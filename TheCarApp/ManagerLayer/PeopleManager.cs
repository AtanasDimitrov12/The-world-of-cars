using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer;
using Entity_Layer.Enums;
using EntityLayout;
using InterfaceLayer;
using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer
{
    public class PeopleManager : IPeopleManager
    {
        public List<Person> people { get; set; }
        private DataAccess access;
        private DataWriter writer;
        private DataRemover remover;
        private IUserRepository _userRepository;
        private IAdministratorRepository _administratorRepository;
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public PeopleManager(IUserRepository userRepository, IAdministratorRepository administratorRepository)
        {
            people = new List<Person>();
            access = new DataAccess();
            writer = new DataWriter();
            remover = new DataRemover();
            _userRepository = userRepository;
            _administratorRepository = administratorRepository;
        }


        public string AddPerson(Person person)
        {
            switch (person)
            {
                case User user:
                    user.password = HashPassword(user.password, out var salt);
                    user.passSalt = salt;
                    return _userRepository.AddUser(user);
                case Administrator admin:
                    admin.password = HashPassword(admin.password, out salt);
                    admin.passSalt = salt;
                    return _administratorRepository.AddAdmin(admin);
                default:
                    return "Unsupported person type";
            }
        }

        public string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
            salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        public string RemovePerson(Person person)
        {
            switch (person)
            {
                case User user:
                    return _userRepository.RemoveUser(user);
                case Administrator admin:
                    return _administratorRepository.RemoveAdmin(admin);
                default:
                    return "Unsupported person type";
            }
        }

        public string UpdatePerson(Person person)
        {
            switch (person)
            {
                case User user:
                    return _userRepository.UpdateUser(user);
                case Administrator admin:
                    return _administratorRepository.UpdateAdmin(admin);
                default:
                    return "Unsupported person type";
            }
        }

        public bool AuthenticateUser(string UserEmail, string UserPass)
        {
            foreach (User user in _userRepository.GetAllUsers())
            {
                string checkPass = CheckHashPassword(UserPass, user.passSalt);
                if (user.email == UserEmail)
                {
                    if (user.password == checkPass) // Parolite sa razlichni
                    {
                        return true;
                    }
                    else { return false; }
                }
            }
            return false;
        }

        public string CheckHashPassword(string password, byte[] salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
            salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        public User GetUser(string Email)
        {
            foreach (User user in _userRepository.GetAllUsers())
            {
                if (user.email == Email)
                { 
                    return user;
                }
            }
            return null;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            var users = _userRepository.GetAllUsers();
            var admins = _administratorRepository.GetAllAdministrators();

            return users.Cast<Person>().Concat(admins);
        }
    }
}

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


        public void AddPerson(Person person)
        {
            switch (person)
            {
                case User user:
                    user.password = HashPassword(user.password, out var salt);
                    user.passSalt = salt;
                    _userRepository.AddUser(user);
                    break;
                case Administrator admin:
                    admin.password = HashPassword(admin.password, out salt);
                    admin.passSalt = salt;
                    _administratorRepository.AddAdmin(admin);
                    break;
                default:
                    throw new ArgumentException("Unsupported person type");
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

        public void RemovePerson(Person person)
        {
            switch (person)
            {
                case User user:
                    _userRepository.RemoveUser(user);
                    break;
                case Administrator admin:
                    _administratorRepository.RemoveAdmin(admin);
                    break;
                default:
                    throw new ArgumentException("Unsupported person type");
            }
        }

        public void UpdatePerson(Person person)
        {
            switch (person)
            {
                case User user:
                    _userRepository.UpdateUser(user);
                    break;
                case Administrator admin:
                    _administratorRepository.UpdateAdmin(admin);
                    break;
                default:
                    throw new ArgumentException("Unsupported person type");
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

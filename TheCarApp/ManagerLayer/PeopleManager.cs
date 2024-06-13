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
        private IUserRepository _userRepository;
        private IAdministratorRepository _administratorRepository;
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public PeopleManager(IUserRepository userRepository, IAdministratorRepository administratorRepository)
        {
            people = new List<Person>();
            _userRepository = userRepository;
            _administratorRepository = administratorRepository;
        }

        public bool AddPerson(Person person, out string errorMessage)
        {
            errorMessage = string.Empty;
            switch (person)
            {
                case User user:
                    var (hash, salt) = HashPassword(user.Password);
                    user.Password = hash;
                    user.PassSalt = salt;
                    return _userRepository.AddUser(user, out errorMessage);

                case Administrator admin:
                    (hash, salt) = HashPassword(admin.Password);
                    admin.Password = hash;
                    admin.PassSalt = salt;
                    return _administratorRepository.AddAdmin(admin, out errorMessage);

                default:
                    errorMessage = "Unsupported person type";
                    return false;
            }
        }

        public bool RemovePerson(Person person, out string errorMessage)
        {
            errorMessage = string.Empty;
            switch (person)
            {
                case User user:
                    return _userRepository.RemoveUser(user, out errorMessage);
                case Administrator admin:
                    return _administratorRepository.RemoveAdmin(admin, out errorMessage);
                default:
                    errorMessage = "Unsupported person type";
                    return false;
            }
        }

        public bool UpdatePerson(Person person, out string errorMessage)
        {
            errorMessage = string.Empty;
            switch (person)
            {
                case User user:
                    return _userRepository.UpdateUser(user, out errorMessage);
                case Administrator admin:
                    return _administratorRepository.UpdateAdmin(admin, out errorMessage);
                default:
                    errorMessage = "Unsupported person type";
                    return false;
            }
        }

        public bool AuthenticateUser(string userEmail, string userPass, out string errorMessage)
        {
            errorMessage = string.Empty;
            foreach (User user in _userRepository.GetAllUsers())
            {
                if (user.Email == userEmail)
                {
                    if (VerifyPassword(userPass, user.Password, user.PassSalt))
                    {
                        return true;
                    }
                    else
                    {
                        errorMessage = "Invalid password.";
                        return false;
                    }
                }
            }
            errorMessage = "User not found.";
            return false;
        }

        public (string Hash, string Salt) HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm);
            byte[] hash = pbkdf2.GetBytes(keySize);

            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        public bool VerifyPassword(string enteredPassword, string storedPass, string base64Salt)
        {
            byte[] salt = Convert.FromBase64String(base64Salt);
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, iterations, hashAlgorithm);
            byte[] hash = pbkdf2.GetBytes(keySize);

            return Convert.ToBase64String(hash) == storedPass;
        }

        public User GetUser(string email)
        {
            return _userRepository.GetAllUsers().FirstOrDefault(user => user.Email == email);
        }

        public IEnumerable<Person> GetAllPeople()
        {
            var users = _userRepository.GetAllUsers();
            var admins = _administratorRepository.GetAllAdministrators();

            return users.Cast<Person>().Concat(admins);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}

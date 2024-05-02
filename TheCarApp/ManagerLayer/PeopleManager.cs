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
using System.Data.SqlTypes;
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
                    var (hash, salt) = HashPassword(user.password);
                    user.password = hash;
                    user.passSalt = salt; // Store the salt as a Base64 string
                    return _userRepository.AddUser(user);

                case Administrator admin:
                    (hash, salt) = HashPassword(admin.password);
                    admin.password = hash;
                    admin.passSalt = salt; // Store the salt as a Base64 string
                    return _administratorRepository.AddAdmin(admin);

                default:
                    return "Unsupported person type";
            }
        }


        public (string Hash, string Salt) HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16); // Generate a 128-bit salt

            // Use PBKDF2 to hash the password
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000); // 10,000 iterations
            byte[] hash = pbkdf2.GetBytes(20); // Generate a 160-bit hash

            // Convert both hash and salt into Base64 strings for easy storage
            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
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
                if (user.email == UserEmail)
                {
                    if (VerifyPassword(UserPass, user.password, user.passSalt)) // Parolite sa razlichni
                    {
                        return true;
                    }
                    else { return false; }
                }
            }
            return false;
        }

        public bool VerifyPassword(string enteredPassword, string storedPass, string base64Salt)
        {
            byte[] salt = Convert.FromBase64String(base64Salt); // Decode the Base64 string to get the salt byte array
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            return Convert.ToBase64String(hash) == storedPass;
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

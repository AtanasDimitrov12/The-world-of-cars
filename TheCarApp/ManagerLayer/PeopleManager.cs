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


        public string AddPerson(Person person)
        {
            switch (person)
            {
                case User user:
                    var (hash, salt) = HashPassword(user.Password);
                    user.Password = hash;
                    user.PassSalt = salt; 
                    return _userRepository.AddUser(user);

                case Administrator admin:
                    (hash, salt) = HashPassword(admin.Password);
                    admin.Password = hash;
                    admin.PassSalt = salt;
                    return _administratorRepository.AddAdmin(admin);

                default:
                    return "Unsupported person type";
            }
        }


        public (string Hash, string Salt) HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16); 

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000); 
            byte[] hash = pbkdf2.GetBytes(20); 

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
            foreach (User user in _userRepository.GetAllUsers()) //add different example of return message
            {
                if (user.Email == UserEmail)
                {
                    if (VerifyPassword(UserPass, user.Password, user.PassSalt)) 
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
            byte[] salt = Convert.FromBase64String(base64Salt); 
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            return Convert.ToBase64String(hash) == storedPass;
        }


        public User GetUser(string Email)
        {
            foreach (User user in _userRepository.GetAllUsers())
            {
                if (user.Email == Email)
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

        public List<User> GetAllUsers()
        { 
            return _userRepository.GetAllUsers();
        }

    }
}

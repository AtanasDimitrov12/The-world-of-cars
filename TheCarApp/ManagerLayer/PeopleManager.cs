using AutoMapper;
using System.Security.Cryptography;
using DTO;
using InterfaceLayer;

namespace ManagerLayer
{
    public class PeopleManager : IPeopleManager
    {
        private readonly IUserManager _userManager;
        private readonly IAdministratorManager _adminManager;
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public PeopleManager(IUserManager userManager, IAdministratorManager adminManager)
        {
            _userManager = userManager;
            _adminManager = adminManager;
        }

        // Method to add both User and Administrator
        public async Task<(bool Success, string ErrorMessage)> AddPersonAsync(object person)
        {
            if (person is UserDTO userDto)
            {
                var (hash, salt) = HashPassword(userDto.PasswordHash);
                userDto.PasswordHash = hash;
                userDto.Salt = salt;
                return await _userManager.AddUserAsync(userDto);
            }
            else if (person is AdministratorDTO adminDto)
            {
                var (hash, salt) = HashPassword(adminDto.PasswordHash);
                adminDto.PasswordHash = hash;
                adminDto.Salt = salt;
                return await _adminManager.AddAdminAsync(adminDto);
            }
            return (false, "Invalid person type.");
        }

        // Method to remove both User and Administrator
        public async Task<(bool Success, string ErrorMessage)> RemovePersonAsync(object person)
        {
            if (person is UserDTO userDto)
            {
                return await _userManager.RemoveUserAsync(userDto);
            }
            else if (person is AdministratorDTO adminDto)
            {
                return await _adminManager.RemoveAdminAsync(adminDto);
            }
            return (false, "Invalid person type.");
        }

        // Method to update both User and Administrator
        public async Task<(bool Success, string ErrorMessage)> UpdatePersonAsync(object person)
        {
            if (person is UserDTO userDto)
            {
                var (hash, salt) = HashPassword(userDto.PasswordHash);
                userDto.PasswordHash = hash;
                userDto.Salt = salt;
                return await _userManager.UpdateUserAsync(userDto);
            }
            else if (person is AdministratorDTO adminDto)
            {
                var (hash, salt) = HashPassword(adminDto.PasswordHash);
                adminDto.PasswordHash = hash;
                adminDto.Salt = salt;
                return await _adminManager.UpdateAdminAsync(adminDto);
            }
            return (false, "Invalid person type.");
        }

        // Authentication for users (similar logic can be applied for administrators)
        public bool AuthenticateUser(string email, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            var user = _userManager.GetAllUsers().FirstOrDefault(u => u.Email == email);
            if (user != null && VerifyPassword(password, user.PasswordHash, user.Salt))
            {
                return true;
            }

            var admin = _adminManager.GetAllAdministrators().FirstOrDefault(a => a.Email == email);
            if (admin != null && VerifyPassword(password, admin.PasswordHash, admin.Salt))
            {
                return true;
            }

            errorMessage = "Invalid credentials.";
            return false;
        }

        // Shared password hashing logic
        public (string Hash, string Salt) HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm);
            byte[] hash = pbkdf2.GetBytes(keySize);

            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        // Shared password verification logic
        private bool VerifyPassword(string enteredPassword, string storedPasswordHash, string storedSalt)
        {
            byte[] salt = Convert.FromBase64String(storedSalt);
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, iterations, hashAlgorithm);
            byte[] hash = pbkdf2.GetBytes(keySize);

            return Convert.ToBase64String(hash) == storedPasswordHash;
        }

        // Fetching all users
        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _userManager.GetAllUsers();
        }

        // Fetching all administrators
        public IEnumerable<AdministratorDTO> GetAllAdministrators()
        {
            return _adminManager.GetAllAdministrators();
        }

        // Method to get all people (both Users and Administrators)
        public IEnumerable<object> GetAllPeople()
        {
            var users = _userManager.GetAllUsers();
            var admins = _adminManager.GetAllAdministrators();

            return users.Cast<object>().Concat(admins);
        }

    }
}

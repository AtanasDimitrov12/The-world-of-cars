using System;
using System.Collections.Generic;
using InterfaceLayer;
using DatabaseAccess;
using Database;
using Entity_Layer;
using DTO;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IPeopleDataWriter writer;
        private readonly IPeopleDataRemover remover;
        private readonly IDataAccess access;
        private readonly List<User> users;

        public UserRepository(IDataAccess dataAccess, IPeopleDataWriter dataWriter, IPeopleDataRemover dataRemover)
        {
            writer = dataWriter;
            remover = dataRemover;
            access = dataAccess;
            users = new List<User>();
        }

        public bool AddUser(User user, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                writer.AddUser(user.Username, user.Email, user.Password, user.LicenseNumber, user.CreatedOn, user.PassSalt);
                writer.UploadProfilePicture(user, user.ProfilePicturePath);
                users.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool UploadProfilePicture(User user, string relativeFilePath, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                remover.RemoveProfilePicture(user.Id);
                writer.UploadProfilePicture(user, relativeFilePath);
                user.ProfilePicturePath = relativeFilePath; // Update the user profile picture path
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public string GetProfilePicPathById(int userId)
        {
            foreach (var user in users)
            {
                if (user.Id == userId)
                {
                    return user.ProfilePicturePath;
                }
            }
            return string.Empty;
        }

        public bool RemoveUser(User user, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                remover.RemoveUser(user.Id);
                users.Remove(user);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool UpdateUser(User user, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                writer.UpdateUser(user.Id, user.Username, user.Email, user.Password, user.LicenseNumber, user.CreatedOn);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public string GetUserNameById(int userId)
        {
            foreach (var user in users)
            {
                if (user.Id == userId)
                {
                    return user.Username;
                }
            }
            return string.Empty;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public bool LoadUsers(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var loadUsers = access.GetUsers();
                if (loadUsers != null)
                {
                    foreach (UserDTO userDTO in loadUsers)
                    {
                        User user = new User(userDTO.Id, userDTO.email, userDTO.password, userDTO.Username, userDTO.CreatedOn, userDTO._licenseNumber, userDTO.passSalt, userDTO.ProfilePicturePath);
                        users.Add(user);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}

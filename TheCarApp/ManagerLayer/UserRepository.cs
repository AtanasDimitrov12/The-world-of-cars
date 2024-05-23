using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer;
using DatabaseAccess;
using Database;
using Entity_Layer;
using DTO;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private IPeopleDataWriter writer;
        private IPeopleDataRemover remover;
        private IDataAccess access;
        List<User> users;

        public UserRepository(IDataAccess dataAccess, IPeopleDataWriter dataWriter, IPeopleDataRemover dataRemover)
        {
            writer = dataWriter;
            remover = dataRemover;
            access = dataAccess;
            users = new List<User>();
        }

        public string AddUser(User user)
        {
            try
            {
                writer.AddUser(user.Username, user.Email, user.Password, user.LicenseNumber, user.CreatedOn, user.PassSalt);
                users.Add(user);
                return "done";
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
            
            
        }

        public string RemoveUser(User user)
        {
            try
            {
                remover.RemoveUser(user.Id);
                users.Remove(user);
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string UpdateUser(User user)
        {
            try
            { 
            writer.UpdateUser(user.Id, user.Username, user.Email, user.Password, user.LicenseNumber, user.CreatedOn);
            return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string GetUserNameById(int UserID) 
        {
            foreach (var user in users) 
            {
                if (user.Id == UserID)
                { 
                    return user.Username;
                }
            }
            return "";
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public string LoadUsers()
        {
            try
            {
                var loadUsers = access.GetUsers();
                if (loadUsers != null)
                {
                    foreach (UserDTO userDTO in access.GetUsers())
                    {
                        User user = new User(userDTO.Id, userDTO.email, userDTO.password, userDTO.Username, userDTO.CreatedOn, userDTO._licenseNumber, userDTO.passSalt);
                        users.Add(user);
                    }
                }
                return "done";
            }
            catch (ApplicationException ex)
            {
                return ex.Message;
            }
            
        }
    }
}

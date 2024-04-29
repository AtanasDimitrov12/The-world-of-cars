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
        private IDataWriter writer;
        private IDataRemover remover;
        private IDataAccess access;
        List<User> users;

        public UserRepository(IDataAccess dataAccess, IDataWriter dataWriter, IDataRemover dataRemover)
        {
            writer = dataWriter;
            remover = dataRemover;
            access = dataAccess;
            users = new List<User>();
        }

        public string AddUser(User user)
        {
            string Message = writer.AddUser(user.Username, user.email, user.password, user._licenseNumber, user.CreatedOn, user.passSalt);
            if (Message == "done")
            {
                users.Add(user);
                return "done";
            }
            else { return Message; }
            
        }

        public string RemoveUser(User user)
        {
            string Message = remover.RemoveUser(user.Id);
            if (Message == "done")
            {
                users.Remove(user);
                return "done";
            }
            else { return Message; }
            
        }

        public string UpdateUser(User user)
        {
            string Message = writer.UpdateUser(user.Id, user.Username, user.email, user.password, user._licenseNumber, user.CreatedOn);
            if (Message == "done")
            {
                return "done";
            }
            else { return Message; }
            
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

        //public bool CheckUserDetails(User user)
        //{ 
        //    foreach (var storedUser in users) 
        //    {
        //        if (user.email == storedUser.email)
        //        {
        //            if (user.password == storedUser.password)
        //            {
        //                return true;
        //            }
        //        }
        //        else { return false; }
        //    }
        //    return false;
        //}

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

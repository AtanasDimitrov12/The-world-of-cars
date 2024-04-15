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

        public void AddUser(User user)
        {
            writer.AddUser(user.Username, user.email, user.password, user._licenseNumber, user.CreatedOn);
            users.Add(user);
        }



        public void RemoveUser(User user)
        {
            remover.RemoveUser(user.Id);
            users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            writer.UpdateUser(user.Id, user.Username, user.email, user.password, user._licenseNumber, user.CreatedOn);
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

        public void LoadUSers()
        {
            if (access.GetUsers() != null)
            {
                foreach (UserDTO userDTO in access.GetUsers())
                {
                    User user = new User(userDTO.Id, userDTO.email, userDTO.password, userDTO.Username, userDTO.CreatedOn, userDTO._licenseNumber);
                    users.Add(user);
                }
            }
        }
    }
}

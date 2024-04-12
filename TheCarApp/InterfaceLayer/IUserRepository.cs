using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void RemoveUser(User user);
        void UpdateUser(User user);
        List<User> GetAllUsers();
        void LoadUSers();
    }
}

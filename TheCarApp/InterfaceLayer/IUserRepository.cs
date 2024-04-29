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
        string AddUser(User user);
        string RemoveUser(User user);
        string UpdateUser(User user);
        string GetUserNameById(int UserID);
        List<User> GetAllUsers();
        string LoadUsers();
    }
}

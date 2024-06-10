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
        bool AddUser(User user, out string errorMessage);
        bool UploadProfilePicture(User user, string relativeFilePath, out string errorMessage);
        string GetProfilePicPathById(int userId);
        bool RemoveUser(User user, out string errorMessage);
        bool UpdateUser(User user, out string errorMessage);
        string GetUserNameById(int userId);
        List<User> GetAllUsers();
        bool LoadUsers(out string errorMessage);
    }
}

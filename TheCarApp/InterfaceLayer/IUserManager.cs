using Data.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IUserManager
    {
        Task<(bool Success, string ErrorMessage)> AddUserAsync(UserDTO userDTO);
        Task<(bool Success, string ErrorMessage)> UploadProfilePictureAsync(UserDTO userDTO, string relativeFilePath);
        string GetProfilePicPathById(int userId);
        Task<(bool Success, string ErrorMessage)> RemoveUserAsync(UserDTO userDTO);
        Task<(bool Success, string ErrorMessage)> UpdateUserAsync(UserDTO userDTO);
        string GetUserNameById(int userId);
        List<UserDTO> GetAllUsers();
        UserDTO FindUserById(int userId);
        UserDTO FindUserByEmail(string Email);
        Task<(bool Success, string ErrorMessage)> LoadUsersAsync();
    }
}

using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IPeopleManager
    {
        Task<(bool Success, string ErrorMessage)> AddPersonAsync(object person);
        Task<(bool Success, string ErrorMessage)> RemovePersonAsync(object person);
        Task<(bool Success, string ErrorMessage)> UpdatePersonAsync(object person);
        bool AuthenticateUser(string email, string password, out string errorMessage);
        IEnumerable<UserDTO> GetAllUsers();
        IEnumerable<AdministratorDTO> GetAllAdministrators();
        IEnumerable<object> GetAllPeople();
    }
}

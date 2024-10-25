using Data.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IAdministratorManager
    {
        Task<(bool Success, string ErrorMessage)> AddAdminAsync(AdministratorDTO admin);
        Task<(bool Success, string ErrorMessage)> RemoveAdminAsync(AdministratorDTO admin);
        Task<(bool Success, string ErrorMessage)> UpdateAdminAsync(AdministratorDTO admin);
        List<AdministratorDTO> GetAllAdministrators();
        Task<(bool Success, string ErrorMessage)> LoadAdminsAsync();
    }
}

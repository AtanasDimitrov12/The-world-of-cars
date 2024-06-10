using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer;
using InterfaceLayer;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly IPeopleDataWriter writer;
        private readonly IPeopleDataRemover remover;
        private readonly IDataAccess access;
        public List<Administrator> admins;

        public AdministratorRepository(IDataAccess dataAccess, IPeopleDataWriter dataWriter, IPeopleDataRemover dataRemover)
        {
            writer = dataWriter;
            access = dataAccess;
            remover = dataRemover;
            admins = new List<Administrator>();
        }

        public bool AddAdmin(Administrator admin, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                writer.AddAdmin(admin.Username, admin.Email, admin.Password, admin.PhoneNumber, admin.CreatedOn, admin.PassSalt);
                admins.Add(admin);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool RemoveAdmin(Administrator admin, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                remover.RemoveAdmin(admin.Id);
                admins.Remove(admin);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool UpdateAdmin(Administrator admin, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                writer.UpdateAdministration(admin.Id, admin.Username, admin.Email, admin.Password, admin.PhoneNumber, admin.CreatedOn, admin.PassSalt);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public List<Administrator> GetAllAdministrators()
        {
            return admins;
        }

        public bool LoadAdmins(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var loadAdmins = access.GetAdministrators();
                if (loadAdmins != null)
                {
                    foreach (AdministratorDTO adminDTO in loadAdmins)
                    {
                        var admin = new Administrator(adminDTO.Id, adminDTO.email, adminDTO.password, adminDTO.Username, adminDTO.CreatedOn, adminDTO._phoneNumber, adminDTO.passSalt);
                        admins.Add(admin);
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

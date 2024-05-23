using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer;
using EntityLayout;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private IPeopleDataWriter writer;
        private IPeopleDataRemover remover;
        private IDataAccess access;
        public List<Administrator> admins;

        public AdministratorRepository(IDataAccess dataAccess, IPeopleDataWriter dataWriter, IPeopleDataRemover dataRemover)
        {
            writer = dataWriter;
            access = dataAccess;
            remover = dataRemover;
            admins = new List<Administrator>();
        }

        public string AddAdmin(Administrator admin)
        {
            try
            {
                writer.AddAdmin(admin.Username, admin.Email, admin.Password, admin.PhoneNumber, admin.CreatedOn, admin.PassSalt);

                admins.Add(admin);
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string RemoveAdmin(Administrator admin)
        {
            try
            {
                remover.RemoveAdmin(admin.Id);
                admins.Remove(admin);
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateAdmin(Administrator admin)
        {
            try
            {
                writer.UpdateAdministration(admin.Id, admin.Username, admin.Email, admin.Password, admin.PhoneNumber, admin.CreatedOn, admin.PassSalt); ;
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Administrator> GetAllAdministrators()
        {
            return admins;
        }

        public string LoadAdmins()
        {
            List<AdministratorDTO> loadAdmins;
            try
            {
                loadAdmins = access.GetAdministrators();
                if (loadAdmins != null)
                {
                    foreach (AdministratorDTO adminDTO in loadAdmins)
                    {
                        Administrator admin = new Administrator(adminDTO.Id, adminDTO.email, adminDTO.password, adminDTO.Username, adminDTO.CreatedOn, adminDTO._phoneNumber, adminDTO.passSalt);
                        admins.Add(admin);
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

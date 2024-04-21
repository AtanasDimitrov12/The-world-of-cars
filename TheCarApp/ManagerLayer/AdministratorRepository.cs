using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer;
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
        private IDataWriter writer;
        private IDataRemover remover;
        private IDataAccess access;
        public List<Administrator> admins;

        public AdministratorRepository(IDataAccess dataAccess, IDataWriter dataWriter, IDataRemover dataRemover)
        { 
            writer = dataWriter;
            access = dataAccess;
            remover = dataRemover;
            admins = new List<Administrator>();
        }

        public void AddAdmin(Administrator admin)
        {
            writer.AddAdmin(admin.Username, admin.email, admin.password, admin._phoneNumber, admin.CreatedOn);
            admins.Add(admin);
        }


        public void RemoveAdmin(Administrator admin)
        {
            remover.RemoveAdmin(admin.Id);
            admins.Remove(admin);
        }

        public void UpdateAdmin(Administrator admin)
        {
            writer.UpdateAdministration(admin.Id, admin.Username, admin.email, admin.password, admin._phoneNumber, admin.CreatedOn);
        }
        public List<Administrator> GetAllAdministrators()
        {
            return admins;
        }

        public void LoadAdmins()
        {
            if (access.GetAdministrators() != null)
            {
                foreach (AdministratorDTO adminDTO in access.GetAdministrators())
                {
                    Administrator admin = new Administrator(adminDTO.Id, adminDTO.email, adminDTO.password, adminDTO.Username, adminDTO.CreatedOn, adminDTO._phoneNumber, adminDTO.passSalt);
                    admins.Add(admin);
                }
            }
        }
    }


}

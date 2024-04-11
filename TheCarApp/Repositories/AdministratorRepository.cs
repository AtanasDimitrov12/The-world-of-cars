using Database;
using DatabaseAccess;
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
        public List<Administrator> admins = new List<Administrator>();

        // Constructor and implementation of methods

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
    }


}

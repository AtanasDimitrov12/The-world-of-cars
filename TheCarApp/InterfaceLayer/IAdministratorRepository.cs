using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IAdministratorRepository
    {
        bool AddAdmin(Administrator admin, out string errorMessage);
        bool RemoveAdmin(Administrator admin, out string errorMessage);
        bool UpdateAdmin(Administrator admin, out string errorMessage);
        List<Administrator> GetAllAdministrators();
        bool LoadAdmins(out string errorMessage);
    }
}

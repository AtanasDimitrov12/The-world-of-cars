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
        string AddAdmin(Administrator admin);
        string RemoveAdmin(Administrator admin);
        string UpdateAdmin(Administrator admin);
        List<Administrator> GetAllAdministrators();
        string LoadAdmins();
    }
}

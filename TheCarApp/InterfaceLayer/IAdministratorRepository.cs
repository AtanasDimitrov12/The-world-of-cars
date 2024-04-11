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
        void AddAdmin(Administrator admin);
        void RemoveAdmin(Administrator admin);
        void UpdateAdmin(Administrator admin);
        List<Administrator> GetAllAdministrators();
    }
}

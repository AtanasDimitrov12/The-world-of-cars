using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IPeopleDataRemover
    {
        string RemoveUser(int UserId);
        string RemoveAdmin(int AdminId);
        string RemoveRental(int RentalId);
    }
}

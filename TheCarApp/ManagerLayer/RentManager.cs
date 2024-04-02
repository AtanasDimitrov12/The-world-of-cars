using Entity_Layer;
using Entity_Layer.Enums;
using EntityLayout;
using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer
{
    public class RentManager
    {
        public List<RentACar> rentalHistory { get; set; }

        public RentManager() 
        { 
            rentalHistory = new List<RentACar>();
        }

        public void RentACar(User user, Car car, DateTime startDate, DateTime endDate)
        {
            RentACar rentACar = new RentACar(user, car, startDate, endDate);
        }

        public void ChangeRentStatus(RentACar rentACar, RentStatus status)
        { 
            rentACar.ChangeStatus(status);
        }
    }
}

using Entity_Layer.Enums;
using InterfaceLayer;
using Manager_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Strategy
{
    public class StandardRentalStrategy : IRentalStrategy
    {
        public decimal CalculateRentalPrice(decimal BasePriceOfCar, int daysRented)
        {
            // Standard pricing logic
            return BasePriceOfCar * daysRented;
        }


        public void UpdateRentalStatus(RentACar rental, RentStatus status)
        {
            rental.RentStatus = status;
        }
    }
}

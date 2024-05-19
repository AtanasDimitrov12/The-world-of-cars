using Entity_Layer.Enums;
using InterfaceLayer;
using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Strategy
{
    public class PeakSeasonRentalStrategy : IRentalStrategy
    {
        public decimal CalculateRentalPrice(decimal BasePriceOfCar, int daysRented)
        {
            // Increased pricing during peak season
            return (BasePriceOfCar * 1.2m) * daysRented; // 20% more
        }


        public void UpdateRentalStatus(RentACar rental, RentStatus status)
        {
            rental.RentStatus = status;
        }
    }
}

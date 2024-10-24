using DTO;
using DTO.Enums;
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
        public decimal CalculateRentalPrice(decimal BasePriceOfCar, int daysRented, int Discount)
        {
            // Increased pricing during peak season
            decimal Price = (BasePriceOfCar * 1.2m) * daysRented; // 20% more
            return Price - Price * (Discount / 100);
        }


        public void UpdateRentalStatus(RentACarDTO rental, RentStatus status)
        {
            rental.Status = status.ToString();
        }
    }
}

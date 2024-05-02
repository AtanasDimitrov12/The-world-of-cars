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
        public decimal CalculateRentalPrice(RentACar rental, int daysRented)
        {
            // Increased pricing during peak season
            return (rental.car.PricePerDay * 1.2m) * daysRented; // 20% more
        }

        //public void ApplyDiscount(RentACar rental)
        //{
        //    // Smaller discount during peak times
        //    if (rental.DaysRented > 10)
        //    {
        //        rental.Discount = 0.05m; // 5% discount
        //    }
        //}

        public void UpdateRentalStatus(RentACar rental, RentStatus status)
        {
            rental.status = status;
        }
    }
}

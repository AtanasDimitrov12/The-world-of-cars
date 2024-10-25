using DTO.Enums;
using DTO;
using InterfaceLayer;

namespace ManagerLayer.Strategy
{
    public class StandardRentalStrategy : IRentalStrategy
    {
        public decimal CalculateRentalPrice(decimal BasePriceOfCar, int daysRented, int Discount)
        {
            // Standard pricing logic
            decimal Price = BasePriceOfCar * daysRented;
            return Price - Price * (Discount/100);
        }


        public void UpdateRentalStatus(RentACarDTO rental, RentStatus status)
        {
            rental.Status = status.ToString();
        }
    }
}

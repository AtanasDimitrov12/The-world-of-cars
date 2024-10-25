using DTO;
using DTO.Enums;

namespace InterfaceLayer
{
    public interface IRentalStrategy
    {
        decimal CalculateRentalPrice(decimal BasePriceOfCar, int daysRented, int Discount);
        void UpdateRentalStatus(RentACarDTO rental, RentStatus status);
    }
}


using DTO;
using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Enums;

namespace InterfaceLayer
{
    public interface IRentalStrategy
    {
        decimal CalculateRentalPrice(decimal BasePriceOfCar, int daysRented, int Discount);
        void UpdateRentalStatus(RentACarDTO rental, RentStatus status);
    }
}

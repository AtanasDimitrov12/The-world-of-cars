using Entity_Layer.Enums;
using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IRentalStrategy
    {
        decimal CalculateRentalPrice(decimal BasePriceOfCar, int daysRented);
        void UpdateRentalStatus(RentACar rental, RentStatus status);
    }
}

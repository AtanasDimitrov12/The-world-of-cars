using Entity_Layer.Enums;
using Entity_Layer;
using EntityLayout;
using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IRentManager
    {
        List<RentACar> rentalHistory { get; set; }

        bool IsPeakSeason(DateTime startDate, DateTime endDate);
        decimal CalculatePrice(decimal BasePrice, DateTime startDate, DateTime endDate);
        string RentACar(RentACar rentACar);
        void UpdateRentStatus(RentACar rental, RentStatus newStatus);
        void UpdateRental(RentACar rental);
        void RemoveRent(RentACar rental);
        bool IsCarAvailable(int carId, DateTime startDate, DateTime endDate);
        string LoadRentals();
    }
}

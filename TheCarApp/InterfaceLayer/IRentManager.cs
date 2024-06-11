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

        decimal CalculatePrice(User user, decimal BasePrice, DateTime startDate, DateTime endDate);
        int CheckForDiscount(User user);
        string RentACar(RentACar rentACar);
        void UpdateRentStatus(RentACar rental, RentStatus newStatus);
        void UpdateRental(RentACar rental);
        void RemoveRent(RentACar rental);
        bool IsCarAvailable(int carId, DateTime startDate, DateTime endDate);
        List<RentACar> GetRentedPeriods(int carId);
        string LoadRentals();
    }
}

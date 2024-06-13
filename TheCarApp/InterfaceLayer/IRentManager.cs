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
        List<RentACar> RentalHistory { get; set; }

        decimal CalculatePrice(User user, decimal basePrice, DateTime startDate, DateTime endDate);

        int CheckForDiscount(User user);

        bool RentACar(RentACar rentACar, out string errorMessage);

        bool UpdateRentStatus(RentACar rental, RentStatus newStatus, out string errorMessage);

        bool RemoveRent(RentACar rental, out string errorMessage);

        List<RentACar> GetRentedPeriods(int carId);

        bool IsCarAvailable(int carId, DateTime startDate, DateTime endDate);

        bool LoadRentals(out string errorMessage);
    }
}

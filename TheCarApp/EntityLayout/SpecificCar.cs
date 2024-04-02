using Entity_Layer.Enums;
using EntityLayout;

namespace EntityLayout
{
    public class SpecificCar : Car
    {
        public SpecificCar(string brand, string model, int Year, int Mileage, string FuelType, int Enginesize, int horsePower, string GearBox, string color, string VIN, string description, decimal pricePerDay, CarStatus carStatus)
            : base(brand, model, Year, Mileage, FuelType, Enginesize, horsePower, GearBox, color, VIN, description, pricePerDay, carStatus)
        {
            // Additional initialization specific to SpecificCar, if needed
        }
    }
}

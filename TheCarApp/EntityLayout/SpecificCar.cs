using EntityLayout;

namespace EntityLayout
{
    public class SpecificCar : Car
    {
        public SpecificCar(string brand, string model, int Year, int Mileage, string FuelType, int Enginesize, int horsePower, string GearBox, string color, decimal price)
            : base(brand, model, Year, Mileage, FuelType, Enginesize, horsePower, GearBox, color, price)
        {
            // Additional initialization specific to SpecificCar, if needed
        }
    }
}

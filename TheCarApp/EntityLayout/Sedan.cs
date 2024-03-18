using EntityLayout;
using EntityLayout.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Sedan : Car
    {
        private int NrOfSeats;
        private bool IsComfortable;

        public Sedan(CarBrands brand, string model, int Year, int Mileage, string FuelType, int Enginesize, int horsePower, string GearBox, string color, decimal price, int nrOfSeats)
            : base(brand, model, Year, Mileage, FuelType, Enginesize, horsePower, GearBox, color, price)
        {
            NrOfSeats = nrOfSeats;
        }

        public void IsComfortableFor5()
        {
            if (NrOfSeats >= 5)
            {
                IsComfortable = true;
            }
            else { IsComfortable = false; }
        }
    }
}

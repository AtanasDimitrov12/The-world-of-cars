using EntityLayout;
using EntityLayout.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Coupe : Car
    {
        private int NrOfSeats;
        private bool IsComfortable;

        public Coupe(CarBrands brand, string model, int startYear, int endYear, string engineType, int horsePower, int maxSpeed, float acceleration, int nrOfSeats)
            : base(brand, model, startYear, endYear, engineType, horsePower, maxSpeed, acceleration)
        {
            this.NrOfSeats = nrOfSeats;
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

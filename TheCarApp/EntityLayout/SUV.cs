using EntityLayout;
using EntityLayout.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class SUV : Car
    {
        private int NrOfSeats;
        private bool IsComfortable;
        private int WheelDrive;
        private bool IsAllWheelDrive;

        public SUV(CarBrands brand, string model, int startYear, int endYear, string engineType, int horsePower, int maxSpeed, float acceleration, int nrOfSeats, int wheelDrive)
            : base(brand, model, startYear, endYear, engineType, horsePower, maxSpeed, acceleration)
        {
            this.NrOfSeats = nrOfSeats;
            this.WheelDrive = wheelDrive;
        }

        public void IsComfortableFor7()
        {
            if (NrOfSeats >= 7)
            {
                IsComfortable = true;
            }
            else { IsComfortable = false; }
        }

        public bool GetComfortable()
        { 
            return IsComfortable;
        }

        public void Is4x4()
        {
            if (WheelDrive == 4)
            {
                IsAllWheelDrive = true;
            }
            else { IsAllWheelDrive = false; }
        }

        public bool AllWheelDrive()
        {
            return IsAllWheelDrive;
        }
    }
}

using Entity_Layer;
using Entity_Layer.Enums;
using EntityLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayout
{
    public class Car
    {
        public string brand { get; set; }
        public string Model { get; set; }
        public int FirstRegistration { get; set; }
        public int Mileage { get; set; }
        public string Fuel { get; set; }
        public int EngineSize { get; set; }
        public int HorsePower { get; set; }
        public string Gearbox { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }
        public List<string> Pictures { get; set; }
        public List<Extra> CarExtras { get; set; }
        public CarStatus CarStatus { get; set; }

        public Car(string brand, string model, int Year, int Mileage, string FuelType, int Enginesize , int horsePower, string GearBox, string color, string VIN, string description, decimal pricePerDay, CarStatus carStatus)
        {
            this.brand = brand;
            Model = model;
            FirstRegistration = Year;
            this.Mileage = Mileage;
            Fuel = FuelType;
            EngineSize = Enginesize;
            HorsePower = horsePower;
            Gearbox = GearBox;
            Color = color;
            VIN = VIN;
            Description = description;
            PricePerDay = pricePerDay;
            Pictures = new List<string> { };
            CarExtras = new List<Extra> { };
            CarStatus = carStatus;
        }


        //public List<string> GetPictures()
        //{
        //    return pictures;
        //}

        //public void AddPicture(string picture)
        //{
        //    pictures.Add(picture);
        //}

        //public void RemovePicture(string picture)
        //{
        //    pictures.Remove(picture);
        //}


    }
}

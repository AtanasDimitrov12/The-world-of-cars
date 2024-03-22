using EntityLayout.Enums;
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
        private string brand { get; set; }
        private string Model { get; set; }
        private int FirstRegistration { get; set; }
        private int Mileage { get; set; }
        private string Fuel { get; set; }
        private int EngineSize { get; set; }
        private int HorsePower { get; set; }
        private string Gearbox { get; set; }
        private string Color { get; set; }
        private decimal Price { get; set; }
        //private Pictures 

        public Car(string brand, string model, int Year, int Mileage, string FuelType, int Enginesize , int horsePower, string GearBox, string color, decimal price)
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
            Price = price;
        }

        public string GetBrand()
        {
            return brand;
        }

        public string GetModel()
        {
            return Model;
        }

        public int FirstReg()
        {
            return FirstRegistration;
        }

        public int GetMileage()
        {
            return Mileage;
        }
        
        public int GetEngineSize()
        {
            return EngineSize;
        }

        public string GetFuelType()
        {
            return Fuel;
        }

        public int GetHorsePower()
        {
            return HorsePower;
        }

        public string GetColor()
        {
            return Color;
        }

        public string GetGearBox()
        {
            return Gearbox;
        }

        public decimal GetPrice()
        {
            return Price;
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

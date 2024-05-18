using Entity_Layer;
using Entity_Layer.Enums;
using EntityLayout;
using Microsoft.VisualBasic;
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
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime FirstRegistration { get; set; }
        public int Mileage { get; set; }
        public string Fuel { get; set; }
        public int EngineSize { get; set; }
        public int HorsePower { get; set; }
        public string Gearbox { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }
        public List<Picture> Pictures { get; set; }
        public List<Extra> CarExtras { get; set; }
        public CarStatus CarStatus { get; set; }
        public int NumberOfSeats { get; set; }
        public string NumberOfDoors { get; set; }
        public int Views { get; set; }

        public Car(int id, string brand, string model, DateTime Year, int Mileage, string FuelType, int Enginesize , int horsePower, string GearBox, string color, string VIN, string description, decimal pricePerDay, CarStatus carStatus, int numberOfSeats, string numberOfDoors, int views)
        {
            this.Id = id;
            this.Brand = brand;
            Model = model;
            FirstRegistration = Year;
            this.Mileage = Mileage;
            Fuel = FuelType;
            EngineSize = Enginesize;
            HorsePower = horsePower;
            Gearbox = GearBox;
            Color = color;
            this.VIN = VIN;
            Description = description;
            PricePerDay = pricePerDay;
            Pictures = new List<Picture> { };
            CarExtras = new List<Extra> { };
            CarStatus = carStatus;
            NumberOfSeats = numberOfSeats;
            NumberOfDoors = numberOfDoors;
            Views = views;
        }

        public Car(string brand, string model, DateTime Year, int Mileage, string FuelType, int Enginesize, int horsePower, string GearBox, string color, string VIN, string description, decimal pricePerDay, CarStatus carStatus, int numberOfSeats, string numberOfDoors, int views)
        {
            this.Brand = brand;
            Model = model;
            FirstRegistration = Year;
            this.Mileage = Mileage;
            Fuel = FuelType;
            EngineSize = Enginesize;
            HorsePower = horsePower;
            Gearbox = GearBox;
            Color = color;
            this.VIN = VIN;
            Description = description;
            PricePerDay = pricePerDay;
            Pictures = new List<Picture> { };
            CarExtras = new List<Extra> { };
            CarStatus = carStatus;
            NumberOfSeats = numberOfSeats;
            NumberOfDoors = numberOfDoors;
            this.Views = views;
        }

        public Car()
        { }
        public void AddPicture(Picture picture)
        {
            this.Pictures.Add(picture);
        }

        public void RemovePicture(Picture picture)
        {
            this.Pictures.Remove(picture);
        }

        public void AddExtra(Extra extra)
        {
            CarExtras.Add(extra);
        }

        public void RemoveExtra(Extra extra)
        {
            CarExtras.Remove(extra);
        }

        public string GetInfo()
        {
            return $"{Brand} {Model} {FirstRegistration.ToShortDateString()}";
        }

    }
}

using EntityLayout.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayout
{
    public abstract class Car
    {
        private CarBrands brand;
        private string Model;
        private int StartYear;
        private int EndYear;
        private string EngineType;
        private int HorsePower;
        private int MaxSpeed;
        private float Acceleration;
        //private Pictures 

        protected Car(CarBrands brands, string model, int startYear, int endYear, string engineType, int horsePower, int maxSpeed, float acceleration)
        {
            this.brand = brands;
            Model = model;
            StartYear = startYear;
            EndYear = endYear;
            EngineType = engineType;
            HorsePower = horsePower;
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
        }

        public CarBrands GetBrand()
        {
            return brand;
        }

        public string GetModel()
        {
            return Model;
        }

        public int GetStartYear()
        {
            return StartYear;
        }

        public int GetEndYear()
        {
            return EndYear;
        }

        public string GetEngineType()
        {
            return EngineType;
        }

        public int GetHorsePower()
        {
            return HorsePower;
        }

        public int GetMaxSpeed()
        {
            return MaxSpeed;
        }

        public float GetAcceleration()
        {
            return Acceleration;
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

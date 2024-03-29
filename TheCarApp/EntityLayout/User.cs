using EntityLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class User : Member
    {
        private string _licenseNumber;
        private List<Car> rentedCars;

        public User(string Email, string Password, string UserName, DateTime CreatedON, string License) : base(Email, Password, UserName, CreatedON)
        {
            this._licenseNumber = License;
            rentedCars = new List<Car>();   
        }

        public void AddCar(Car car)
        { 
            rentedCars.Add(car);
        }

        public List<Car> GetCars()
        { 
            return rentedCars;
        }
        public override string ToString()
        {
            return _licenseNumber;
        }
    }
}

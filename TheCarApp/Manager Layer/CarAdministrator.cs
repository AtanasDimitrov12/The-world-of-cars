using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayout;



namespace Manager_Layer
{
    public class CarAdministrator
    {
        private List<Car> cars;

        public CarAdministrator()
        { 
            cars = new List<Car>(); 
        }

        public void AddCar(Car car) 
        {
            cars.Add(car);
        }

        public Car SearchForCar(int index)  //Something to search with a new method
        { 
            return cars[index];
        }

        public List<Car> GetCars() 
        {
            return cars;
        }
    }
}

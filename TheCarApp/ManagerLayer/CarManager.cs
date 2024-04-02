using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayout;



namespace Manager_Layer
{
    public class CarManager
    {
        private List<Car> cars;

        public CarManager()
        { 
            cars = new List<Car>(); 
        }

        public void AddCar(Car car) 
        {
            cars.Add(car);
        }

        public void RemoveCar(Car car)
        {
            cars.Remove(car);
        }

        public Car SearchForCar(int index)
        { 
            return cars[index];
        }

        public List<Car> GetCars() 
        {
            return cars;
        }
    }
}

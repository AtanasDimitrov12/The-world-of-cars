using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using DTO;
using Entity_Layer.Enums;
using EntityLayout;



namespace Manager_Layer
{
    public class CarManager
    {
        private List<Car> cars;
        private DataAccess access;

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

        public void LoadCars()
        {
            if (access.GetCars() != null)
            {
                foreach (CarDTO carDTO in access.GetCars())
                {
                    CarStatus status;
                    bool isValidArea = Enum.TryParse(carDTO.CarStatus.ToUpper(), true, out status);

                    if (isValidArea)
                    {

                        Car loadCar = new Car(carDTO.Id, carDTO.Brand, carDTO.Model, carDTO.FirstRegistration, carDTO.Mileage, carDTO.Fuel, carDTO.EngineSize, carDTO.HorsePower, carDTO.Gearbox, carDTO.Color, carDTO.VIN, carDTO.Description, carDTO.PricePerDay, status);

                        cars.Add(loadCar);

                    }
                    else
                    {
                        Console.WriteLine($"Warning: {carDTO.Id} has an invalid area assigned.");
                    }
                }
            }
        }
    }
}

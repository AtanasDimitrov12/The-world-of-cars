using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer;
using Entity_Layer.Enums;
using Entity_Layer.Interfaces;
using EntityLayout;
using InterfaceLayer;



namespace Manager_Layer
{
    public class CarManager : ICarManager
    {
        private List<Car> cars;
        private readonly IDataAccess _dataAccess;
        private readonly IDataWriter _dataWriter;
        private readonly IDataRemover _dataRemover;

        public CarManager(IDataAccess dataAccess, IDataWriter dataWriter, IDataRemover dataRemover)
        {
            cars = new List<Car>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
        }

        public void AddCar(Car car, List<Picture> pictures, List<Extra> extras)
        {
            cars.Add(car);
            _dataWriter.AddCar(car.brand, car.Model, car.FirstRegistration, car.Mileage, car.Fuel, car.EngineSize, car.HorsePower, car.Gearbox, car.NumberOfSeats, car.NumberOfDoors, car.Color, car.VIN, car.CarStatus.ToString());
            int carId = _dataWriter.GetCarId(car.VIN);
            car.Id = carId;
            _dataWriter.AddCarDescription(car.Id, car.Description, car.PricePerDay);
            foreach (Picture pic in pictures)
            {
                _dataWriter.AddCarPictures(car.Id, pic.Id);
                car.AddPicture(pic);
            }
            foreach (Extra extra in extras)
            {
                _dataWriter.AddCarExtras(car.Id, extra.Id);
                car.AddExtra(extra);
            }
        }

        public void UpdateCar(Car car)
        {
            _dataWriter.UpdateCar(car);
            _dataWriter.UpdateCarDescription(car);
            _dataWriter.RemoveCarPictures(car.Id);
            _dataWriter.RemoveCarExtras(car.Id);
            foreach (Picture pic in car.Pictures)
            {
                _dataWriter.AddCarPictures(car.Id, pic.Id);
            }
            foreach (Extra extra in car.CarExtras)
            {
                _dataWriter.AddCarExtras(car.Id, extra.Id);
            }
        }

        public void RemoveCar(Car car, Picture picture, Extra extra)
        {
            cars.Remove(car);
            _dataRemover.RemoveCar(car.Id, extra.Id, picture.Id);
        }

        public Car SearchForCar(int index)
        {
            return cars[index];
        }

        public List<Car> GetCars()
        {
            return cars;
        }

        public List<Car> GetCarsASC()
        {
            AscendingBrandComparer asc = new AscendingBrandComparer();
            cars.Sort(asc);
            return cars;
        }

        public List<Car> GetCarsDESC()
        {
            DescendingBrandComparer desc = new DescendingBrandComparer();
            cars.Sort(desc);
            return cars;
        }

        public Car GetCarById(int carId) 
        {
            foreach (Car car in cars) 
            {
                if (car.Id == carId)
                {
                    return car;
                }
            }
            return null;
        }

        public void LoadCars()
        {
            if (_dataAccess.GetCars() != null)
            {
                foreach (CarDTO carDTO in _dataAccess.GetCars())
                {
                    CarStatus status;
                    bool isValidArea = Enum.TryParse(carDTO.CarStatus.ToUpper(), true, out status);

                    if (isValidArea)
                    {
                        Car loadCar = new Car(carDTO.Id, carDTO.Brand, carDTO.Model, carDTO.FirstRegistration, carDTO.Mileage, carDTO.Fuel, carDTO.EngineSize, carDTO.HorsePower, carDTO.Gearbox, carDTO.Color, carDTO.VIN, carDTO.Description, carDTO.PricePerDay, status, carDTO.NumberOfSeats, carDTO.NumberOfDoors);
                        
                        foreach (ExtraDTO extraDTO in carDTO.CarExtras)
                        {
                            Extra extra = new Extra(extraDTO.extraName, extraDTO.Id);
                            loadCar.AddExtra(extra);
                        }
                        foreach (PictureDTO picDTO in carDTO.Pictures)
                        {
                            Picture pic = new Picture(picDTO.Id, picDTO.PictureURL);
                            loadCar.AddPicture(pic);
                        }
                        cars.Add(loadCar);
                    }
                    else
                    {
                        Console.WriteLine($"Warning: {carDTO.Id} has an invalid status assigned.");
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace Manager_Layer
{
    public class CarManager : ICarManager
    {
        private List<Car> cars;
        private readonly IDataAccess _dataAccess;
        private readonly ICarDataWriter _dataWriter;
        private readonly ICarDataRemover _dataRemover;

        public CarManager(IDataAccess dataAccess, ICarDataWriter dataWriter, ICarDataRemover dataRemover)
        {
            cars = new List<Car>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
        }

        public string AddCar(Car car, List<Picture> pictures, List<Extra> extras)
        {
            try
            {
                _dataWriter.AddCar(car.Brand, car.Model, car.FirstRegistration, car.Mileage, car.Fuel, car.EngineSize, car.HorsePower, car.Gearbox, car.NumberOfSeats, car.NumberOfDoors, car.Color, car.VIN, car.CarStatus.ToString());


                int CarId = _dataWriter.GetCarId(car.VIN);
                car.Id = CarId;
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
                cars.Add(car);
                return "done";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateCar(Car car, List<Picture> pictures, List<Extra> extras)
        {
            try
            {
                _dataWriter.UpdateCar(car);
                _dataWriter.UpdateCarDescription(car);
                _dataWriter.RemoveCarPictures(car.Id);
                _dataWriter.RemoveCarExtras(car.Id);
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
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string RemoveCar(Car car)
        {
            try
            {
                _dataRemover.RemoveCar(car.Id); ;
                cars.Remove(car);
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ChangeCarStatus(Car car, string newStatus, CarStatus Status)
        {
            try
            {
                _dataWriter.ChangeCarStatus(car, newStatus);
                car.CarStatus = Status;
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string RecordCarView(int carId)
        {
            try
            {
                _dataWriter.RecordCarView(carId);
                Car car = GetCarById(carId);
                car.Views = car.Views + 1;
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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

        public string LoadCars()
        {
            List<CarDTO> loadedCars;
            try
            {
                loadedCars = _dataAccess.GetCars();
                if (loadedCars != null)
                {
                    foreach (CarDTO carDTO in loadedCars)
                    {
                        CarStatus status;
                        bool isValidArea = Enum.TryParse(carDTO.CarStatus.ToUpper(), true, out status);

                        if (isValidArea)
                        {
                            Car loadCar = new Car(carDTO.Id, carDTO.Brand, carDTO.Model, carDTO.FirstRegistration, carDTO.Mileage, carDTO.Fuel, carDTO.EngineSize, carDTO.HorsePower, carDTO.Gearbox, carDTO.Color, carDTO.VIN, carDTO.Description, carDTO.PricePerDay, status, carDTO.NumberOfSeats, carDTO.NumberOfDoors, carDTO.Views);

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
                            return $"Warning: {carDTO.Id} has an invalid status assigned.";
                        }
                    }
                }
                return "done";
            }
            catch (ApplicationException ex)
            {
                return ex.Message;
            }

        }
    }
}

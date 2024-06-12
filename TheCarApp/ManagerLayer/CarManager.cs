using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ICarDataWriter _dataWriter;
        private readonly ICarDataRemover _dataRemover;

        public CarManager(IDataAccess dataAccess, ICarDataWriter dataWriter, ICarDataRemover dataRemover)
        {
            cars = new List<Car>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
        }

        public bool AddCar(Car car, List<Picture> pictures, List<Extra> extras, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataWriter.AddCar(car.Brand, car.Model, car.FirstRegistration, car.Mileage, car.Fuel, car.EngineSize, car.HorsePower, car.Gearbox, car.NumberOfSeats, car.NumberOfDoors, car.Color, car.VIN, car.CarStatus.ToString());

                int carId = _dataWriter.GetCarId(car.VIN);
                car.Id = carId;
                _dataWriter.AddCarDescription(car.Id, car.Description, car.PricePerDay);
                foreach (var pic in pictures)
                {
                    _dataWriter.AddCarPictures(car.Id, pic.Id);
                    car.AddPicture(pic);
                }
                foreach (var extra in extras)
                {
                    _dataWriter.AddCarExtras(car.Id, extra.Id);
                    car.AddExtra(extra);
                }
                cars.Add(car);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool UpdateCar(Car car, List<Picture> pictures, List<Extra> extras, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataWriter.UpdateCar(car);
                _dataWriter.UpdateCarDescription(car);
                _dataRemover.RemoveCarPictures(car.Id);
                _dataRemover.RemoveCarExtras(car.Id);
                foreach (var pic in pictures)
                {
                    _dataWriter.AddCarPictures(car.Id, pic.Id);
                    car.AddPicture(pic);
                }
                foreach (var extra in extras)
                {
                    _dataWriter.AddCarExtras(car.Id, extra.Id);
                    car.AddExtra(extra);
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool RemoveCar(Car car, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataRemover.RemoveCar(car.Id);
                cars.Remove(car);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool ChangeCarStatus(Car car, string newStatus, CarStatus status, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataWriter.ChangeCarStatus(car, newStatus);
                car.CarStatus = status;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool RecordCarView(int carId, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataWriter.RecordCarView(carId);
                var car = GetCarById(carId);
                if (car != null)
                {
                    car.Views++;
                    return true;
                }
                else
                {
                    errorMessage = "Car not found";
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public Car SearchForCar(int index)
        {
            return cars.ElementAtOrDefault(index);
        }

        public List<Car> GetCars()
        {
            return cars;
        }

        public List<Car> GetCarsASC()
        {
            var asc = new AscendingBrandComparer();
            cars.Sort(asc);
            return cars;
        }

        public List<Car> GetCarsDESC()
        {
            var desc = new DescendingBrandComparer();
            cars.Sort(desc);
            return cars;
        }

        public Car GetCarById(int carId)
        {
            return cars.FirstOrDefault(car => car.Id == carId);
        }

        public Car MapCarDtoToCar(CarDTO carDTO)
        {
            if (carDTO == null)
                throw new ArgumentNullException(nameof(carDTO));

            if (string.IsNullOrEmpty(carDTO.CarStatus))
                throw new ArgumentException("CarStatus cannot be null or empty", nameof(carDTO.CarStatus));

            CarStatus status;
            if (!Enum.TryParse<CarStatus>(carDTO.CarStatus, true, out status))
                throw new ArgumentException($"Invalid CarStatus value: {carDTO.CarStatus}");

            var car = new Car(carDTO.Id, carDTO.Brand, carDTO.Model, carDTO.FirstRegistration, carDTO.Mileage, carDTO.Fuel, carDTO.EngineSize, carDTO.HorsePower, carDTO.Gearbox, carDTO.Color, carDTO.VIN, carDTO.Description, carDTO.PricePerDay, status, carDTO.NumberOfSeats, carDTO.NumberOfDoors, carDTO.Views);

            foreach (var extraDTO in carDTO.CarExtras)
            {
                var extra = new Extra(extraDTO.extraName, extraDTO.Id);
                car.AddExtra(extra);
            }

            foreach (var picDTO in carDTO.Pictures)
            {
                var pic = new Picture(picDTO.Id, picDTO.PictureURL);
                car.AddPicture(pic);
            }

            return car;
        }

        public bool LoadCars(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var loadedCars = _dataAccess.GetCars();
                if (loadedCars != null)
                {
                    foreach (var carDTO in loadedCars)
                    {
                        if (Enum.TryParse(carDTO.CarStatus, true, out CarStatus status))
                        {
                            var loadCar = new Car(carDTO.Id, carDTO.Brand, carDTO.Model, carDTO.FirstRegistration, carDTO.Mileage, carDTO.Fuel, carDTO.EngineSize, carDTO.HorsePower, carDTO.Gearbox, carDTO.Color, carDTO.VIN, carDTO.Description, carDTO.PricePerDay, status, carDTO.NumberOfSeats, carDTO.NumberOfDoors, carDTO.Views);

                            foreach (var extraDTO in carDTO.CarExtras)
                            {
                                var extra = new Extra(extraDTO.extraName, extraDTO.Id);
                                loadCar.AddExtra(extra);
                            }
                            foreach (var picDTO in carDTO.Pictures)
                            {
                                var pic = new Picture(picDTO.Id, picDTO.PictureURL);
                                loadCar.AddPicture(pic);
                            }
                            cars.Add(loadCar);
                        }
                        else
                        {
                            errorMessage = $"Warning: {carDTO.Id} has an invalid status assigned.";
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}

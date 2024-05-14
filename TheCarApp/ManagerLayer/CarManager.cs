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
        private readonly IDataWriter _dataWriter;
        private readonly IDataRemover _dataRemover;

        public CarManager(IDataAccess dataAccess, IDataWriter dataWriter, IDataRemover dataRemover)
        {
            cars = new List<Car>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
        }

        public string AddCar(Car car, List<Picture> pictures, List<Extra> extras)
        {
            string Message = _dataWriter.AddCar(car.brand, car.Model, car.FirstRegistration, car.Mileage, car.Fuel, car.EngineSize, car.HorsePower, car.Gearbox, car.NumberOfSeats, car.NumberOfDoors, car.Color, car.VIN, car.CarStatus.ToString());
            if (Message == "done")
            {
                
                string SearchID = _dataWriter.GetCarId(car.VIN);
                int CarId;
                if (int.TryParse(SearchID, out CarId))
                {
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
                else
                {
                    return SearchID;
                }
            }
            else { return Message; }

            }

        public string UpdateCar(Car car, List<Picture> pictures, List<Extra> extras)
        {
            string MessageCar = _dataWriter.UpdateCar(car);
            if (MessageCar == "done")
            {
                string MessageCarDesc = _dataWriter.UpdateCarDescription(car);
                if (MessageCarDesc == "done")
                { 
                    string MessageRemovePics = _dataWriter.RemoveCarPictures(car.Id);
                    if (MessageRemovePics == "done")
                    { 
                        string MessageRemoveExtras = _dataWriter.RemoveCarExtras(car.Id);
                        if (MessageRemoveExtras == "done")
                        {
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
                        else { return MessageRemoveExtras; }
                    }
                    else { return MessageRemovePics; }
                }
                else { return MessageCarDesc; }
            }
            else { return MessageCar; }
        }

        public string RemoveCar(Car car)
        {


            string MessageCar = _dataRemover.RemoveCar(car.Id); ;
            if (MessageCar == "done")
            {
                cars.Remove(car);
                return "done";
            }
            else { return MessageCar; }
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

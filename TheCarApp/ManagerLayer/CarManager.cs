using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using DatabaseAccess;
using DTO.Enums;
using DTO.Interfaces;
using InterfaceLayer;
using DTO;
using AutoMapper;

namespace Manager_Layer
{
    public class CarManager : ICarManager
    {
        private List<CarDTO> cars;
        private readonly IDataAccess _dataAccess;
        private readonly ICarDataWriter _dataWriter;
        private readonly ICarDataRemover _dataRemover;
        private readonly IMapper _mapper;

        public CarManager(IMapper mapper, IDataAccess dataAccess, ICarDataWriter dataWriter, ICarDataRemover dataRemover)
        {
            cars = new List<CarDTO>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            _mapper = mapper;
        }

        // Adds a car and its related data (CarPictures, CarExtras) to the database
        public async Task<(bool Success, string ErrorMessage)> AddCarAsync(CarDTO carDTO)
        {
            try
            {
                Car car = _mapper.Map<Car>(carDTO);

                // Add the car entity
                await _dataWriter.AddCar(car);

                // Get the Car ID from the database using the VIN (if necessary)
                car.CarId = await _dataWriter.GetCarId(car.VIN);

                // Map the car entity to CarDTO
                cars.Add(carDTO);

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Updates the car and its related data
        public async Task<(bool Success, string ErrorMessage)> UpdateCarAsync(CarDTO carDTO)
        {
            try
            {
                Car car = _mapper.Map<Car>(carDTO);
                await _dataWriter.UpdateCar(car);

                // Map the car entity to CarDTO
                //var carDTO = cars.FirstOrDefault(c => c.Id == car.CarId);
                //if (carDTO != null)
                //{
                //    carDTO = _mapper.Map<CarDTO>(car);
                //}

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Removes a car
        public async Task<(bool Success, string ErrorMessage)> RemoveCarAsync(CarDTO carDTO)
        {
            try
            {
                Car car = _mapper.Map<Car>(carDTO);
                await _dataRemover.RemoveCarAsync(car.CarId);

                // Remove the corresponding DTO
                //var carDTO = cars.FirstOrDefault(c => c.Id == car.CarId);
                //if (carDTO != null)
                //{
                //    cars.Remove(carDTO);
                //}

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Changes the status of a car
        public async Task<(bool Success, string ErrorMessage)> ChangeCarStatusAsync(CarDTO carDTO, string newStatus, CarStatus status)
        {
            try
            {
                Car car = _mapper.Map<Car>(carDTO);
                await _dataWriter.ChangeCarStatus(car.CarId, newStatus);
                
                carDTO.Status = status.ToString();
                

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Records a car view
        public async Task<(bool Success, string ErrorMessage)> RecordCarViewAsync(int carId)
        {
            try
            {
                await _dataWriter.RecordCarView(carId);
                var car = GetCarById(carId);
                if (car != null)
                {
                    car.ViewCount++;
                    return (true, null); // Success
                }
                else
                {
                    return (false, "Car not found"); // Car not found
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Searches for a car by index
        public CarDTO SearchForCar(int index)
        {
            return cars.ElementAtOrDefault(index);
        }

        // Gets all cars
        public List<CarDTO> GetCars()
        {
            return cars;
        }

        // Gets cars sorted in ascending order by brand
        public List<CarDTO> GetCarsASC()
        {
            cars.Sort(new AscendingBrandComparer());
            return cars;
        }

        // Gets cars sorted in descending order by brand
        public List<CarDTO> GetCarsDESC()
        {
            cars.Sort(new DescendingBrandComparer());
            return cars;
        }

        // Gets a car by ID
        public CarDTO GetCarById(int carId)
        {
            return cars.FirstOrDefault(car => car.Id == carId);
        }

        // Loads cars from the database and adds them to the in-memory list
        public async Task<(bool Success, string ErrorMessage)> LoadCarsAsync()
        {
            try
            {
                var loadedCars = await _dataAccess.GetCarsAsync();
                if (loadedCars != null)
                {
                    // Map each car entity to CarDTO and add to the in-memory list
                    foreach (var carEntity in loadedCars)
                    {
                        CarDTO carDTO = _mapper.Map<CarDTO>(carEntity);
                        cars.Add(carDTO);
                    }
                }
                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }
    }
}

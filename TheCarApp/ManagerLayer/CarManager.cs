using Data.Models;
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

        public async Task<(bool Success, string ErrorMessage)> AddCarAsync(CarDTO carDTO)
        {
            try
            {
                Car car = _mapper.Map<Car>(carDTO);

                
                await _dataWriter.AddCar(car);

                
                car.CarId = await _dataWriter.GetCarId(car.VIN);

                
                cars.Add(carDTO);

                return (true, null); 
            }
            catch (Exception ex)
            {
                return (false, ex.Message); 
            }
        }

        public async Task<(bool Success, string ErrorMessage)> UpdateCarAsync(CarDTO carDTO)
        {
            try
            {
                Car car = _mapper.Map<Car>(carDTO);
                await _dataWriter.UpdateCar(car);


                return (true, null); 
            }
            catch (Exception ex)
            {
                return (false, ex.Message); 
            }
        }

        public async Task<(bool Success, string ErrorMessage)> RemoveCarAsync(CarDTO carDTO)
        {
            try
            {
                Car car = _mapper.Map<Car>(carDTO);
                await _dataRemover.RemoveCarAsync(car.CarId);


                return (true, null); 
            }
            catch (Exception ex)
            {
                return (false, ex.Message); 
            }
        }

        public async Task<(bool Success, string ErrorMessage)> ChangeCarStatusAsync(CarDTO carDTO, string newStatus, CarStatus status)
        {
            try
            {
                Car car = _mapper.Map<Car>(carDTO);
                await _dataWriter.ChangeCarStatus(car.CarId, newStatus);
                
                carDTO.Status = status.ToString();
                

                return (true, null); 
            }
            catch (Exception ex)
            {
                return (false, ex.Message); 
            }
        }

        public async Task<(bool Success, string ErrorMessage)> RecordCarViewAsync(int carId)
        {
            try
            {
                await _dataWriter.RecordCarView(carId);
                var car = GetCarById(carId);
                if (car != null)
                {
                    car.ViewCount++;
                    return (true, null); 
                }
                else
                {
                    return (false, "Car not found"); 
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public CarDTO SearchForCar(int index)
        {
            return cars.ElementAtOrDefault(index);
        }

        public List<CarDTO> GetCars()
        {
            return cars;
        }

        public List<CarDTO> GetCarsASC()
        {
            cars.Sort(new AscendingBrandComparer());
            return cars;
        }
        public List<CarDTO> GetCarsDESC()
        {
            cars.Sort(new DescendingBrandComparer());
            return cars;
        }

        public CarDTO GetCarById(int carId)
        {
            return cars.FirstOrDefault(car => car.Id == carId);
        }

        public async Task<(bool Success, string ErrorMessage)> LoadCarsAsync()
        {
            try
            {
                var loadedCars = await _dataAccess.GetCarsAsync();
                if (loadedCars != null)
                {
                    foreach (var carEntity in loadedCars)
                    {
                        CarDTO carDTO = _mapper.Map<CarDTO>(carEntity);
                        cars.Add(carDTO);
                    }
                }
                return (true, null); 
            }
            catch (Exception ex)
            {
                return (false, ex.Message); 
            }
        }
    }
}

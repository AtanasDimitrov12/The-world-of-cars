using DTO;
using DTO.Enums;

namespace InterfaceLayer
{
    public interface ICarManager
    {
        // Adds a car and its related data to the database
        Task<(bool Success, string ErrorMessage)> AddCarAsync(CarDTO carDTO);

        // Updates the car and its related data
        Task<(bool Success, string ErrorMessage)> UpdateCarAsync(CarDTO carDTO);

        // Removes a car
        Task<(bool Success, string ErrorMessage)> RemoveCarAsync(CarDTO carDTO);

        // Changes the status of a car
        Task<(bool Success, string ErrorMessage)> ChangeCarStatusAsync(CarDTO carDTO, string newStatus, CarStatus status);

        // Records a car view
        Task<(bool Success, string ErrorMessage)> RecordCarViewAsync(int carId);

        // Searches for a car by index
        CarDTO SearchForCar(int index);

        // Gets all cars
        List<CarDTO> GetCars();

        // Gets cars sorted in ascending order by brand
        List<CarDTO> GetCarsASC();

        // Gets cars sorted in descending order by brand
        List<CarDTO> GetCarsDESC();

        // Gets a car by ID
        CarDTO GetCarById(int carId);

        // Loads cars from the database and adds them to the in-memory list
        Task<(bool Success, string ErrorMessage)> LoadCarsAsync();
    }
}

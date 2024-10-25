using Data.Models;


namespace InterfaceLayer
{
    public interface IDataAccess
    {
        // Fetch all cars
        Task<List<Car>> GetCarsAsync();

        // Fetch all car extras
        Task<List<CarExtra>> GetAllExtrasAsync();
        Task<List<CarPicture>> GetAllPicturesAsync();

        // Fetch pictures for a car by car ID
        Task<List<CarPicture>> GetCarPicturesAsync(int carId);

        // Fetch a car by ID
        Task<Car> GetCarByIdAsync(int carId);

        // Fetch all car news
        Task<List<News>> GetCarNewsAsync();

        // Fetch comments for a specific news item by news ID
        Task<List<Comment>> GetCommentsForNewsAsync(int newsId);

        // Fetch all rentals
        Task<List<Rental>> GetRentalsAsync();

        // Fetch a user by ID
        Task<User> GetUserByIdAsync(int userId);

        // Fetch all users
        Task<List<User>> GetUsersAsync();

        // Fetch all administrators
        Task<List<Administrator>> GetAdministratorsAsync();
    }
}

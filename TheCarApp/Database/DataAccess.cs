using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data;
using InterfaceLayer;


namespace DatabaseAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly CarAppContext _context;

        public DataAccess(CarAppContext context)
        {
            _context = context;
        }

        // Fetch all cars with descriptions and views (if applicable)
        public async Task<List<Car>> GetCarsAsync()
        {
            try
            {
                return await _context.Cars
                    .Include(c => c.CarExtras)  // Include related CarExtras
                    .Include(c => c.CarPictures) // Include related CarPictures
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving cars: {ex.Message}");
                return new List<Car>();
            }
        }

        // Get all car extras
        public async Task<List<CarExtra>> GetAllExtrasAsync()
        {
            try
            {
                return await _context.CarExtras.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving extras: {ex.Message}");
                return new List<CarExtra>();
            }
        }

        public async Task<List<CarPicture>> GetAllPicturesAsync()
        {
            try
            {
                return await _context.CarPictures.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving extras: {ex.Message}");
                return new List<CarPicture>();
            }
        }

        // Fetch pictures for a car
        public async Task<List<CarPicture>> GetCarPicturesAsync(int carId)
        {
            try
            {
                return await _context.CarPictures
                    .Where(p => p.CarId == carId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving car pictures: {ex.Message}");
                return new List<CarPicture>();
            }
        }

        // Fetch car by ID
        public async Task<Car> GetCarByIdAsync(int carId)
        {
            try
            {
                return await _context.Cars
                    .Include(c => c.CarExtras) // Include related CarExtras
                    .Include(c => c.CarPictures) // Include related CarPictures
                    .FirstOrDefaultAsync(c => c.CarId == carId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving car by ID: {ex.Message}");
                return null;
            }
        }

        // Fetch all car news
        public async Task<List<News>> GetCarNewsAsync()
        {
            try
            {
                return await _context.News
                    .Include(n => n.Comments) // Include related comments
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving car news: {ex.Message}");
                return new List<News>();
            }
        }

        // Fetch comments for specific news
        public async Task<List<Comment>> GetCommentsForNewsAsync(int newsId)
        {
            try
            {
                return await _context.Comments
                    .Where(c => c.NewsId == newsId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving comments: {ex.Message}");
                return new List<Comment>();
            }
        }

        // Fetch all rentals
        public async Task<List<Rental>> GetRentalsAsync()
        {
            try
            {
                return await _context.Rentals.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving rentals: {ex.Message}");
                return new List<Rental>();
            }
        }

        // Fetch user by ID
        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving user: {ex.Message}");
                return null;
            }
        }

        // Fetch all users
        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await _context.Users
                    .Include(u => u.ProfilePictureFilePath) // Include profile pictures if needed
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<User>();
            }
        }

        // Fetch all administrators
        public async Task<List<Administrator>> GetAdministratorsAsync()
        {
            try
            {
                return await _context.Administrators.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving administrators: {ex.Message}");
                return new List<Administrator>();
            }
        }
    }
}

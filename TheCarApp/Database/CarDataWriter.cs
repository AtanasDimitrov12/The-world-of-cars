using Data.Models;
using InterfaceLayer;
using Data;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess
{
    public class CarDataWriter : ICarDataWriter
    {
        private readonly CarAppContext _context;

        public CarDataWriter(CarAppContext context)
        {
            _context = context;
        }

        public async Task AddCar(Car car)
        {
            try
            {
                // Add the car entity to the DbSet and save changes
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding a car: {ex.Message}");
            }
        }


        public async Task RecordCarView(int carId)
        {
            try
            {
                // Fetch the car from the database
                var car = await _context.Cars.FirstOrDefaultAsync(c => c.CarId == carId);

                if (car != null)
                {
                    // Increment the view count if the car exists
                    car.ViewCount++;

                    // Save changes to the database
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine($"Car with ID {carId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while recording car views: {ex.Message}");
            }
        }


        public async Task UpdateCar(Car car)
        {
            try
            {
                _context.Cars.Update(car); // Update the car entity in the DbSet
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the car: {ex.Message}");
            }
        }

        

        public async Task ChangeCarStatus(int carId, string status)
        {
            try
            {
                var car = await _context.Cars.FindAsync(carId);
                if (car != null)
                {
                    car.Status = status;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while changing car status: {ex.Message}");
            }
        }

        public async Task RemoveCarExtras(int carId)
        {
            try
            {
                var carExtras = _context.CarExtras.Where(ce => ce.CarId == carId);
                _context.CarExtras.RemoveRange(carExtras);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while removing car extras: {ex.Message}");
            }
        }

        public async Task RemoveCarPictures(int carId)
        {
            try
            {
                var carPictures = _context.CarPictures.Where(cp => cp.CarId == carId);
                _context.CarPictures.RemoveRange(carPictures);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while removing car pictures: {ex.Message}");
            }
        }

        public async Task<int> GetCarId(string vin)
        {
            try
            {
                var car = await _context.Cars.FirstOrDefaultAsync(c => c.VIN == vin);
                return car?.CarId ?? -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting car ID: {ex.Message}");
                return -1;
            }
        }

        public async Task AddExtra(string extraName)
        {
            try
            {
                var extra = new CarExtra
                {
                    ExtraName = extraName
                };
                _context.CarExtras.Add(extra);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding extra: {ex.Message}");
            }
        }

        public async Task AddPicture(string pictureUrl)
        {
            try
            {
                var picture = new CarPicture
                {
                    PictureURL = pictureUrl
                };
                _context.CarPictures.Add(picture);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding picture: {ex.Message}");
            }
        }

        public async Task<int> GetExtraId(string extraName)
        {
            try
            {
                var extra = await _context.CarExtras.FirstOrDefaultAsync(e => e.ExtraName == extraName);
                return extra?.CarExtraId ?? -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting extra ID: {ex.Message}");
                return -1;
            }
        }

        public async Task<int> GetPictureId(string pictureUrl)
        {
            try
            {
                var picture = await _context.CarPictures.FirstOrDefaultAsync(p => p.PictureURL == pictureUrl);
                return picture?.CarPictureId ?? -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting picture ID: {ex.Message}");
                return -1;
            }
        }
    }
}

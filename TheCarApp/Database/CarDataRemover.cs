using InterfaceLayer;
using Microsoft.EntityFrameworkCore;
using Data;

namespace DatabaseAccess
{
    public class CarDataRemover : ICarDataRemover
    {
        private readonly CarAppContext _context;

        public CarDataRemover(CarAppContext context)
        {
            _context = context;
        }

        public async Task RemoveCarAsync(int carId)
        {
            try
            {
                // Remove related data first
                await RemoveCarExtrasAsync(carId);
                await RemoveCarPicturesAsync(carId);

                // Now remove the car itself
                var car = await _context.Cars.FindAsync(carId);
                if (car != null)
                {
                    _context.Cars.Remove(car);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine($"Car with ID {carId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        

        public async Task RemoveCarExtrasAsync(int carId)
        {
            try
            {
                var carExtras = await _context.CarExtras
                    .Where(e => e.CarId == carId)
                    .ToListAsync();

                if (carExtras.Count > 0)
                {
                    _context.CarExtras.RemoveRange(carExtras);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task RemoveCarPicturesAsync(int carId)
        {
            try
            {
                var carPictures = await _context.CarPictures
                    .Where(p => p.CarId == carId)
                    .ToListAsync();

                if (carPictures.Count > 0)
                {
                    _context.CarPictures.RemoveRange(carPictures);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        


        public async Task RemoveExtraAsync(int extraId)
        {
            try
            {
                var extra = await _context.CarExtras.FindAsync(extraId);
                if (extra != null)
                {
                    _context.CarExtras.Remove(extra);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task RemovePictureAsync(int picId)
        {
            try
            {
                var picture = await _context.CarPictures.FindAsync(picId);
                if (picture != null)
                {
                    _context.CarPictures.Remove(picture);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

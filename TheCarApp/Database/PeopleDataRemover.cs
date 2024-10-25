using Data;
using Data.Models;
using InterfaceLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess
{
    public class PeopleDataRemover : IPeopleDataRemover
    {
        private readonly CarAppContext _context;

        public PeopleDataRemover(CarAppContext context)
        {
            _context = context;
        }

        // Removes a user by ID
        public async Task RemoveUserAsync(int userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Since profile pictures are now part of the User entity, this method will just clear the profile picture path and save the changes
        public async Task RemoveProfilePictureAsync(int userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user != null)
                {
                    user.ProfilePictureFilePath = null; // Remove the profile picture by clearing the path
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Removes an admin by ID
        public async Task RemoveAdminAsync(int adminId)
        {
            try
            {
                var admin = await _context.Administrators.FindAsync(adminId);
                if (admin != null)
                {
                    _context.Administrators.Remove(admin);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Removes a rental based on user ID, car ID, and start date
        public async Task RemoveRentalAsync(Rental rent)
        {
            try
            {
                var rental = await _context.Rentals
                    .FirstOrDefaultAsync(r => r.UserId == rent.User.UserId && r.CarId == rent.Car.CarId && r.StartDate == rent.StartDate);

                if (rental != null)
                {
                    _context.Rentals.Remove(rental);
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

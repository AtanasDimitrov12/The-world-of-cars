using System;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using InterfaceLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess
{
    public class PeopleDataWriter : IPeopleDataWriter
    {
        private readonly CarAppContext _context;

        public PeopleDataWriter(CarAppContext context)
        {
            _context = context;
        }

        // Adds a new user
        public async Task AddUserAsync(User newUser)
        {
            try
            {
                var user = new User
                {
                    Username = newUser.Username,
                    Email = newUser.Email,
                    PasswordHash = newUser.PasswordHash,
                    LicenseNumber = newUser.LicenseNumber,
                    ModifiedOn = newUser.ModifiedOn,
                    Salt = newUser.Salt,
                    ProfilePictureFilePath = newUser.ProfilePictureFilePath

                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Uploads a profile picture (updates User entity directly)
        public async Task UploadProfilePictureAsync(int userId, string relativeFilePath)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user != null)
                {
                    user.ProfilePictureFilePath = relativeFilePath;
                    user.ModifiedOn = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        // Adds a new administrator
        public async Task AddAdminAsync(Administrator adm)
        {
            try
            {
                var admin = new Administrator
                {
                    Username = adm.Username,
                    Email = adm.Email,
                    PasswordHash = adm.PasswordHash,
                    PhoneNumber = adm.PhoneNumber,
                    ModifiedOn = adm.ModifiedOn,
                    Salt = adm.Salt
                };

                _context.Administrators.Add(admin);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Updates an existing user
        public async Task UpdateUserAsync(User updatedUser)
        {
            try
            {
                var user = await _context.Users.FindAsync(updatedUser.UserId);
                if (user != null)
                {
                    user.Username = updatedUser.Username;
                    user.Email = updatedUser.Email;
                    user.PasswordHash = updatedUser.PasswordHash;
                    user.LicenseNumber = updatedUser.LicenseNumber;
                    user.ModifiedOn = updatedUser.ModifiedOn;
                    user.Salt = updatedUser.Salt;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Retrieves user ID by email
        public async Task<int> GetUserIdAsync(string email)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                return user?.UserId ?? -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1;
            }
        }

        // Updates an existing administrator
        public async Task UpdateAdminAsync(Administrator updatedAdm)
        {
            try
            {
                var admin = await _context.Administrators.FindAsync(updatedAdm);
                if (admin != null)
                {
                    admin.Username = updatedAdm.Username;
                    admin.Email = updatedAdm.Email;
                    admin.PasswordHash = updatedAdm.PasswordHash;
                    admin.PhoneNumber = updatedAdm.PhoneNumber;
                    admin.ModifiedOn = updatedAdm.ModifiedOn;
                    admin.Salt = updatedAdm.Salt;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Records a new rental
        public async Task RentACarAsync(Rental newRental)
        {
            try
            {
                var rental = new Rental
                {
                    UserId = newRental.UserId,
                    CarId = newRental.CarId,
                    StartDate = newRental.StartDate,
                    EndDate = newRental.EndDate,
                    Status = newRental.Status
                };

                _context.Rentals.Add(rental);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Updates an existing rental
        public async Task UpdateRentAsync(Rental rental)
        {
            try
            {
                var existingRental = await _context.Rentals
                    .FirstOrDefaultAsync(r => r.UserId == rental.User.UserId && r.CarId == rental.Car.CarId && r.StartDate == rental.StartDate);

                if (existingRental != null)
                {
                    existingRental.EndDate = rental.EndDate;
                    existingRental.Status = rental.Status.ToString();
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

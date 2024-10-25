using Data.Models;

namespace InterfaceLayer
{
    public interface IPeopleDataWriter
    {
        Task AddUserAsync(User user);
        Task UploadProfilePictureAsync(int userId, string relativeFilePath);
        Task AddAdminAsync(Administrator adm);
        Task UpdateUserAsync(User user);
        Task<int> GetUserIdAsync(string email);
        Task UpdateAdminAsync(Administrator adm);
        Task RentACarAsync(Rental rental);
        Task UpdateRentAsync(Rental rental);
    }
}

using Data.Models;

namespace InterfaceLayer
{
    public interface IPeopleDataRemover
    {
        Task RemoveUserAsync(int userId);
        Task RemoveProfilePictureAsync(int userId);  
        Task RemoveAdminAsync(int adminId);
        Task RemoveRentalAsync(Rental rent);
    }
}

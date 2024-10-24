using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace InterfaceLayer
{
    public interface IPeopleDataRemover
    {
        Task RemoveUserAsync(int userId);
        Task RemoveProfilePictureAsync(int userId);  // No separate UserProfilePicture entity now, so this just clears the fields
        Task RemoveAdminAsync(int adminId);
        Task RemoveRentalAsync(Rental rent);
    }
}

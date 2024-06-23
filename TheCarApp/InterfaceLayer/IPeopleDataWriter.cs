using Entity_Layer;
using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IPeopleDataWriter
    {
        void AddUser(string Username, string email, string password, int LicenseNumber, DateTime CreatedOn, string Salt);
        void UploadProfilePicture(int UserID, string relativeFilePath);
        int GetUserId(string Email);
        void AddAdmin(string Username, string email, string password, string PhoneNumber, DateTime CreatedOn, string PassSalt);
        void UpdateUser(int userId, string Username, string email, string password, string Salt, int licenseNumber, DateTime CreatedOn);
        void UpdateAdministration(int adminId, string username, string email, string passwordHash, string phoneNumber, DateTime createdOn, string PassSalt);
        void RentACar(int CarsId, int UserId, DateTime StartDate, DateTime EndDate, string Status);
        void UpdateRent(RentACar rental);
    }
}

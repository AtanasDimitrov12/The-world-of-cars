using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IPeopleDataWriter
    {
        string AddUser(string Username, string email, string password, int LicenseNumber, DateTime CreatedOn, string Salt);
        string AddAdmin(string Username, string email, string password, string PhoneNumber, DateTime CreatedOn);
        string UpdateUser(int userId, string Username, string email, string password, int licenseNumber, DateTime CreatedOn);
        string UpdateAdministration(int adminId, string username, string email, string passwordHash, string phoneNumber, DateTime createdOn);
        string RentACar(int CarsId, int UserId, DateTime StartDate, DateTime EndDate, string Status);
    }
}

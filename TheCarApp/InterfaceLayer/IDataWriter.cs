using Entity_Layer;
using EntityLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IDataWriter
    {
        int AddCar(string Brand, string Model, DateTime FirstRegistration, int Mileage, string Fuel, int EngineSize, int HP, string Gearbox, int NumOfSeats, string NumOfDoors, string color, string VIN, string Status);
        int AddCarDescription(int CarId, string Description, decimal Price);
        int AddCarExtras(int CarId, int ExtraId);
        int AddCarPictures(int CarId, int PictureId);
        int UpdateCar(Car car);
        int UpdateCarDescription(Car car);
        int RemoveCarExtras(int CarId);
        int RemoveCarPictures(int CarId);
        int AddCarNews(string Author, string Title, DateTime DatePosted, string NewsDescription, string ImageURL, string Intro);
        int AddComment(int NewsId, int UserId, DateTime CommentDate, string Content);
        int AddUser(string Username, string email, string password, int LicenseNumber, DateTime CreatedOn);
        int UpdateUser(int userId, string Username, string email, string password, int _licenseNumber, DateTime CreatedOn);
        int AddAdmin(string Username, string email, string password, string PhoneNumber, DateTime CreatedOn);
        int UpdateAdministration(int adminId, string username, string email, string passwordHash, string phoneNumber, DateTime createdOn);
        int AddExtra(string ExtraName);
        int AddPicture(string PictureURL);
        int GetCarId(string VIN);
        int GetExtraId(string VIN);
        int GetPictureId(string VIN);
        int GetNewsId(string Title);
        int GetCommentId(DateTime date);
    }
}

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
        string AddCar(string Brand, string Model, DateTime FirstRegistration, int Mileage, string Fuel, int EngineSize, int HP, string Gearbox, int NumOfSeats, string NumOfDoors, string color, string VIN, string Status);
        string AddCarDescription(int CarId, string Description, decimal Price);
        string AddCarExtras(int CarId, int ExtraId);
        string AddCarPictures(int CarId, int PictureId);
        string RecordCarView(int CarId);
        string UpdateCar(Car car);
        string UpdateCarDescription(Car car);
        string ChangeCarStatus(Car car, string Status);
        string RemoveCarExtras(int CarId);
        string RemoveCarPictures(int CarId);
        string AddCarNews(string Author, string Title, DateTime DatePosted, string NewsDescription, string ImageURL, string Intro);
        string UpdateNews(CarNews news);
        string AddComment(int NewsId, int UserId, DateTime CommentDate, string Content);
        string AddUser(string Username, string email, string password, int LicenseNumber, DateTime CreatedOn, string Salt);
        string UpdateUser(int userId, string Username, string email, string password, int _licenseNumber, DateTime CreatedOn);
        string AddAdmin(string Username, string email, string password, string PhoneNumber, DateTime CreatedOn);
        string UpdateAdministration(int adminId, string username, string email, string passwordHash, string phoneNumber, DateTime createdOn);
        string AddExtra(string ExtraName);
        string AddPicture(string PictureURL);
        string GetCarId(string VIN);
        string GetExtraId(string VIN);
        string GetPictureId(string VIN);
        string GetNewsId(string Title);
        string GetCommentId(DateTime date);
    }
}

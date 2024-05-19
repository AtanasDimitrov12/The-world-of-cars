using EntityLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ICarDataWriter
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
        string GetCarId(string VIN);
        string AddExtra(string ExtraName);
        string AddPicture(string PictureURL);
        string GetExtraId(string ExtraName);
        string GetPictureId(string PictureURL);
    }
}

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
        void AddCar(string Brand, string Model, DateTime FirstRegistration, int Mileage, string Fuel, int EngineSize, int HP, string Gearbox, int NumOfSeats, string NumOfDoors, string color, string VIN, string Status);
        void AddCarDescription(int CarId, string Description, decimal Price);
        void AddCarExtras(int CarId, int ExtraId);
        void AddCarPictures(int CarId, int PictureId);
        
        void RecordCarView(int CarId);
        void UpdateCar(Car car);
        void UpdateCarDescription(Car car);
        void ChangeCarStatus(Car car, string Status);
        void RemoveCarExtras(int CarId);
        void RemoveCarPictures(int CarId);
        int GetCarId(string VIN);
        void AddExtra(string ExtraName);
        void AddPicture(string PictureURL);
        int GetExtraId(string ExtraName);
        int GetPictureId(string PictureURL);
    }
}

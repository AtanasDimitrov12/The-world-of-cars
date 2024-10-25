using Data.Models;

namespace InterfaceLayer
{
    public interface ICarDataWriter
    {
        Task AddCar(Car car);
        Task RecordCarView(int carId);
        Task UpdateCar(Car car);
        Task ChangeCarStatus(int carId, string status);
        Task RemoveCarExtras(int carId);
        Task RemoveCarPictures(int carId);
        Task<int> GetCarId(string vin);
        Task AddExtra(string extraName);
        Task AddPicture(string pictureUrl);
        Task<int> GetExtraId(string extraName);
        Task<int> GetPictureId(string pictureUrl);
    }
}

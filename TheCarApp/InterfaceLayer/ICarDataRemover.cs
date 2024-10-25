
namespace InterfaceLayer
{
    public interface ICarDataRemover
    {
        Task RemoveCarAsync(int carId);
        Task RemoveCarExtrasAsync(int carId);
        Task RemoveCarPicturesAsync(int carId);
        Task RemoveExtraAsync(int extraId);
        Task RemovePictureAsync(int picId);
    }
}

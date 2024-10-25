using DTO;

namespace InterfaceLayer
{
    public interface IPictureManager
    {
        Task<(bool Success, string ErrorMessage)> AddPictureAsync(PictureDTO picDTO);
        Task<(bool Success, string ErrorMessage)> RemovePictureAsync(PictureDTO picDTO);
        Task<(bool Success, string ErrorMessage)> LoadPicturesAsync();
        Task<int> GetPicIdAsync(string URL);
        List<PictureDTO> Pictures { get; set; }
    }

}

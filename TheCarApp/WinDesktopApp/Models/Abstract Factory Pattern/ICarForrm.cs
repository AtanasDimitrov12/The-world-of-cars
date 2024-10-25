using DTO;

namespace WinDesktopApp.Models.Abstract_Factory_Pattern
{
    public interface ICarForm
    {
        void LoadCarData(CarDTO car);
        void LoadExtrasAndPictures(List<ExtraDTO> extras, List<PictureDTO> pictures);
        void DisableControls();
        void EnableControls();
        void ShowForm(); 
        event EventHandler AddCarClicked;
    }

}

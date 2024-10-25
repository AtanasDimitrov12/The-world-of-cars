using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace InterfaceLayer
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

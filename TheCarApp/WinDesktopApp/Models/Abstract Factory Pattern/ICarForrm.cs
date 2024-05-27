using Entity_Layer;
using EntityLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ICarForm
    {
        void LoadCarData(Car car);
        void LoadExtrasAndPictures(List<Extra> extras, List<Picture> pictures);
        void DisableControls();
        void EnableControls();
        void ShowForm(); 
        event EventHandler AddCarClicked;
    }

}

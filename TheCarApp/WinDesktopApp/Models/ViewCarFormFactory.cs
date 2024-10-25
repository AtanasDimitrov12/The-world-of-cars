using InterfaceLayer;
using DTO;
using WinDesktopApp.Models.Abstract_Factory_Pattern;

namespace WinDesktopApp.Models
{
    public class ViewCarFormFactory : ICarFormFactory
    {
        public ICarForm CreateCarForm(CarDTO car, ICarManager cm, IExtraManager em, IPictureManager picManager)
        {
            return new ViewCarForm(car, cm, em, picManager);
        }
    }
}

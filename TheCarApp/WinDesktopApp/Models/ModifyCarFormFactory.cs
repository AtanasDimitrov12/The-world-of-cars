using DTO;
using InterfaceLayer;
using WinDesktopApp.Models.Abstract_Factory_Pattern;

namespace WinDesktopApp.Models
{
    public class ModifyCarFormFactory : ICarFormFactory
    {
        public ICarForm CreateCarForm(CarDTO car, ICarManager cm, IExtraManager em, IPictureManager picManager)
        {
            return new ModifyCarForm(car, cm, em, picManager);
        }
    }
}

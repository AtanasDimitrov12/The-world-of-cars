using InterfaceLayer;
using DTO;
using WinDesktopApp.Models.Abstract_Factory_Pattern;

namespace WinDesktopApp.Models
{
    public class AddCarFormFactory : ICarFormFactory
    {
        public ICarForm CreateCarForm(CarDTO car, ICarManager cm, IExtraManager em, IPictureManager picManager)
        {
            return new AddCarForm(cm, em, picManager);
        }
    }
} 

using DTO;
using InterfaceLayer;

namespace WinDesktopApp.Models.Abstract_Factory_Pattern
{
    public interface ICarFormFactory
    {
        ICarForm CreateCarForm(CarDTO car, ICarManager cm, IExtraManager em, IPictureManager picManager);
    }

}

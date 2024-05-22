using EntityLayout;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDesktopApp.Models
{
    public class CarFormFactory : ICarFormFactory
    {
        private readonly ICarManager carManager;
        private readonly IExtraManager extraManager;
        private readonly IPictureManager pictureManager;

        public CarFormFactory(ICarManager carManager, IExtraManager extraManager, IPictureManager pictureManager)
        {
            this.carManager = carManager;
            this.extraManager = extraManager;
            this.pictureManager = pictureManager;
        }

        public ICarForm CreateViewForm(Car car)
        {
            return new ViewCarForm(car, carManager, extraManager, pictureManager);
        }

        public ICarForm CreateModifyForm(Car car)
        {
            return new ModifyCarForm(car, carManager, extraManager, pictureManager);
        }

        public ICarForm CreateAddForm()
        {
            return new AddCarForm(carManager, extraManager, pictureManager);
        }
    }

}

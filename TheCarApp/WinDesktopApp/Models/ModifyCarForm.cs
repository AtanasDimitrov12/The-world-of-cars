using DesktopApp;
using EntityLayout;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDesktopApp.Models
{
    public class ModifyCarForm : ICarForm
    {
        private Car car;
        private ICarManager carManager;
        private IExtraManager extraManager;
        private IPictureManager pictureManager;

        public ModifyCarForm(Car car, ICarManager carManager, IExtraManager extraManager, IPictureManager pictureManager)
        {
            this.car = car;
            this.carManager = carManager;
            this.extraManager = extraManager;
            this.pictureManager = pictureManager;
        }

        public event EventHandler CarActionCompleted;

        public void ShowForm()
        {
            AddCar addCar = new AddCar(car, carManager, extraManager, pictureManager, false);
            addCar.Show();
            addCar.CarAdded += (s, e) => CarActionCompleted?.Invoke(this, e);
        }
    }

}

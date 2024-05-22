using DesktopApp;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDesktopApp.Models
{
    public class AddCarForm : ICarForm
    {
        private ICarManager carManager;
        private IExtraManager extraManager;
        private IPictureManager pictureManager;

        public AddCarForm(ICarManager carManager, IExtraManager extraManager, IPictureManager pictureManager)
        {
            this.carManager = carManager;
            this.extraManager = extraManager;
            this.pictureManager = pictureManager;
        }

        public event EventHandler CarActionCompleted;

        public void ShowForm()
        {
            AddCar addCar = new AddCar(null, carManager, extraManager, pictureManager, false);
            addCar.Show();
            addCar.CarAdded += (s, e) => CarActionCompleted?.Invoke(this, e);
        }
    }

}

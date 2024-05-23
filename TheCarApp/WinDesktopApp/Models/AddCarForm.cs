using DesktopApp;
using Entity_Layer;
using EntityLayout;
using InterfaceLayer;
using Manager_Layer;
using ManagerLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDesktopApp.Models
{
    public class AddCarForm : ICarForm
    {
        private readonly AddCar _addCarForm;

        public AddCarForm(ICarManager cm, IExtraManager em, IPictureManager picManager)
        {
            _addCarForm = new AddCar(null, cm, em, picManager, false);
            _addCarForm.BTNAddCarGet.Click += OnAddCarClicked;
            EnableControls();
        }

        public void DisableControls() { /* Not needed for add form */ }

        public void EnableControls()
        {
            _addCarForm.BTNAddCarGet.Enabled = true;
            _addCarForm.BTNAddCarGet.Visible = true;
        }

        public event EventHandler CarActionCompleted;

        public void ShowForm()
        {
            AddCar addCar = _addCarForm as AddCar;
            addCar.Show();
            addCar.CarAdded += (s, e) => CarActionCompleted?.Invoke(this, e);
        }

        public void LoadCarData(Car car) { /* Not needed for add form */ }

        public void LoadExtrasAndPictures(List<Extra> extras, List<Picture> pictures) => _addCarForm.LoadCB();

        private void OnAddCarClicked(object sender, EventArgs e)
        {
            AddCarClicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler AddCarClicked;
    }

}

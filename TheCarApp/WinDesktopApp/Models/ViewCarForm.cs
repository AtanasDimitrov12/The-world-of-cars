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
    public class ViewCarForm : ICarForm
    {
        private readonly AddCar _addCarForm;

        public ViewCarForm(Car car, ICarManager cm, IExtraManager em, IPictureManager picManager)
        {
            _addCarForm = new AddCar(car, cm, em, picManager, true);
            _addCarForm.BTNAddCarGet.Click += OnAddCarClicked;
            DisableControls();
        }

        public void DisableControls()
        {
            _addCarForm.BTNAddCarGet.Enabled = false;
            _addCarForm.BTNAddCarGet.Visible = false;
            _addCarForm.BTNAddExtraGet.Enabled = false;
            _addCarForm.BTNAddExtraGet.Visible = false;
            _addCarForm.BTNAddPicturesGet.Enabled = false;
            _addCarForm.BTNAddPicturesGet.Visible = false;
            _addCarForm.BTNAddPictureGet.Enabled = false;
            _addCarForm.BTNAddPictureGet.Visible = false;
            _addCarForm.BTNAddExtrasGet.Enabled = false;
            _addCarForm.BTNAddExtrasGet.Visible = false;
            _addCarForm.BTNRemoveExtraGet.Enabled = false;
            _addCarForm.BTNRemoveExtraGet.Visible = false;
            _addCarForm.BTNRemovePictureGet.Enabled = false;
            _addCarForm.BTNRemovePictureGet.Visible = false;
        }

        public void EnableControls() { /* Not needed for view form */ }

        public event EventHandler CarActionCompleted;
        public void ShowForm()
        {
            AddCar addCar = _addCarForm as AddCar;
            addCar.Show();
            addCar.CarAdded += (s, e) => CarActionCompleted?.Invoke(this, e);
        }

        public void LoadCarData(Car car) => _addCarForm.LoadCarData();

        public void LoadExtrasAndPictures(List<Extra> extras, List<Picture> pictures) => _addCarForm.LoadCB();

        private void OnAddCarClicked(object sender, EventArgs e)
        {
            AddCarClicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler AddCarClicked;
    }


}

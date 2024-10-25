using InterfaceLayer;
using DTO;
using WinDesktopApp.Forms;
using WinDesktopApp.Models.Abstract_Factory_Pattern;

namespace WinDesktopApp.Models
{
    public class ModifyCarForm : ICarForm
    {
        private readonly AddCar _addCarForm;

        public ModifyCarForm(CarDTO car, ICarManager cm, IExtraManager em, IPictureManager picManager)
        {
            _addCarForm = new AddCar(car, cm, em, picManager, false);
            _addCarForm.BTNAddCarGet.Click += OnAddCarClicked;
            EnableControls();
            LoadCarData(car);
        }

        public void DisableControls() { }

        public void EnableControls()
        {
            _addCarForm.BTNAddCarGet.Enabled = true;
            _addCarForm.BTNAddCarGet.Visible = true;
            _addCarForm.BTNAddCarGet.Text = "Update Car";
        }

        public event EventHandler CarActionCompleted;
        public void ShowForm()
        {
            AddCar addCar = _addCarForm as AddCar;
            addCar.Show();
        }

        public void LoadCarData(CarDTO car) => _addCarForm.LoadCarData();

        public void LoadExtrasAndPictures(List<ExtraDTO> extras, List<PictureDTO> pictures) => _addCarForm.LoadCB();

        private void OnAddCarClicked(object sender, EventArgs e)
        {
            AddCarClicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler AddCarClicked;
    }
}
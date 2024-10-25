using DTO;
using InterfaceLayer;
using WinDesktopApp.Forms;
using WinDesktopApp.Models.Abstract_Factory_Pattern;

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

        public void DisableControls() { }

        public void EnableControls()
        {
            _addCarForm.BTNAddCarGet.Enabled = true;
            _addCarForm.BTNAddCarGet.Visible = true;
        }

        public void ShowForm()
        {
            AddCar addCar = _addCarForm as AddCar;
            addCar.Show();
        }

        public void LoadCarData(CarDTO car) { }

        public void LoadExtrasAndPictures(List<ExtraDTO> extras, List<PictureDTO> pictures) => _addCarForm.LoadCB();

        private void OnAddCarClicked(object sender, EventArgs e)
        {
            AddCarClicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler AddCarClicked;
    }

}

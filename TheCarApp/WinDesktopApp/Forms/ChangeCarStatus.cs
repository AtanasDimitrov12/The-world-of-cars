using DTO.Enums;
using DTO;
using InterfaceLayer;

namespace WinDesktopApp.Forms
{
    public partial class ChangeCarStatus : Form
    {
        CarDTO car;
        ICarManager manager;
        public event EventHandler StatusChanged;
        public ChangeCarStatus(CarDTO SelectedCar, ICarManager cm)
        {
            InitializeComponent();
            manager = cm;
            car = SelectedCar;
            DisplayInfo();
            foreach (var status in Enum.GetValues(typeof(CarStatus)))
            {
                string statusStr = status.ToString();
                string capitalizedStatus = char.ToUpper(statusStr[0]) + statusStr.Substring(1).ToLower();
                CBChangeStatus.Items.Add(capitalizedStatus);
            }

        }

        private void DisplayInfo()
        {
            TBBrand.Text = car.Brand;
            TBBrand.Enabled = false;
            TBModel.Text = car.Model;
            TBModel.Enabled = false;
            TBYear.Text = car.FirstRegistration.ToShortDateString();
            TBYear.Enabled = false;
            TBStatus.Text = car.Status.ToString().ToLower();
            TBStatus.Enabled = false;
        }

        private async void BTNUpdate_Click(object sender, EventArgs e)
        {
            CarStatus newStatus;
            if (Enum.TryParse<CarStatus>(CBChangeStatus.Text.ToUpper(), true, out newStatus))
            {

                (bool Response, string ErrorMessage) = await manager.ChangeCarStatusAsync(car, CBChangeStatus.Text.ToUpper(), newStatus);
                if (Response)
                {
                    Console.WriteLine("Car updated successfully.");
                    StatusChanged?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    Console.WriteLine($"Failed to update car: {ErrorMessage}");
                }

            }
        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

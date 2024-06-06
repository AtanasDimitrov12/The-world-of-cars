using EntityLayout;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Entity_Layer.Enums;

namespace WinDesktopApp.Forms
{
    public partial class ChangeCarStatus : Form
    {
        Car car;
        ICarManager manager;
        public event EventHandler StatusChanged;
        public ChangeCarStatus(Car SelectedCar, ICarManager cm)
        {
            InitializeComponent();
            manager = cm;
            car = SelectedCar;
            LBLBrand.Text = car.Brand;
            LBLModel.Text = car.Model;
            LBLYear.Text = car.FirstRegistration.ToShortDateString();
            LBLCurrentStatus.Text = car.CarStatus.ToString().ToLower();
            foreach (var status in Enum.GetValues(typeof(CarStatus)))
            {
                string statusStr = status.ToString();
                string capitalizedStatus = char.ToUpper(statusStr[0]) + statusStr.Substring(1).ToLower();
                CBChangeStatus.Items.Add(capitalizedStatus);
            }

        }

        private void BTNUpdate_Click(object sender, EventArgs e)
        {
            CarStatus newStatus;
            if (Enum.TryParse<CarStatus>(CBChangeStatus.Text.ToUpper(), true, out newStatus))
            { 
                manager.ChangeCarStatus(car, CBChangeStatus.Text.ToUpper(), newStatus);
                StatusChanged?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
    }
}

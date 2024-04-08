using Manager_Layer;
using EntityLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Entity_Layer.Enums;

namespace DesktopApp
{
    public partial class AddCar : Form
    {
        CarManager manager;
        public AddCar(CarManager cm)
        {
            InitializeComponent();
            manager = cm;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BTNAddCar_Click(object sender, EventArgs e)
        {

            Car car = new Car(TBCarBrand.Text, TBCarModel.Text, DTPCarFirstReg.Value, Convert.ToInt32(NUDCarMileage.Value), TBCarFuel.Text, Convert.ToInt32(NUDCarEngineSize.Value), Convert.ToInt32(NUDCarPower.Value), CBCarGearbox.SelectedItem.ToString(), TBCarColor.Text, TBCarVIN.Text, RTBCarDescription.Text, Convert.ToDecimal(TBCarPrice.Text), CarStatus.AVAILABLE, Convert.ToInt32(TBCarNumOfSeats.Text), TBCarNumOfDoors.Text);
            manager.AddCar();
            this.Close();
        }
    }
}

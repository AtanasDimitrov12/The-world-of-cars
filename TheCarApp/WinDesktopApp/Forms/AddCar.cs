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
using Entity_Layer;
using ManagerLayer;

namespace DesktopApp
{
    public partial class AddCar : Form
    {
        CarManager manager;
        PictureManager pictureManager;
        ExtraManager extraManager;
        List<Extra> extras;
        List<Picture> pictures;
        public AddCar(CarManager cm, ExtraManager em, PictureManager picmanager)
        {
            InitializeComponent();
            manager = cm;
            pictureManager = picmanager;
            extraManager = em;
            extras = new List<Extra>();
            pictures = new List<Picture>();
            LoadCB();
            this.extraManager = extraManager;
        }

        public void LoadCB()
        {
            foreach (Extra extra in extraManager.extras)
            { 
                CBCarExtras.Items.Add($"{extra.Id} - {extra.extraName}");
            }
            foreach (Picture pic in pictureManager.pictures)
            {
                CBPictureURL.Items.Add($"{pic.Id} - {pic.PictureURL}");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BTNAddCar_Click(object sender, EventArgs e)
        {
            try
            {
                Car car = new Car(TBCarBrand.Text, TBCarModel.Text, DTPCarFirstReg.Value, Convert.ToInt32(NUDCarMileage.Value), TBCarFuel.Text, Convert.ToInt32(NUDCarEngineSize.Value), Convert.ToInt32(NUDCarPower.Value), CBCarGearbox.SelectedItem.ToString(), TBCarColor.Text, TBCarVIN.Text, RTBCarDescription.Text, Convert.ToDecimal(TBCarPrice.Text), CarStatus.AVAILABLE, Convert.ToInt32(TBCarNumOfSeats.Text), TBCarNumOfDoors.Text);
                if (pictures.Count != 0 && extras.Count != 0)
                {
                    manager.AddCar(car, pictures, extras);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You should first add pictures and extras");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Type each data first " + ex.Message);
            }

            
        }

        private void BTNAddExtra_Click(object sender, EventArgs e)
        {
            int Index = CBCarExtras.SelectedIndex;
            extras.Add(extraManager.extras[Index]);

        }

        private void BTNRemoveExtra_Click(object sender, EventArgs e)
        {
            int Index = CBCarExtras.SelectedIndex;
            extras.Remove(extraManager.extras[Index]);
        }

        private void BTNAddPicture_Click(object sender, EventArgs e)
        {
            int Index = CBPictureURL.SelectedIndex;
            pictures.Add(pictureManager.pictures[Index]);
        }

        private void BTNRemovePicture_Click(object sender, EventArgs e)
        {
            int Index = CBPictureURL.SelectedIndex;
            pictures.Remove(pictureManager.pictures[Index]);
        }
    }
}

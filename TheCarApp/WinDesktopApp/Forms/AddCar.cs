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
using InterfaceLayer;

namespace DesktopApp
{
    public partial class AddCar : Form
    {
        ICarManager manager;
        IPictureManager pictureManager;
        IExtraManager extraManager;
        List<Extra> extras;
        List<Picture> pictures;
        bool Modify = false;
        Car carData;
        public AddCar(Car car, ICarManager cm, IExtraManager em, IPictureManager picManager)
        {
            InitializeComponent();
            manager = cm;
            pictureManager = picManager;
            extraManager = em;
            extras = new List<Extra>();
            pictures = new List<Picture>();
            LoadCB();
            carData = car;
            if (carData != null)
            {
                Modify = true;
                LoadCarData();
                BTNAddCar.Text = "Update Car";
            }

        }

        public void LoadCarData()
        {
            TBCarBrand.Text = carData.brand;
            TBCarModel.Text = carData.Model;
            DTPCarFirstReg.Value = carData.FirstRegistration;
            NUDCarMileage.Value = carData.Mileage;
            TBCarFuel.Text = carData.Fuel;
            NUDCarEngineSize.Value = carData.EngineSize;
            NUDCarPower.Value = carData.HorsePower;
            TBCarColor.Text = carData.Color;
            TBCarVIN.Text = carData.VIN;
            RTBCarDescription.Text = carData.Description;
            TBCarPrice.Text = carData.PricePerDay.ToString();
            TBCarNumOfSeats.Text = carData.NumberOfSeats.ToString();
            TBCarNumOfDoors.Text = carData.NumberOfDoors;

            foreach (var picture in carData.Pictures)
            {
                pictures.Add(picture);
            }

            foreach (var extra in carData.CarExtras)
            {
                extras.Add(extra);
            }
            AddToLB();
        }

        private void AddToLB()
        {
            LBExtras.Items.Clear();
            LBPictures.Items.Clear();
            foreach (var picture in pictures)
            {
                LBPictures.Items.Add($"{picture.Id} - {picture.PictureURL}");
            }

            foreach (var extra in extras)
            {
                LBExtras.Items.Add($"{extra.Id} - {extra.extraName}");
            }
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
                if (!Modify)
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
                else
                {
                    UpdateCarData();
                    manager.UpdateCar(carData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Type each data first " + ex.Message);
            }


        }

        private void UpdateCarData()
        {
            carData.brand = TBCarBrand.Text;
            carData.Model = TBCarModel.Text;
            carData.FirstRegistration = DTPCarFirstReg.Value; // Assuming this is correctly typed as a DateTime
            carData.Mileage = Convert.ToInt32(NUDCarMileage.Value);
            carData.Fuel = TBCarFuel.Text;
            carData.EngineSize = Convert.ToInt32(NUDCarEngineSize.Value);
            carData.HorsePower = Convert.ToInt32(NUDCarPower.Value);
            carData.Color = TBCarColor.Text;
            carData.VIN = TBCarVIN.Text;
            carData.Description = RTBCarDescription.Text;
            carData.PricePerDay = Convert.ToDecimal(TBCarPrice.Text);
            carData.NumberOfSeats = Convert.ToInt32(TBCarNumOfSeats.Text);
            carData.NumberOfDoors = TBCarNumOfDoors.Text;

        }

        private void BTNAddExtra_Click(object sender, EventArgs e)
        {
            int Index = CBCarExtras.SelectedIndex;
            foreach (var ex in extras)
            {
                if (ex != extraManager.extras[Index])
                {
                    extras.Add(extraManager.extras[Index]);
                }
                else 
                {
                    MessageBox.Show("This extra is already added to that car!");
                }
            }
            AddToLB();

        }

        private void BTNRemoveExtra_Click(object sender, EventArgs e)
        {
            int Index = CBCarExtras.SelectedIndex;
            extras.Remove(extraManager.extras[Index]);
            AddToLB();
        }

        private void BTNAddPicture_Click(object sender, EventArgs e)
        {
            int Index = CBPictureURL.SelectedIndex;
            foreach (var pic in pictures)
            {
                if (pic != pictureManager.pictures[Index])
                {
                    pictures.Add(pictureManager.pictures[Index]);
                }
                else
                {
                    MessageBox.Show("This picture is already added to that car!");
                }
            }
            AddToLB();
        }

        private void BTNRemovePicture_Click(object sender, EventArgs e)
        {
            int Index = CBPictureURL.SelectedIndex;
            pictures.Remove(pictureManager.pictures[Index]);
            AddToLB();
        }
    }
}

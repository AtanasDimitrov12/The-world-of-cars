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
using WinDesktopApp.Forms;

namespace DesktopApp
{
    public partial class AddCar : Form
    {
        ICarManager manager;
        IPictureManager pictureManager;
        IExtraManager extraManager;
        List<Extra> extras;
        List<Picture> pictures;
        bool Modify;
        bool IsView;
        Car carData;
        public event EventHandler CarAdded;
        public Button BTNAddCarGet { get; }
        public Button BTNAddExtraGet { get; }
        public Button BTNAddExtrasGet { get; }
        public Button BTNAddPictureGet { get; }
        public Button BTNAddPicturesGet { get; }
        public Button BTNRemovePictureGet { get; }
        public Button BTNRemoveExtraGet { get; }

        public AddCar(Car car, ICarManager cm, IExtraManager em, IPictureManager picManager, bool View)
        {
            InitializeComponent();
            manager = cm;
            pictureManager = picManager;
            extraManager = em;
            extras = new List<Extra>();
            pictures = new List<Picture>();
            IsView = View;
            Modify = false;
            LoadCB();
            carData = car;
            BTNAddCarGet = BTNAddCar;
            BTNAddExtraGet = BTNAddExtra;
            BTNAddExtrasGet = BTNAddExtras;
            BTNAddPictureGet = BTNAddPicture;
            BTNAddPicturesGet = BTNAddPics;
            BTNRemoveExtraGet = BTNRemoveExtra;
            BTNRemovePictureGet = BTNRemovePicture;
            foreach (var color in Enum.GetValues(typeof(Colors)))
            {
                string colorStr = color.ToString();
                string capitalizedColor = char.ToUpper(colorStr[0]) + colorStr.Substring(1).ToLower();
                CBColor.Items.Add(capitalizedColor);
            }

            if (carData != null)
            {
                Modify = true;
                LoadCarData();

            }
            if (IsView)
            {
                BTNAddCar.Visible = false;
                BTNClose.Location = new Point(510, 565);
                DisabledTextBoxes();
            }
            else
            {
                TBColor.Visible = false;
                TBGearbox.Visible = false;
            }
        }

        public void LoadCarData()
        {
            TBCarBrand.Text = carData.Brand;
            TBCarModel.Text = carData.Model;
            DTPCarFirstReg.Value = carData.FirstRegistration;
            NUDCarMileage.Value = carData.Mileage;
            TBCarFuel.Text = carData.Fuel;
            CBCarGearbox.Text = carData.Gearbox;
            NUDCarEngineSize.Value = carData.EngineSize;
            NUDCarPower.Value = carData.HorsePower;
            CBColor.Text = carData.Color;
            TBCarVIN.Text = carData.VIN;
            RTBCarDescription.Text = carData.Description;
            TBCarPrice.Text = carData.PricePerDay.ToString();
            TBCarNumOfSeats.Text = carData.NumberOfSeats.ToString();
            TBCarNumOfDoors.Text = carData.NumberOfDoors;

            pictures.Clear();
            extras.Clear();
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
                LBPictures.Items.Add($"{picture.PictureURL}");
            }

            foreach (var extra in extras)
            {
                LBExtras.Items.Add($"{extra.ExtraName}");
            }
        }

        public void LoadCB()
        {
            CBCarExtras.Items.Clear();
            CBPictureURL.Items.Clear();
            foreach (Extra extra in extraManager.extras)
            {
                CBCarExtras.Items.Add($"{extra.ExtraName}");
            }
            foreach (Picture pic in pictureManager.pictures)
            {
                CBPictureURL.Items.Add($"{pic.PictureURL}");
            }
        }

        private void BTNAddCar_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(TBCarBrand.Text) ||
                    string.IsNullOrEmpty(TBCarModel.Text) ||
                    string.IsNullOrEmpty(TBCarFuel.Text) ||
                    CBCarGearbox.SelectedItem == null ||
                    string.IsNullOrEmpty(CBColor.Text) ||
                    string.IsNullOrEmpty(TBCarVIN.Text) ||
                    string.IsNullOrEmpty(RTBCarDescription.Text) ||
                    string.IsNullOrEmpty(TBCarPrice.Text) ||
                    string.IsNullOrEmpty(TBCarNumOfSeats.Text) ||
                    string.IsNullOrEmpty(TBCarNumOfDoors.Text))
                {
                    MessageBox.Show("All fields must be filled in.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Modify)
                {
                    Car car = new Car(TBCarBrand.Text, TBCarModel.Text, DTPCarFirstReg.Value, Convert.ToInt32(NUDCarMileage.Value), TBCarFuel.Text, Convert.ToInt32(NUDCarEngineSize.Value), Convert.ToInt32(NUDCarPower.Value), CBCarGearbox.SelectedItem.ToString(), CBColor.SelectedItem.ToString(), TBCarVIN.Text, RTBCarDescription.Text, Convert.ToDecimal(TBCarPrice.Text), CarStatus.AVAILABLE, Convert.ToInt32(TBCarNumOfSeats.Text), TBCarNumOfDoors.Text, 0);
                    if (pictures.Count != 0)
                    {
                        if (manager.AddCar(car, pictures, extras, out string addCarError))
                        {
                            CarAdded?.Invoke(this, EventArgs.Empty);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to add car: {addCarError}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You should first add pictures!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    UpdateCarData();
                    if (manager.UpdateCar(carData, pictures, extras, out string updateCarError))
                    {
                        CarAdded?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update car: {updateCarError}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void UpdateCarData()
        {
            carData.Brand = TBCarBrand.Text;
            carData.Model = TBCarModel.Text;
            carData.FirstRegistration = DTPCarFirstReg.Value;
            carData.Mileage = Convert.ToInt32(NUDCarMileage.Value);
            carData.Fuel = TBCarFuel.Text;
            carData.Gearbox = CBCarGearbox.Text;
            carData.EngineSize = Convert.ToInt32(NUDCarEngineSize.Value);
            carData.HorsePower = Convert.ToInt32(NUDCarPower.Value);
            carData.Color = CBColor.Text;
            carData.VIN = TBCarVIN.Text;
            carData.Description = RTBCarDescription.Text;
            carData.PricePerDay = Convert.ToDecimal(TBCarPrice.Text);
            carData.NumberOfSeats = Convert.ToInt32(TBCarNumOfSeats.Text);
            carData.NumberOfDoors = TBCarNumOfDoors.Text;
        }

        private void BTNAddExtra_Click(object sender, EventArgs e)
        {
            if (CBCarExtras.Text != "")
            {
                int Index = CBCarExtras.SelectedIndex;
                if (extras.Count > 0)
                {
                    if (!extras.Contains(extraManager.extras[Index]))
                    {
                        extras.Add(extraManager.extras[Index]);
                    }
                    else
                    {
                        MessageBox.Show("This extra is already added to that car!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    extras.Add(extraManager.extras[Index]);
                }
                AddToLB();
            }
            else
            {
                MessageBox.Show("First, you need to choose an extra to add!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTNRemoveExtra_Click(object sender, EventArgs e)
        {
            string ExtraName = LBExtras.SelectedItem as string;
            if (ExtraName != null)
            {
                foreach (var ex in extraManager.extras)
                {
                    if (ex.ExtraName == ExtraName)
                    {
                        extras.Remove(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("No item is selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            AddToLB();
        }

        private void BTNAddPicture_Click(object sender, EventArgs e)
        {
            if (CBPictureURL.Text != "")
            {
                int Index = CBPictureURL.SelectedIndex;
                if (pictures.Count > 0)
                {
                    if (!pictures.Contains(pictureManager.pictures[Index]))
                    {
                        pictures.Add(pictureManager.pictures[Index]);
                    }
                    else
                    {
                        MessageBox.Show("This picture is already added to that car!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    pictures.Add(pictureManager.pictures[Index]);
                }
                AddToLB();
            }
            else
            {
                MessageBox.Show("First, you need to choose a picture to add!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTNRemovePicture_Click(object sender, EventArgs e)
        {
            string PicURL = LBPictures.SelectedItem as string;
            try
            {
                if (PicURL != null)
                {
                    foreach (var pic in pictureManager.pictures)
                    {
                        if (pic.PictureURL == PicURL)
                        {
                            pictures.Remove(pic);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No item is selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            AddToLB();
        }

        private void BTNAddExtras_Click(object sender, EventArgs e)
        {
            AddExtra addExtra = new AddExtra(extraManager);
            addExtra.ExtraAdded += AddExtra_ExtraAdded;
            addExtra.Show();
        }

        private void AddExtra_ExtraAdded(object sender, EventArgs e)
        {
            LoadCB();
        }

        private void BTNAddPics_Click(object sender, EventArgs e)
        {
            AddPicture addPicture = new AddPicture(pictureManager);
            addPicture.PicAdded += AddPic_PicAdded;
            addPicture.Show();
        }

        private void AddPic_PicAdded(object sender, EventArgs e)
        {
            LoadCB();
        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TBCarBrand_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 50;
            if (TBCarBrand.Text.Length > maxLength)
            {
                MessageBox.Show("Input is too long. Please enter a maximum of 50 characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBCarBrand.Text = TBCarBrand.Text.Substring(0, maxLength);
                TBCarBrand.SelectionStart = TBCarBrand.Text.Length;
            }
        }

        private void BTNClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisabledTextBoxes()
        {
            TBCarBrand.Enabled = false;
            TBCarModel.Enabled = false;
            TBCarFuel.Enabled = false;
            TBColor.Enabled = false;
            TBColor.Text = carData.Color;
            TBCarNumOfDoors.Enabled = false;
            TBCarNumOfSeats.Enabled = false;
            TBCarPrice.Enabled = false;
            TBCarVIN.Enabled = false;
            TBGearbox.Enabled = false;
            RTBCarDescription.Enabled = false;
            CBCarExtras.Visible = false;
            CBCarGearbox.Enabled = false;
            CBCarGearbox.Visible = false;
            CBPictureURL.Visible = false;
            TBGearbox.Text = carData.Gearbox;
            DTPCarFirstReg.Enabled = false;
            NUDCarEngineSize.Enabled = false;
            NUDCarMileage.Enabled = false;
            NUDCarPower.Enabled = false;
        }
    }
}

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
            TBCarBrand.MaxLength = 50;
            TBCarModel.MaxLength = 255;
            TBCarVIN.MaxLength = 255;

            TBCarBrand.TextChanged += ValidateTextLength;
            TBCarModel.TextChanged += ValidateTextLength;
            TBCarVIN.TextChanged += ValidateTextLength;
            LBExtras.Items.Clear();
            LBPictures.Items.Clear();
        }

        private void ValidateTextLength(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int maxLength = textBox.MaxLength;
                if (textBox.Text.Length > maxLength)
                {
                    MessageBox.Show($"Input is too long. Please enter a maximum of {maxLength} characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Text = textBox.Text.Substring(0, maxLength);
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
        }

        public void LoadCarData()
        {
            // Clear existing items to avoid duplication
            pictures.Clear();
            extras.Clear();
            LBExtras.Items.Clear();
            LBPictures.Items.Clear();

            TBCarBrand.Text = carData.Brand;
            TBCarModel.Text = carData.Model;
            DTPCarFirstReg.Value = carData.FirstRegistration;
            NUDCarMileage.Value = carData.Mileage;
            CBFuelType.Text = carData.Fuel;
            CBCarGearbox.Text = carData.Gearbox;
            NUDCarEngineSize.Value = carData.EngineSize;
            NUDCarPower.Value = carData.HorsePower;
            CBColor.Text = carData.Color;
            TBCarVIN.Text = carData.VIN;
            RTBCarDescription.Text = carData.Description;
            TBCarPrice.Text = carData.PricePerDay.ToString();
            NUDSeats.Value = carData.NumberOfSeats;
            CBDoors.Text = carData.NumberOfDoors;

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
                    CBFuelType.Text == "" ||
                    CBCarGearbox.Text == "" ||
                    CBColor.Text == "" ||
                    string.IsNullOrEmpty(TBCarVIN.Text) ||
                    string.IsNullOrEmpty(RTBCarDescription.Text) ||
                    string.IsNullOrEmpty(TBCarPrice.Text) ||
                    CBDoors.Text == "")
                {
                    MessageBox.Show("All fields must be filled in.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Modify)
                {
                    Car car = new Car(TBCarBrand.Text, TBCarModel.Text, DTPCarFirstReg.Value, Convert.ToInt32(NUDCarMileage.Value), CBFuelType.Text, Convert.ToInt32(NUDCarEngineSize.Value), Convert.ToInt32(NUDCarPower.Value), CBCarGearbox.SelectedItem.ToString(), CBColor.SelectedItem.ToString(), TBCarVIN.Text, RTBCarDescription.Text, Convert.ToDecimal(TBCarPrice.Text), CarStatus.AVAILABLE, Convert.ToInt32(NUDSeats.Value), CBDoors.Text, 0);
                    if (pictures.Count != 0)
                    {
                        if (manager.AddCar(car, pictures, extras, out string addCarError))
                        {
                            CarAdded?.Invoke(this, EventArgs.Empty);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to add car: {addCarError}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show($"You successfully updated that car!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            carData.Fuel = CBFuelType.Text;
            carData.Gearbox = CBCarGearbox.Text;
            carData.EngineSize = Convert.ToInt32(NUDCarEngineSize.Value);
            carData.HorsePower = Convert.ToInt32(NUDCarPower.Value);
            carData.Color = CBColor.Text;
            carData.VIN = TBCarVIN.Text;
            carData.Description = RTBCarDescription.Text;
            carData.PricePerDay = Convert.ToDecimal(TBCarPrice.Text);
            carData.NumberOfSeats = Convert.ToInt32(NUDSeats.Value);
            carData.NumberOfDoors = CBDoors.Text;
        }

        private void BTNAddExtra_Click(object sender, EventArgs e)
        {
            if (CBCarExtras.Text != "")
            {
                int index = CBCarExtras.SelectedIndex;
                Extra selectedExtra = extraManager.extras[index];

                if (extras.Any(ex => ex.ExtraName == selectedExtra.ExtraName))
                {
                    MessageBox.Show("This extra is already added to that car!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    extras.Add(selectedExtra);
                    AddToLB();
                }
            }
            else
            {
                MessageBox.Show("First, you need to choose an extra to add!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void BTNRemoveExtra_Click(object sender, EventArgs e)
        {
            string extraName = LBExtras.SelectedItem as string;
            if (extraName != null)
            {
                Extra extraToRemove = extras.FirstOrDefault(ex => ex.ExtraName == extraName);
                if (extraToRemove != null)
                {
                    extras.Remove(extraToRemove);
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
                int index = CBPictureURL.SelectedIndex;
                Picture selectedPicture = pictureManager.pictures[index];

                if (pictures.Any(pic => pic.PictureURL == selectedPicture.PictureURL))
                {
                    MessageBox.Show("This picture is already added to that car!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    pictures.Add(selectedPicture);
                    AddToLB();
                }
            }
            else
            {
                MessageBox.Show("First, you need to choose a picture to add!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void BTNRemovePicture_Click(object sender, EventArgs e)
        {
            string picURL = LBPictures.SelectedItem as string;
            if (picURL != null)
            {
                Picture pictureToRemove = pictures.FirstOrDefault(pic => pic.PictureURL == picURL);
                if (pictureToRemove != null)
                {
                    pictures.Remove(pictureToRemove);
                }
            }
            else
            {
                MessageBox.Show("No item is selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            CBFuelType.Enabled = false;
            TBColor.Enabled = false;
            TBColor.Text = carData.Color;
            CBDoors.Enabled = false;
            NUDSeats.Enabled = false;
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

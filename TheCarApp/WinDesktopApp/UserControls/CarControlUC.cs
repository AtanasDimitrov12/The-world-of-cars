using EntityLayout;
using Manager_Layer;
using ManagerLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinDesktopApp.Forms;
using InterfaceLayer;

namespace DesktopApp
{
    public partial class CarControlUC : UserControl
    {
        IPeopleManager peopleManager;
        ICarManager carManager;
        IExtraManager extraManager;
        IPictureManager pictureManager;
        public CarControlUC(IPeopleManager pm, ICarManager cm, IExtraManager em, IPictureManager picM)
        {
            InitializeComponent();
            this.peopleManager = pm;
            this.carManager = cm;
            this.extraManager = em;
            this.pictureManager = picM;
            DisplayCars(carManager.GetCars());
        }

        private void BTNAddCar_Click(object sender, EventArgs e)
        {
            AddCar addCar = new AddCar(null, carManager, extraManager, pictureManager);
            addCar.Show();
        }

        private void BTNModifyCar_Click(object sender, EventArgs e)
        {
            if (LBCars.SelectedItem != null)
            {
                try
                {
                    string CarInfo = LBCars.SelectedItem.ToString();
                    foreach (var selectedCar in carManager.GetCars())
                    {
                        if (selectedCar.GetInfo() == CarInfo)
                        {
                            AddCar addCar = new AddCar(selectedCar, carManager, extraManager, pictureManager);
                            addCar.Show();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else 
            {
                MessageBox.Show("Please first select a car to modify from the List box!");
            }
            
            
        }

        private void RBAsc_CheckedChanged(object sender, EventArgs e)
        {
            DisplayCars(carManager.GetCarsDESC());
        }

        private void RBDesc_CheckedChanged(object sender, EventArgs e)
        {
            DisplayCars(carManager.GetCarsASC());
        }

        public void DisplayCars(List<Car> sortedCars)
        {
            LBCars.Items.Clear();
            foreach (Car car in sortedCars)
            {
                LBCars.Items.Add(car.GetInfo());
            }
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            LBCars.Items.Clear();
            int year = int.Parse(TBSearchByYear.Text);
            var filteredCars = carManager.GetCars().Where(car => car.FirstRegistration.Year == year).ToList();
            foreach (var car in filteredCars)
            {
                LBCars.Items.Add(car.GetInfo());
            }
        }

        private void BTNAddExtras_Click(object sender, EventArgs e)
        {
            AddExtra addExtra = new AddExtra(extraManager);
            addExtra.Show();
        }

        private void BTNAddPics_Click(object sender, EventArgs e)
        {
            AddPicture addPicture = new AddPicture(pictureManager);
            addPicture.Show();
        }
    }
}

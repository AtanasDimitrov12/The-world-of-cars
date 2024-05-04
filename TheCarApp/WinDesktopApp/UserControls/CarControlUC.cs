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
            InitializeGridView();
            FillDataGridView(carManager.GetCars());
        }

        private void BTNAddCar_Click(object sender, EventArgs e)
        {
            AddCar addCar = new AddCar(null, carManager, extraManager, pictureManager);
            addCar.Show();
        }

        private void BTNModifyCar_Click(object sender, EventArgs e)
        {
            //if (LBCars.SelectedItem != null)
            //{
            //    try
            //    {
            //string CarInfo = LBCars.SelectedItem.ToString();
            //foreach (var selectedCar in carManager.GetCars())
            //{
            //    if (selectedCar.GetInfo() == CarInfo)
            //    {
            //        AddCar addCar = new AddCar(selectedCar, carManager, extraManager, pictureManager);
            //        addCar.Show();
            //    }
            //}
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please first select a car to modify from the List box!");
            //}


        }

        private void RBAsc_CheckedChanged(object sender, EventArgs e)
        {
            FillDataGridView(carManager.GetCarsDESC());
        }

        private void RBDesc_CheckedChanged(object sender, EventArgs e)
        {
            FillDataGridView(carManager.GetCarsASC());
        }


        private void InitializeGridView()
        {
            this.DGVCars.ColumnCount = 7;
            this.DGVCars.Columns[0].Name = "Brand";
            this.DGVCars.Columns[0].Width = 100;
            this.DGVCars.Columns[1].Name = "Model";
            this.DGVCars.Columns[1].Width = 100;
            this.DGVCars.Columns[2].Name = "Year";
            this.DGVCars.Columns[2].Width = 100;
            this.DGVCars.Columns[3].Name = "Horse Power";
            this.DGVCars.Columns[3].Width = 120;
            this.DGVCars.Columns[4].Name = "Gearbox";
            this.DGVCars.Columns[4].Width = 80;
            this.DGVCars.Columns[5].Name = "Fuel";
            this.DGVCars.Columns[5].Width = 80;
            this.DGVCars.Columns[6].Name = "VIN";
            this.DGVCars.Columns[6].Width = 180;

            var btnModify = new DataGridViewButtonColumn();
            btnModify.Name = "Modify";
            btnModify.HeaderText = "Modify";
            btnModify.Text = "Modify";

            btnModify.UseColumnTextForButtonValue = true;
            DGVCars.Columns.Add(btnModify);
        }

        private void FillDataGridView(List<Car> cars)
        {
            this.DGVCars.Rows.Clear();
            foreach (var car in cars)
            {
                this.DGVCars.Rows.Add(car.brand, car.Model, car.FirstRegistration, car.HorsePower, car.Gearbox, car.Fuel, car.VIN);
            }
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            int year = int.Parse(TBSearchByYear.Text);
            var filteredCars = carManager.GetCars().Where(car => car.FirstRegistration.Year == year).ToList();
            FillDataGridView(filteredCars);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on the 'Modify' button column
            if (e.ColumnIndex == DGVCars.Columns["Modify"].Index && e.RowIndex >= 0)
            {
                // Ensure that the row index is valid
                if (e.RowIndex != -1)
                {
                    // Extract car information from the clicked row
                    
                    var carVIN = DGVCars.Rows[e.RowIndex].Cells["VIN"].Value.ToString();

                    // Concatenate the car information to match the format expected by GetInfo()

                    // Loop through the cars managed by carManager to find the matching car
                    foreach (var selectedCar in carManager.GetCars())
                    {
                        if (selectedCar.VIN == carVIN)
                        {
                            // Assuming AddCar is a form that takes a car object and other managers as parameters
                            AddCar addCar = new AddCar(selectedCar, carManager, extraManager, pictureManager);
                            addCar.Show(); // Display the AddCar form
                            break; // Exit the loop after finding the matching car
                        }
                    }
                }
            }
        }

    }
}

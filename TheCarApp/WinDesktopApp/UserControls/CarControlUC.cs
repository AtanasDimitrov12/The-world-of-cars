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
            addCar.CarAdded += AddCar_CarAdded;
            addCar.Show();
        }

        private void AddCar_CarAdded(object sender, EventArgs e)
        {
            FillDataGridView(carManager.GetCars()); 
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
            this.DGVCars.ColumnCount = 8;
            this.DGVCars.Columns[0].Name = "Brand";
            this.DGVCars.Columns[0].Width = 100;
            this.DGVCars.Columns[1].Name = "Model";
            this.DGVCars.Columns[1].Width = 100;
            this.DGVCars.Columns[2].Name = "Year";
            this.DGVCars.Columns[2].Width = 100;
            this.DGVCars.Columns[3].Name = "Horse Power";
            this.DGVCars.Columns[3].Width = 120;
            this.DGVCars.Columns[4].Name = "Gearbox";
            this.DGVCars.Columns[4].Width = 100;
            this.DGVCars.Columns[5].Name = "Fuel";
            this.DGVCars.Columns[5].Width = 80;
            this.DGVCars.Columns[6].Name = "VIN";
            this.DGVCars.Columns[6].Width = 140;
            this.DGVCars.Columns[7].Name = "Status";
            this.DGVCars.Columns[7].Width = 100;

            var btnModify = new DataGridViewButtonColumn();
            btnModify.Name = "Modify";
            btnModify.HeaderText = "Modify";
            btnModify.Text = "Modify";

            btnModify.UseColumnTextForButtonValue = true;
            DGVCars.Columns.Add(btnModify);

            var btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Delete";
            btnDelete.HeaderText = "Delete";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            DGVCars.Columns.Add(btnDelete);

            var btnStatus = new DataGridViewButtonColumn();
            btnStatus.Name = "Change Status";
            btnStatus.HeaderText = "Change Status";
            btnStatus.Text = "Change Status";
            btnStatus.UseColumnTextForButtonValue = true;
            DGVCars.Columns.Add(btnStatus);
        }

        private void FillDataGridView(List<Car> cars)
        {
            this.DGVCars.Rows.Clear();
            foreach (var car in cars)
            {
                this.DGVCars.Rows.Add(car.Brand, car.Model, car.FirstRegistration.ToShortDateString(), car.HorsePower, car.Gearbox, car.Fuel, car.VIN, car.CarStatus);
            }
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            int year = int.Parse(TBSearchByYear.Text);
            var filteredCars = carManager.GetCars().Where(car => car.FirstRegistration.Year == year).ToList();
            FillDataGridView(filteredCars);
        }

        private void DGVCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVCars.Columns["Modify"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var carVIN = DGVCars.Rows[e.RowIndex].Cells["VIN"].Value.ToString();

                    foreach (var selectedCar in carManager.GetCars())
                    {
                        if (selectedCar.VIN == carVIN)
                        {
                            AddCar addCar = new AddCar(selectedCar, carManager, extraManager, pictureManager);
                            addCar.Show();
                            break;
                        }
                    }
                }
            }

            if (e.ColumnIndex == DGVCars.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var carVIN = DGVCars.Rows[e.RowIndex].Cells["VIN"].Value.ToString();

                    foreach (var selectedCar in carManager.GetCars())
                    {
                        if (selectedCar.VIN == carVIN)
                        {
                            carManager.RemoveCar(selectedCar);
                            FillDataGridView(carManager.GetCars());
                            break;
                        }
                    }
                }
            }

            if (e.ColumnIndex == DGVCars.Columns["Change Status"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var carVIN = DGVCars.Rows[e.RowIndex].Cells["VIN"].Value.ToString();

                    foreach (var selectedCar in carManager.GetCars())
                    {
                        if (selectedCar.VIN == carVIN)
                        {
                            ChangeCarStatus changeStatus = new ChangeCarStatus(selectedCar, carManager);
                            changeStatus.Show();
                            changeStatus.StatusChanged += ChangeCarStatus_StatusChanged;
                            break;
                        }
                    }
                }
            }

        }

        private void ChangeCarStatus_StatusChanged(object sender, EventArgs e)
        {
            FillDataGridView(carManager.GetCars());
        }
    }
}

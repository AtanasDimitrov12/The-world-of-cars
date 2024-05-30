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
using Entity_Layer;
using WinDesktopApp.Models;

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
            ICarFormFactory factory = new AddCarFormFactory();
            var addForm = factory.CreateCarForm(null, carManager, extraManager, pictureManager);
            addForm.AddCarClicked += AddCar_CarAdded;
            addForm.ShowForm();
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
            this.DGVCars.ColumnCount = 5;
            this.DGVCars.Columns[0].Name = "Brand";
            this.DGVCars.Columns[0].Width = 100;
            this.DGVCars.Columns[1].Name = "Model";
            this.DGVCars.Columns[1].Width = 100;
            this.DGVCars.Columns[2].Name = "Year";
            this.DGVCars.Columns[2].Width = 100;
            this.DGVCars.Columns[3].Name = "VIN";
            this.DGVCars.Columns[3].Width = 110;
            this.DGVCars.Columns[4].Name = "Status";
            this.DGVCars.Columns[4].Width = 100;
            

            

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
                this.DGVCars.Rows.Add(car.Brand, car.Model, car.FirstRegistration.ToShortDateString(), car.VIN, car.CarStatus);
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
            if (e.RowIndex >= 0)
            {
                var carVIN = DGVCars.Rows[e.RowIndex].Cells["VIN"].Value.ToString();
                var selectedCar = carManager.GetCars().FirstOrDefault(car => car.VIN == carVIN);

                if (selectedCar != null)
                {
                    ICarFormFactory factory = null;

                    if (e.ColumnIndex == DGVCars.Columns["View"].Index)
                    {
                        factory = new ViewCarFormFactory();
                    }
                    else if (e.ColumnIndex == DGVCars.Columns["Modify"].Index)
                    {
                        factory = new ModifyCarFormFactory();
                    }
                    else if (e.ColumnIndex == DGVCars.Columns["Delete"].Index)
                    {
                        carManager.RemoveCar(selectedCar);
                        FillDataGridView(carManager.GetCars());
                        return;
                    }
                    else if (e.ColumnIndex == DGVCars.Columns["Change Status"].Index)
                    {
                        ChangeCarStatus changeStatus = new ChangeCarStatus(selectedCar, carManager);
                        changeStatus.Show();
                        changeStatus.StatusChanged += ChangeCarStatus_StatusChanged;
                        return;
                    }

                    if (factory != null)
                    {
                        var carForm = factory.CreateCarForm(selectedCar, carManager, extraManager, pictureManager);
                        carForm.AddCarClicked += AddCar_CarAdded; 
                        carForm.ShowForm();
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

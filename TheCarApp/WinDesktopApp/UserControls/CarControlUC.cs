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
        private readonly ICarFormFactory formFactory;
        public CarControlUC(IPeopleManager pm, ICarManager cm, IExtraManager em, IPictureManager picM)
        {
            InitializeComponent();
            this.peopleManager = pm;
            this.carManager = cm;
            this.extraManager = em;
            this.pictureManager = picM;
            this.formFactory = new CarFormFactory(carManager, extraManager, pictureManager);
            InitializeGridView();
            FillDataGridView(carManager.GetCars());
        }

        private void BTNAddCar_Click(object sender, EventArgs e)
        {
            var addForm = formFactory.CreateAddForm();
            addForm.CarActionCompleted += AddCar_CarAdded;
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
            this.DGVCars.ColumnCount = 4;
            this.DGVCars.Columns[0].Name = "Brand";
            this.DGVCars.Columns[0].Width = 100;
            this.DGVCars.Columns[1].Name = "Model";
            this.DGVCars.Columns[1].Width = 100;
            this.DGVCars.Columns[2].Name = "VIN";
            this.DGVCars.Columns[2].Width = 110;
            this.DGVCars.Columns[3].Name = "Status";
            this.DGVCars.Columns[3].Width = 100;
            

            var btnView = new DataGridViewButtonColumn();
            btnView.Name = "View";
            btnView.HeaderText = "View";
            btnView.Text = "View";
            btnView.UseColumnTextForButtonValue = true;
            DGVCars.Columns.Add(btnView);

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
                this.DGVCars.Rows.Add(car.Brand, car.Model, car.VIN, car.CarStatus);
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
            if (e.RowIndex < 0) return;

            var carVIN = DGVCars.Rows[e.RowIndex].Cells["VIN"].Value.ToString();
            var car = carManager.GetCars().FirstOrDefault(c => c.VIN == carVIN);

            if (car == null) return;

            ICarForm form = null;

            if (e.ColumnIndex == DGVCars.Columns["View"].Index)
            {
                form = formFactory.CreateViewForm(car);
            }
            else if (e.ColumnIndex == DGVCars.Columns["Modify"].Index)
            {
                form = formFactory.CreateModifyForm(car);
            }
            else if (e.ColumnIndex == DGVCars.Columns["Delete"].Index)
            {
                carManager.RemoveCar(car);
                FillDataGridView(carManager.GetCars());
                return;
            }
            else if (e.ColumnIndex == DGVCars.Columns["Change Status"].Index)
            {
                var changeStatus = new ChangeCarStatus(car, carManager);
                changeStatus.Show();
                changeStatus.StatusChanged += ChangeCarStatus_StatusChanged;
                return;
            }

            if (form != null)
            {
                form.CarActionCompleted += (s, ev) => FillDataGridView(carManager.GetCars());
                form.ShowForm();
            }


        }

        private void ChangeCarStatus_StatusChanged(object sender, EventArgs e)
        {
            FillDataGridView(carManager.GetCars());
        }
    }
}

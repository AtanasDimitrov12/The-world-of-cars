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

namespace DesktopApp
{
    public partial class CarControlUC : UserControl
    {
        PeopleManager peopleManager;
        CarManager carManager;
        public CarControlUC(PeopleManager pm, CarManager cm)
        {
            InitializeComponent();
            this.peopleManager = pm;
            this.carManager = cm;
        }

        private void BTNAddCar_Click(object sender, EventArgs e)
        {
            AddCar addCar = new AddCar(carManager);
            addCar.Show();
        }

        private void BTNModifyCar_Click(object sender, EventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.Show();
        }

        private void RBAsc_CheckedChanged(object sender, EventArgs e)
        {
            LBCars.Items.Clear();
            foreach (Car car in carManager.GetCarsASC())
            {
                LBCars.Items.Add(car.GetInfo());
            }
        }

        private void RBDesc_CheckedChanged(object sender, EventArgs e)
        {
            LBCars.Items.Clear();
            foreach (Car car in carManager.GetCarsDESC())
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
    }
}

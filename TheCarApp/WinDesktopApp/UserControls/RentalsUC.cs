using Entity_Layer;
using InterfaceLayer;
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

namespace WinDesktopApp.UserControls
{
    public partial class RentalsUC : UserControl
    {
        IPeopleManager peopleManager;
        IRentManager rentManager;
        public RentalsUC(IPeopleManager pm, IRentManager rentManager)
        {
            InitializeComponent();
            peopleManager = pm;
            this.rentManager = rentManager;
            InitializeGridView();
            FillDataGridView();
        }

        private void InitializeGridView()
        {
            this.DGVRentals.ColumnCount = 6;
            this.DGVRentals.Columns[0].Name = "Username";
            this.DGVRentals.Columns[0].Width = 100;
            this.DGVRentals.Columns[1].Name = "Car";
            this.DGVRentals.Columns[1].Width = 100;
            this.DGVRentals.Columns[2].Name = "Start Date";
            this.DGVRentals.Columns[2].Width = 100;
            this.DGVRentals.Columns[3].Name = "End Date";
            this.DGVRentals.Columns[3].Width = 100;
            this.DGVRentals.Columns[4].Name = "Total Price";
            this.DGVRentals.Columns[4].Width = 50;
            this.DGVRentals.Columns[5].Name = "Status";
            this.DGVRentals.Columns[5].Width = 100;


            var btnRemove = new DataGridViewButtonColumn();
            btnRemove.Name = "Remove";
            btnRemove.HeaderText = "Remove";
            btnRemove.Text = "Remove";
            btnRemove.UseColumnTextForButtonValue = true;
            DGVRentals.Columns.Add(btnRemove);


        }

        private void FillDataGridView()
        {
            this.DGVRentals.Rows.Clear();

            foreach (var rent in rentManager.rentalHistory)
            {
                string Car = $"{rent.car.Brand} {rent.car.Model}";
                this.DGVRentals.Rows.Add(rent.user.Username, Car, rent.StartDate.ToShortDateString(), rent.ReturnDate.ToShortDateString(), rent.TotalPrice, rent.RentStatus);

            }
        }

        private void LBLAdminUsername_Click(object sender, EventArgs e)
        {

        }

        private void TBNewsTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNSearchByUsername_Click(object sender, EventArgs e)
        {

        }
    }
}

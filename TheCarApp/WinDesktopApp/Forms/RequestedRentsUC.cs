using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity_Layer.Enums;
using Entity_Layer.Interfaces;
using InterfaceLayer;
using Manager_Layer;

namespace WinDesktopApp.Forms
{
    public partial class RequestedRentsUC : Form
    {
        IRentManager rentManager;
        List<RentACar> rentals;
        public RequestedRentsUC(IRentManager rm)
        {
            InitializeComponent();
            rentManager = rm;
            rentals = rentManager.rentalHistory.Where(rent => rent.RentStatus == RentStatus.REQUESTED).ToList();
            InitializeGridView();
            FillDataGridView(rentals);
        }

        private void InitializeGridView()
        {
            this.DGVRequestRents.ColumnCount = 6;
            this.DGVRequestRents.Columns[0].Name = "Username";
            this.DGVRequestRents.Columns[0].Width = 100;
            this.DGVRequestRents.Columns[1].Name = "Car";
            this.DGVRequestRents.Columns[1].Width = 100;
            this.DGVRequestRents.Columns[2].Name = "Start Date";
            this.DGVRequestRents.Columns[2].Width = 100;
            this.DGVRequestRents.Columns[3].Name = "End Date";
            this.DGVRequestRents.Columns[3].Width = 100;
            this.DGVRequestRents.Columns[4].Name = "Total Price";
            this.DGVRequestRents.Columns[4].Width = 50;
            this.DGVRequestRents.Columns[5].Name = "Status";
            this.DGVRequestRents.Columns[5].Width = 100;


            var btnView = new DataGridViewButtonColumn();
            btnView.Name = "View";
            btnView.HeaderText = "View";
            btnView.Text = "View";
            btnView.UseColumnTextForButtonValue = true;
            DGVRequestRents.Columns.Add(btnView);

            var btnModify = new DataGridViewButtonColumn();
            btnModify.Name = "Modify";
            btnModify.HeaderText = "Modify";
            btnModify.Text = "Modify";
            btnModify.UseColumnTextForButtonValue = true;
            DGVRequestRents.Columns.Add(btnModify);

            var btnRemove = new DataGridViewButtonColumn();
            btnRemove.Name = "Remove";
            btnRemove.HeaderText = "Remove";
            btnRemove.Text = "Remove";
            btnRemove.UseColumnTextForButtonValue = true;
            DGVRequestRents.Columns.Add(btnRemove);


        }

        private void FillDataGridView(List<RentACar> rentals)
        {
            this.DGVRequestRents.Rows.Clear();

            foreach (var rent in rentals)
            {
                string Car = $"{rent.car.Brand} {rent.car.Model}";
                this.DGVRequestRents.Rows.Add(rent.user.Username, Car, rent.StartDate.ToShortDateString(), rent.ReturnDate.ToShortDateString(), rent.TotalPrice, rent.RentStatus);

            }
        }
    }
}

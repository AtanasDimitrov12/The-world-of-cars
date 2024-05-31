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
        public event EventHandler RentChanged;
        public RequestedRentsUC(IRentManager rm)
        {
            InitializeComponent();
            rentManager = rm;
            InitializeGridView();
            UpdateDGV();
        }

        private void UpdateDGV()
        {
            rentals = rentManager.rentalHistory.Where(rent => rent.RentStatus == RentStatus.REQUESTED).ToList();
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


            var btnApprove = new DataGridViewButtonColumn();
            btnApprove.Name = "Approve";
            btnApprove.HeaderText = "Approve";
            btnApprove.Text = "Approve";
            btnApprove.UseColumnTextForButtonValue = true;
            DGVRequestRents.Columns.Add(btnApprove);


            var btnCancel = new DataGridViewButtonColumn();
            btnCancel.Name = "Cancel";
            btnCancel.HeaderText = "Cancel";
            btnCancel.Text = "Cancel";
            btnCancel.UseColumnTextForButtonValue = true;
            DGVRequestRents.Columns.Add(btnCancel);


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



        private void DGVRequestRents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVRequestRents.Columns["Approve"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {

                    var Username = DGVRequestRents.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    var StartDateString = DGVRequestRents.Rows[e.RowIndex].Cells["Start Date"].Value.ToString();
                    var car = DGVRequestRents.Rows[e.RowIndex].Cells["Car"].Value.ToString();

                    foreach (var selectedRental in rentManager.rentalHistory)
                    {
                        if (selectedRental.user.Username == Username && selectedRental.StartDate.ToShortDateString() == StartDateString && $"{selectedRental.car.Brand} {selectedRental.car.Model}" == car)
                        {
                            rentManager.UpdateRentStatus(selectedRental, RentStatus.SCHEDULE);
                            RentChanged?.Invoke(this, EventArgs.Empty);
                            UpdateDGV();
                            break;
                        }
                    }
                }
            }

            if (e.ColumnIndex == DGVRequestRents.Columns["Cancel"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var Username = DGVRequestRents.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    var StartDateString = DGVRequestRents.Rows[e.RowIndex].Cells["Start Date"].Value.ToString();
                    var car = DGVRequestRents.Rows[e.RowIndex].Cells["Car"].Value.ToString();

                    foreach (var selectedRental in rentManager.rentalHistory)
                    {
                        if (selectedRental.user.Username == Username && selectedRental.StartDate.ToShortDateString() == StartDateString && $"{selectedRental.car.Brand} {selectedRental.car.Model}" == car)
                        {
                            rentManager.UpdateRentStatus(selectedRental, RentStatus.CANCELLED);
                            RentChanged?.Invoke(this, EventArgs.Empty);
                            UpdateDGV();
                            break;
                        }
                    }
                }
            }
        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

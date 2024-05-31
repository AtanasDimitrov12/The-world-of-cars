using DesktopApp;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinDesktopApp.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            FillDataGridView(rentManager.rentalHistory);
            UpdateRequestedLabel();
        }

        private void UpdateRequestedLabel()
        {
            int RequestedRentals = rentManager.rentalHistory.Where(r => r.RentStatus == Entity_Layer.Enums.RentStatus.REQUESTED).Count();
            LBLNumOfRentals.Text = RequestedRentals.ToString();
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

            var btnView = new DataGridViewButtonColumn();
            btnView.Name = "View";
            btnView.HeaderText = "View";
            btnView.Text = "View";
            btnView.UseColumnTextForButtonValue = true;
            DGVRentals.Columns.Add(btnView);

            var btnModify = new DataGridViewButtonColumn();
            btnModify.Name = "Modify";
            btnModify.HeaderText = "Modify";
            btnModify.Text = "Modify";
            btnModify.UseColumnTextForButtonValue = true;
            DGVRentals.Columns.Add(btnModify);

            var btnRemove = new DataGridViewButtonColumn();
            btnRemove.Name = "Remove";
            btnRemove.HeaderText = "Remove";
            btnRemove.Text = "Remove";
            btnRemove.UseColumnTextForButtonValue = true;
            DGVRentals.Columns.Add(btnRemove);

            
        }

        private void FillDataGridView(List<RentACar> rentals)
        {
            this.DGVRentals.Rows.Clear();

            foreach (var rent in rentals)
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
            string Username = TBUsername.Text;
            var filteredRentals = rentManager.rentalHistory
                .Where(rent => Regex.IsMatch(rent.user.Username, Regex.Escape(Username), RegexOptions.IgnoreCase))
                .ToList();
            FillDataGridView(filteredRentals);
        }

        private void RBASC_CheckedChanged(object sender, EventArgs e)
        {
            List<RentACar> rentals = rentManager.rentalHistory;
            rentals = rentals.OrderBy(r => r.StartDate).ToList();
            FillDataGridView(rentals);
        }

        private void RBDESC_CheckedChanged(object sender, EventArgs e)
        {
            List<RentACar> rentals = rentManager.rentalHistory;
            rentals = rentals.OrderByDescending(r => r.StartDate).ToList();
            FillDataGridView(rentals);
        }

        
        private void BTNCheckRentals_Click(object sender, EventArgs e)
        {
            RequestedRentsUC checkRentals = new RequestedRentsUC(rentManager);
            checkRentals.RentChanged += ChangeRent_RentChanged;
            checkRentals.Show();
        }

        private void ChangeRent_RentChanged(object sender, EventArgs e)
        {
            FillDataGridView(rentManager.rentalHistory);
            UpdateRequestedLabel();
        }

        private void DGVRentals_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVRentals.Columns["Modify"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {

                    var Username = DGVRentals.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    var StartDateString = DGVRentals.Rows[e.RowIndex].Cells["Start Date"].Value.ToString();
                    var car = DGVRentals.Rows[e.RowIndex].Cells["Car"].Value.ToString();

                    foreach (var selectedRental in rentManager.rentalHistory)
                    {
                        if (selectedRental.user.Username == Username && selectedRental.StartDate.ToShortDateString() == StartDateString && $"{selectedRental.car.Brand} {selectedRental.car.Model}" == car)
                        {
                            ViewRentals modifyRent = new ViewRentals(selectedRental, rentManager, false);
                            modifyRent.RentChanged += ChangeRent_RentChanged;
                            modifyRent.Show();
                            UpdateRequestedLabel();
                            break;
                        }
                    }
                }
            }

            if (e.ColumnIndex == DGVRentals.Columns["Remove"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var Username = DGVRentals.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    var StartDateString = DGVRentals.Rows[e.RowIndex].Cells["Start Date"].Value.ToString();
                    var car = DGVRentals.Rows[e.RowIndex].Cells["Car"].Value.ToString();

                    foreach (var selectedRental in rentManager.rentalHistory)
                    {
                        if (selectedRental.user.Username == Username && selectedRental.StartDate.ToShortDateString() == StartDateString && $"{selectedRental.car.Brand} {selectedRental.car.Model}" == car)
                        {
                            rentManager.RemoveRent(selectedRental);
                            FillDataGridView(rentManager.rentalHistory);
                            break;
                        }
                    }
                }
            }

            if (e.ColumnIndex == DGVRentals.Columns["View"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var Username = DGVRentals.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    var StartDateString = DGVRentals.Rows[e.RowIndex].Cells["Start Date"].Value.ToString();
                    var car = DGVRentals.Rows[e.RowIndex].Cells["Car"].Value.ToString();

                    foreach (var selectedRental in rentManager.rentalHistory)
                    {
                        if (selectedRental.user.Username == Username && selectedRental.StartDate.ToShortDateString() == StartDateString && $"{selectedRental.car.Brand} {selectedRental.car.Model}" == car)
                        {
                            ViewRentals viewRent = new ViewRentals(selectedRental, rentManager, true);
                            viewRent.Show();
                            break;
                        }
                    }
                }
            }
        }
    }
}

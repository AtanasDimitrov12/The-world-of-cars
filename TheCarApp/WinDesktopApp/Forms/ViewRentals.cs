using Entity_Layer.Enums;
using EntityLayout;
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

namespace WinDesktopApp.Forms
{
    public partial class ViewRentals : Form
    {
        RentACar rent;
        IRentManager manager;
        bool IsView;
        public event EventHandler RentChanged;
        public ViewRentals(RentACar rent, IRentManager rm, bool View)
        {
            InitializeComponent();
            this.rent = rent;
            manager = rm;
            IsView = View;
            DisplayRentInfo(rent, View);
            CheckForView();
        }

        public void CheckForView()
        {
            if (IsView)
            {
                BTNClose.Location = new Point(450, 294);
                BTNUpdate.Visible = false;
                BTNUpdate.Enabled = false;
            }
        }

        public void DisplayRentInfo(RentACar rent, bool View)
        {
            TBUsername.Text = rent.user.Username;
            TBCar.Text = $"{rent.car.Brand} {rent.car.Model}";
            DTPStartDate.Value = rent.StartDate;
            DTPEndDate.Value = rent.ReturnDate;
            TBTotalPrice.Text = rent.TotalPrice.ToString();
            TBCar.Enabled = false;
            TBUsername.Enabled = false;
            TBTotalPrice.Enabled = false;
            if (IsView)
            {
                TBRentStatus.Text = rent.RentStatus.ToString();
                CBRentStatus.Visible = false;
                CBRentStatus.Enabled = false;
                DTPStartDate.Enabled = false;
                DTPEndDate.Enabled = false;
                TBRentStatus.Enabled = false;
                BTNUpdate.Text = "Close";
            }
            else
            {
                foreach (var status in Enum.GetValues(typeof(RentStatus)))
                {
                    CBRentStatus.Items.Add(status.ToString().ToLower());
                }
                TBRentStatus.Enabled = false;
                TBRentStatus.Visible = false;
            }

        }

        private void BTNUpdate_Click(object sender, EventArgs e)
        {
            if (CBRentStatus.SelectedItem != null)
            {

                RentStatus newStatus;
                if (Enum.TryParse<RentStatus>(CBRentStatus.Text, true, out newStatus))
                {
                    rent.StartDate = DTPStartDate.Value;
                    rent.ReturnDate = DTPEndDate.Value;
                    rent.TotalPrice = manager.CalculatePrice(rent.user, rent.car.PricePerDay, DTPStartDate.Value, DTPEndDate.Value);
                    if (manager.UpdateRentStatus(rent, newStatus, out string ErrorMessage))
                    {
                        RentChanged?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(ErrorMessage);
                    }
                }

            }
            else
            {
                MessageBox.Show("Please first select Rent Status first!");
            }


        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DTPStartDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void DTPEndDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        public void CalculateTotalPrice()
        {
            if (DTPEndDate.Value <= DTPStartDate.Value)
            {
                MessageBox.Show("End date must be after start date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                TBTotalPrice.Text = manager.CalculatePrice(rent.user, rent.car.PricePerDay, DTPStartDate.Value, DTPEndDate.Value).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in OnPostCalculatePrice: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

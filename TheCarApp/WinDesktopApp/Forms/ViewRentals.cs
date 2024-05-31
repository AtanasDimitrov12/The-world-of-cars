using Entity_Layer.Enums;
using InterfaceLayer;
using Manager_Layer;
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
        }

        public void DisplayRentInfo(RentACar rent, bool View)
        {
            TBUsername.Text = rent.user.Username;
            TBCar.Text = $"{rent.car.Brand} {rent.car.Model}";
            DTPStartDate.Value = rent.StartDate;
            DTPEndDate.Value = rent.ReturnDate;
            TBTotalPrice.Text = rent.TotalPrice.ToString();
            if (IsView)
            {
                TBRentStatus.Text = rent.RentStatus.ToString();
                CBRentStatus.Visible = false;
                CBRentStatus.Enabled = false;
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
            if (IsView)
            {
                this.Close();
            }
            else
            {
                if (CBRentStatus.SelectedItem != null)
                {
                    if (rent.user.Username == TBUsername.Text && $"{rent.car.Brand} {rent.car.Model}" == TBCar.Text)
                    {
                        RentStatus newStatus;
                        if (Enum.TryParse<RentStatus>(CBRentStatus.Text, true, out newStatus))
                        {
                            rent.StartDate = DTPStartDate.Value;
                            rent.ReturnDate = DTPEndDate.Value;
                            rent.TotalPrice = manager.CalculatePrice(rent.car.PricePerDay, DTPStartDate.Value, DTPEndDate.Value);
                            manager.UpdateRentStatus(rent, newStatus);
                            RentChanged?.Invoke(this, EventArgs.Empty);
                            this.Close();
                        }
                    }
                    else 
                    {
                        MessageBox.Show("User and car information cannot be changed!");
                    }
                }
                else
                {
                    MessageBox.Show("Please first select Rent Status first!");
                }

            }
        }
    }
}

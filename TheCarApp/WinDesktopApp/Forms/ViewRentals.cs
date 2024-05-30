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
                manager.UpdateRental(rent);
            }
        }
    }
}

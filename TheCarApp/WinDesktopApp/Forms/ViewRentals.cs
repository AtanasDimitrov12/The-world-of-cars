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
        public ViewRentals(RentACar rent, IRentManager rm, bool View)
        {
            InitializeComponent();
            this.rent = rent;
            manager = rm;
            DisplayRentInfo(rent, View);
        }

        public void DisplayRentInfo(RentACar rent, bool View)
        {
            TBUsername.Text = rent.user.Username;
            TBCar.Text = $"{rent.car.Brand} {rent.car.Model}";
            DTPStartDate.Value = rent.StartDate;
            DTPEndDate.Value = rent.ReturnDate;
            TBTotalPrice.Text = rent.TotalPrice.ToString();
            if (View)
            {
                TBRentStatus.Text = rent.RentStatus.ToString();
                CBRentStatus.Visible = false;
                CBRentStatus.Enabled = false;
            }
            else 
            {
                TBRentStatus.Enabled = false;
                TBRentStatus.Visible = false;
            }
            
        }
    }
}

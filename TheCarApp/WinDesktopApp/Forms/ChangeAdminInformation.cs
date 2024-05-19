using Entity_Layer;
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
    public partial class ChangeAdminInformation : Form
    {
        Administrator Admin;
        public ChangeAdminInformation(Administrator adm)
        {
            InitializeComponent();
            Admin = adm;
            DisplayAdminInfo();
        }

        public void DisplayAdminInfo()
        {
            TBAdminEmail.Text = Admin.Email;
            TBAdminPassword.Text = Admin.Password;
            TBAdminUsername.Text = Admin.Username;
            TBAdminPhoneNumber.Text = Admin.PhoneNumber;
        }
        private void BTNUpdateAdminInfo_Click(object sender, EventArgs e)
        {

        }
    }
}

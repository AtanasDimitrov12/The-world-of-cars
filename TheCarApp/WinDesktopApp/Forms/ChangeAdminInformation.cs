using Entity_Layer;
using InterfaceLayer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinDesktopApp.Forms
{
    public partial class ChangeAdminInformation : Form
    {
        Administrator Admin;
        IPeopleManager Manager;
        public ChangeAdminInformation(Administrator adm, IPeopleManager pm)
        {
            InitializeComponent();
            Admin = adm;
            Manager = pm;
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
            CheckValidity(TBAdminEmail.Text, TBAdminPassword.Text, TBAdminUsername.Text, TBAdminPhoneNumber.Text);
        }

        public void CheckValidity(string email, string password, string username, string phoneNumber)
        {
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address (e.g., example@example.com).");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password should be at least 8 characters long.");
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.");
                return;
            }

            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Please enter a valid phone number (only digits are allowed).");
                return;
            }


        }

        private bool IsValidEmail(string email)
        {
            // Use a regular expression to validate the email format
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Check if the phone number contains only digits
            return phoneNumber.All(char.IsDigit);
        }
    }
}

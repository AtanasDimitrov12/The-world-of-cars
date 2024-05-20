using Entity_Layer;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
        public event EventHandler InfoChanged;
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
            //TBAdminPassword.Text = Admin.Password;
            TBAdminUsername.Text = Admin.Username;
            TBAdminPhoneNumber.Text = Admin.PhoneNumber;
        }
        private void BTNUpdateAdminInfo_Click(object sender, EventArgs e)
        {
            //CheckValidity(TBAdminEmail.Text, TBAdminPassword.Text, TBAdminUsername.Text, TBAdminPhoneNumber.Text);
            //Manager.RemovePerson(Admin);
            //DateTime dateTime = DateTime.Now;

            //Administrator adm = new Administrator(2, TBAdminEmail.Text, TBAdminPassword.Text, TBAdminUsername.Text, dateTime, TBAdminPhoneNumber.Text, "");
            //adm.CreatedOn = dateTime;
            //Manager.AddPerson(adm);

            if(TBAdminPassword.Text != "")
            {


                if (CheckValidity(TBAdminEmail.Text, TBAdminPassword.Text, TBAdminUsername.Text, TBAdminPhoneNumber.Text))
                {
                    Admin.Email = TBAdminEmail.Text;
                    Admin.Password = TBAdminPassword.Text;
                    Admin.Username = TBAdminUsername.Text;
                    Admin.PhoneNumber = TBAdminPhoneNumber.Text;
                    string hash;
                    string salt;
                    (hash, salt) = Manager.HashPassword(Admin.Password);
                    Admin.Password = hash;
                    Admin.PassSalt = salt;
                    string message = Manager.UpdatePerson(Admin);
                    if (message == "done")
                    {
                        InfoChanged?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(message);
                    }
                }

                
            }

            else
            {
                if (CheckValidity(TBAdminEmail.Text, Admin.Password, TBAdminUsername.Text, TBAdminPhoneNumber.Text))
                {
                    Admin.Email = TBAdminEmail.Text;
                    Admin.Username = TBAdminUsername.Text;
                    Admin.PhoneNumber = TBAdminPhoneNumber.Text;
                    string message = Manager.UpdatePerson(Admin);
                    if (message == "done")
                    {
                        InfoChanged?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(message);
                    }
                }
            }

        }

        public bool CheckValidity(string email, string password, string username, string phoneNumber)
        {
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address (e.g., example@example.com).");
                return false;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password should be at least 8 characters long.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.");
                return false;
            }

            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Please enter a valid phone number (only digits are allowed).");
                return false;
            }

            return true;


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

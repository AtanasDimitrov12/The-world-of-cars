using InterfaceLayer;
using System.Text.RegularExpressions;
using DTO;

namespace WinDesktopApp.Forms
{
    public partial class ChangeAdminInformation : Form
    {
        AdministratorDTO Admin;
        IPeopleManager Manager;
        public event EventHandler InfoChanged;

        private string initialEmail;
        private string initialUsername;
        private string initialPhoneNumber;
        private string initialPassword;
        public ChangeAdminInformation(AdministratorDTO adm, IPeopleManager pm)
        {
            InitializeComponent();
            Admin = adm;
            Manager = pm;
            DisplayAdminInfo();

            initialEmail = Admin.Email;
            initialUsername = Admin.Username;
            initialPhoneNumber = Admin.PhoneNumber;
            initialPassword = "";

            TBAdminEmail.TextChanged += AdminInfoChanged;
            TBAdminUsername.TextChanged += AdminInfoChanged;
            TBAdminPhoneNumber.TextChanged += AdminInfoChanged;
            TBAdminPassword.TextChanged += AdminInfoChanged;

            BTNUpdateAdminInfo.Enabled = false;
        }
        private void AdminInfoChanged(object sender, EventArgs e)
        {
            BTNUpdateAdminInfo.Enabled = HasAdminInfoChanged();
        }
        private bool HasAdminInfoChanged()
        {
            return TBAdminEmail.Text != initialEmail ||
                   TBAdminUsername.Text != initialUsername ||
                   TBAdminPhoneNumber.Text != initialPhoneNumber ||
                   TBAdminPassword.Text != initialPassword;
        }

        public void DisplayAdminInfo()
        {
            TBAdminEmail.Text = Admin.Email;
            TBAdminUsername.Text = Admin.Username;
            TBAdminPhoneNumber.Text = Admin.PhoneNumber;
        }


        private async void BTNUpdateAdminInfo_Click(object sender, EventArgs e)
        {
            if (TBAdminPassword.Text != "")
            {
                if (CheckValidity(TBAdminEmail.Text, TBAdminPassword.Text, TBAdminUsername.Text, TBAdminPhoneNumber.Text))
                {
                    Admin.Email = TBAdminEmail.Text;
                    Admin.PasswordHash = TBAdminPassword.Text;
                    Admin.Username = TBAdminUsername.Text;
                    Admin.PhoneNumber = TBAdminPhoneNumber.Text;

                    (bool result, string ErrorMessage) = await Manager.UpdatePersonAsync(Admin);

                    if (result)
                    {
                        InfoChanged?.Invoke(this, EventArgs.Empty);
                        MessageBox.Show("You successfully update the admin's information!");
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
                if (CheckValidity(TBAdminEmail.Text, Admin.PasswordHash, TBAdminUsername.Text, TBAdminPhoneNumber.Text))
                {
                    Admin.Email = TBAdminEmail.Text;
                    Admin.Username = TBAdminUsername.Text;
                    Admin.PhoneNumber = TBAdminPhoneNumber.Text;

                    (bool result, string ErrorMessage) = await Manager.UpdatePersonAsync(Admin);

                    if (result)
                    {
                        InfoChanged?.Invoke(this, EventArgs.Empty);
                        MessageBox.Show("You successfully update the admin's information!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(ErrorMessage);
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
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit);
        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

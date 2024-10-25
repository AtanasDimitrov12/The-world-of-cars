using InterfaceLayer;
using DTO;

namespace WinDesktopApp.Forms
{
    public partial class AdminVerification : Form
    {
        ChangeAdminInformation ChangeAdmInfo;
        AdministratorDTO Admin;
        IPeopleManager Manager;
        public AdminVerification(ChangeAdminInformation ChangeInfo, AdministratorDTO administrator, IPeopleManager pm)
        {
            InitializeComponent();
            this.ChangeAdmInfo = ChangeInfo;
            this.Admin = administrator;
            Manager = pm;
            TBAdminPass.PasswordChar = '*';
        }

        private void BTNCheckPass_Click(object sender, EventArgs e)
        {
            if (Manager.AuthenticateUser(Admin.Email, TBAdminPass.Text, out string ErrorMessage))
            {
                ChangeAdmInfo.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Entered password is different from the stored one! Try again.");
                TBAdminPass.Clear();
            }
        }
    }
}

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
using Entity_Layer;
using InterfaceLayer;
using WinDesktopApp.Forms;

namespace DesktopApp
{
    public partial class AdminInfoUC : UserControl
    {
        IPeopleManager manager;
        IAdministratorRepository administratorRepository;
        List<Administrator> admins;
        public AdminInfoUC(IPeopleManager pm, IAdministratorRepository administratorRepository)
        {
            InitializeComponent();
            manager = pm;
            this.administratorRepository = administratorRepository;
            admins = administratorRepository.GetAllAdministrators();
            DisplayAdminInfo();
        }

        public void DisplayAdminInfo()
        { 
            LBLAdminEmail.Text = admins[0].Email;
            LBLAdminUsername.Text = admins[0].Username;
            LBLAdminPhoneNumber.Text = admins[0].PhoneNumber;
        }
        private void BTNChangeAdminInfo_Click(object sender, EventArgs e)
        {
            ChangeAdminInformation ChangeInfo = new ChangeAdminInformation();
            AdminVerification Verification = new AdminVerification(ChangeInfo);
            Verification.Show();
        }
    }
}

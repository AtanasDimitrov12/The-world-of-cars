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
        ICarManager carManager;
        IRentManager rentManager;    
        List<Administrator> admins;
        public AdminInfoUC(IPeopleManager pm, IAdministratorRepository administratorRepository, ICarManager cm, IRentManager rm)
        {
            InitializeComponent();
            manager = pm;
            this.administratorRepository = administratorRepository;
            this.carManager = cm;
            this.rentManager = rm;
            admins = administratorRepository.GetAllAdministrators();
            DisplayAdminInfo();
            DisplayDataInfo();
        }
        public void DisplayDataInfo()
        { 
            LBLCars.Text = carManager.GetCars().Count.ToString();
            LBLUsers.Text = manager.GetAllUsers().Count.ToString();
            LBLRentals.Text = rentManager.rentalHistory.Count.ToString();   
        }

        public void DisplayAdminInfo()
        { 
            LBLAdminEmail.Text = admins[0].Email;
            LBLAdminUsername.Text = admins[0].Username;
            LBLAdminPhoneNumber.Text = admins[0].PhoneNumber;
        }
        private void BTNChangeAdminInfo_Click(object sender, EventArgs e)
        {
            ChangeAdminInformation ChangeInfo = new ChangeAdminInformation(admins[0], manager);
            ChangeInfo.InfoChanged += ChangeInfo_InfoChanged;
            AdminVerification Verification = new AdminVerification(ChangeInfo, admins[0], manager);
            Verification.Show();
            //ChangeInfo.Show();
        }

        private void ChangeInfo_InfoChanged(object sender, EventArgs e)
        {
            DisplayAdminInfo();
        }
    }
}

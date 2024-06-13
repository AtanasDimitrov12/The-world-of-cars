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
using Manager_Layer;

namespace DesktopApp
{
    public partial class AdminInfoUC : UserControl
    {
        IPeopleManager manager;
        IAdministratorRepository administratorRepository;
        ICarManager carManager;
        IRentManager rentManager;
        INewsManager newsManager;
        List<Administrator> admins;
        public AdminInfoUC(IPeopleManager pm, IAdministratorRepository administratorRepository, ICarManager cm, IRentManager rm, INewsManager nm)
        {
            InitializeComponent();
            manager = pm;
            this.administratorRepository = administratorRepository;
            this.carManager = cm;
            this.rentManager = rm;
            this.newsManager = nm;
            admins = administratorRepository.GetAllAdministrators();
            DisplayAdminInfo();
            DisplayDataInfo();
        }

        public void DisplayDataInfo()
        {
            TBCars.Text = carManager.GetCars().Count.ToString();
            TBCars.Enabled = false;
            TBUsers.Text = manager.GetAllUsers().Count.ToString();
            TBUsers.Enabled = false;
            TBRentals.Text = rentManager.RentalHistory.Count.ToString();
            TBRentals.Enabled = false;
            TBNews.Text = newsManager.news.Count.ToString();
            TBNews.Enabled = false;
            TBUsername.Enabled = false;
            TBEmail.Enabled = false;
            TBPhoneNumber.Enabled = false;

        }

        public void DisplayAdminInfo()
        {
            TBEmail.Text = admins[0].Email;
            TBUsername.Text = admins[0].Username;
            TBPhoneNumber.Text = admins[0].PhoneNumber;

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

        private void AddCar_CarAdded(object sender, EventArgs e)
        {
            DisplayDataInfo();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

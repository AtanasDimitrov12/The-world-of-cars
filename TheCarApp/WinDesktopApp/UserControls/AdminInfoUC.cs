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
        }

        private void BTNUpdateAdminInfo_Click(object sender, EventArgs e)
        {
            foreach (Administrator admin in admins)
            {
                if (RBAdminEmail.Checked)
                {
                    admin.Email = TBAdminInfo.Text;
                }
                else if (RBAdminPassword.Checked)
                {
                    admin.Password = TBAdminInfo.Text;
                }
                else if (RBAdminPhoneNumber.Checked)
                {
                    admin.PhoneNumber = TBAdminInfo.Text;
                }
                manager.UpdatePerson(admin);
                MessageBox.Show("You successfully updated the Admin info");
                TBAdminInfo.Clear();
            }
        }

        private void RBAdminEmail_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Administrator admin in admins)
            {
                LabelAdminInfo.Text = admin.Email;
            }
        }

        private void RBAdminPassword_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Administrator admin in admins)
            {
                LabelAdminInfo.Text = admin.Password;
            }
        }

        private void RBAdminPhoneNumber_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Administrator admin in admins)
            {
                LabelAdminInfo.Text = admin.PhoneNumber;
            }
        }
    }
}

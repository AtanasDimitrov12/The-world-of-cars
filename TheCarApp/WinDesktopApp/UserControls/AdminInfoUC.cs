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

namespace DesktopApp
{
    public partial class AdminInfoUC : UserControl
    {
        PeopleManager manager;
        List<Person> admins;
        public AdminInfoUC(PeopleManager pm)
        {
            InitializeComponent();
            manager = pm;
            admins = manager.people;
        }

        private void BTNUpdateAdminInfo_Click(object sender, EventArgs e)
        {
            foreach (Administrator admin in admins)
            {
                if (RBAdminEmail.Checked)
                {
                    admin.email = TBAdminInfo.Text;
                }
                else if (RBAdminPassword.Checked)
                {
                    admin.password = TBAdminInfo.Text;
                }
                else if (RBAdminPhoneNumber.Checked)
                {
                    admin._phoneNumber = TBAdminInfo.Text;
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
                LabelAdminInfo.Text = admin.email;
            }
        }

        private void RBAdminPassword_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Administrator admin in admins)
            {
                LabelAdminInfo.Text = admin.password;
            }
        }

        private void RBAdminPhoneNumber_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Administrator admin in admins)
            {
                LabelAdminInfo.Text = admin._phoneNumber;
            }
        }
    }
}

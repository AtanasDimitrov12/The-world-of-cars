using Entity_Layer;
using InterfaceLayer;
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
    public partial class AdminVerification : Form
    {
        ChangeAdminInformation ChangeAdmInfo;
        Administrator Admin;
        IPeopleManager Manager;
        public AdminVerification(ChangeAdminInformation ChangeInfo, Administrator administrator, IPeopleManager pm)
        {
            InitializeComponent();
            this.ChangeAdmInfo = ChangeInfo;
            this.Admin = administrator;
            Manager = pm;
        }

        private void BTNCheckPass_Click(object sender, EventArgs e)
        {
            if (Manager.VerifyPassword(TBAdminPass.Text, Admin.Password, Admin.PassSalt))
            {
                ChangeAdmInfo.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Entered password is different from the stored one! Try again.");
                TBAdminPass.Clear();
                ChangeAdmInfo.Show();
            }
        }
    }
}

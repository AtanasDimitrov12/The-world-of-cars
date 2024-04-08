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

namespace DesktopApp
{
    public partial class AdminInfoUC : UserControl
    {
        PeopleManager manager;
        public AdminInfoUC(PeopleManager pm)
        {
            InitializeComponent();
            manager = pm;
        }

        private void BTNUpdateAdminInfo_Click(object sender, EventArgs e)
        {

        }
    }
}

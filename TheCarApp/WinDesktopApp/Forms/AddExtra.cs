using Entity_Layer;
using Manager_Layer;
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
using InterfaceLayer;

namespace WinDesktopApp.Forms
{
    public partial class AddExtra : Form
    {
        IExtraManager manager;
        public AddExtra(IExtraManager em)
        {
            InitializeComponent();
            manager = em;
        }

        private void BTNAddExtra_Click(object sender, EventArgs e)
        {
            Extra extra = new Extra(RTBExtraName.Text);
            manager.AddExtra(extra);
            this.Close();
        }
    }
}

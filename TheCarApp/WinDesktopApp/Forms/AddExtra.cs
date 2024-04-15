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

namespace WinDesktopApp.Forms
{
    public partial class AddExtra : Form
    {
        ExtraManager manager;
        public AddExtra(ExtraManager em)
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

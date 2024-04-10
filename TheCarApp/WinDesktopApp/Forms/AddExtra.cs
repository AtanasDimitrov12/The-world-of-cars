using Entity_Layer;
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
        ExtraManager extraManager;
        public AddExtra(ExtraManager em)
        {
            InitializeComponent();
            extraManager = em;
        }

        private void BTNAddExtra_Click(object sender, EventArgs e)
        {
            Extra extra = new Extra(RTBExtraName.Text);
            extraManager.AddExtra(extra);
            this.Close();
        }
    }
}

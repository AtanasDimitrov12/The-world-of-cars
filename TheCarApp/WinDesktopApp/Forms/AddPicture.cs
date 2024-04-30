using Entity_Layer;
using EntityLayout;
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
    public partial class AddPicture : Form
    {
        IPictureManager manager;
        public AddPicture(IPictureManager pm)
        {
            InitializeComponent();
            manager = pm;
        }

        private void BTNAddPicture_Click(object sender, EventArgs e)
        {
            Picture pic = new Picture(TBPictureURL.Text);
            string ReturnMessage = manager.AddPicture(pic);
            if (ReturnMessage == "done")
            {
                this.Close();
            }
            else { MessageBox.Show(ReturnMessage); }
        }
    }
}

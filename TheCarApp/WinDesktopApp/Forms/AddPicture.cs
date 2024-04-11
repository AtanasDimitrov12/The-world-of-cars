using Entity_Layer;
using EntityLayout;
using Manager_Layer;
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
    public partial class AddPicture : Form
    {
        CarManager manager;
        public AddPicture(CarManager cm)
        {
            InitializeComponent();
            manager = cm;
        }

        private void BTNAddPicture_Click(object sender, EventArgs e)
        {
            Picture pic = new Picture(TBPictureURL.Text);
            manager.AddPicture(pic);
            this.Close();
        }
    }
}

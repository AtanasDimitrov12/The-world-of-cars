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
    public partial class ControlPage : Form
    {
        AdminInfoUC adminInfoUC;
        CarNewsUC carNewsUC;
        CarControlUC carControlUC;
        CommentsControlUC commentsControlUC;
        List<UserControl> usercontrols;
        
        public ControlPage()
        {
            InitializeComponent();
            adminInfoUC = new AdminInfoUC();
            carNewsUC = new CarNewsUC();
            carControlUC = new CarControlUC();
            commentsControlUC = new CommentsControlUC();    
            usercontrols = new List<UserControl> { adminInfoUC, carNewsUC, carControlUC, commentsControlUC };


            
            this.Controls.Add(panel2); 

            AddUC(); 
        }


        public void AddUC()
        {
            foreach (var control in usercontrols)
            {
                control.Dock = DockStyle.Fill;
                panel2.Controls.Add(control);
                control.Hide(); 
            }
        }


        private void BTNControlAdminInfo_Click(object sender, EventArgs e)
        {
            adminInfoUC.Show();
            adminInfoUC.BringToFront();
        }

        private void carNewsUC1_Load(object sender, EventArgs e)
        {

        }

        private void BTNCarNews_Click(object sender, EventArgs e)
        {
            carNewsUC.Show();
            carNewsUC.BringToFront();
        }

        private void BTNComments_Click(object sender, EventArgs e)
        {
            commentsControlUC.Show();
            commentsControlUC.BringToFront();
        }

        private void BTNCarControl_Click(object sender, EventArgs e)
        {
            carControlUC.Show();
            carControlUC.BringToFront();
        }
    }
}

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
        List<UserControl> usercontrols;
        
        public ControlPage()
        {
            InitializeComponent();
            adminInfoUC = new AdminInfoUC();
            carNewsUC = new CarNewsUC();
            usercontrols = new List<UserControl> { adminInfoUC, carNewsUC };



            /*panel2.Dock = DockStyle.Fill;*/ // This makes the panel fill the entire form.
            
            this.Controls.Add(panel2); // Add the panel to the form's controls.

            AddUC(); // Now that everything is initialized, add the user controls.
        }


        public void AddUC()
        {
            foreach (var control in usercontrols)
            {
                control.Dock = DockStyle.Fill;
                panel2.Controls.Add(control);
                control.Hide(); // Hide controls initially here, instead of in the constructor.
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

        private void button2_Click(object sender, EventArgs e)
        {
            carNewsUC.Show();
            carNewsUC.BringToFront();
        }
    }
}

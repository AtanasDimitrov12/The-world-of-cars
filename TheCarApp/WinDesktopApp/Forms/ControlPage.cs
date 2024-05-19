using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerLayer;

namespace DesktopApp
{
    public partial class ControlPage : Form
    {
        AdminInfoUC adminInfoUC;
        CarNewsUC carNewsUC;
        CarControlUC carControlUC;
        CommentsControlUC commentsControlUC;
        List<UserControl> userControls;
        ProjectManager projectManager;
        
        public ControlPage()
        {
            InitializeComponent();
            projectManager = new ProjectManager();
            adminInfoUC = new AdminInfoUC(projectManager.PeopleManager, projectManager.AdministratorRepository);
            carNewsUC = new CarNewsUC(projectManager.PeopleManager, projectManager.NewsManager);
            carControlUC = new CarControlUC(projectManager.PeopleManager, projectManager.CarManager, projectManager.ExtraManager, projectManager.PictureManager);
            commentsControlUC = new CommentsControlUC(projectManager.NewsManager, projectManager.CommentsManager);    
            userControls = new List<UserControl> { adminInfoUC, carNewsUC, carControlUC, commentsControlUC };
            this.Controls.Add(panel2);
            AddUC(); 
        }


        public void AddUC()
        {
            foreach (var control in userControls)
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

﻿using ManagerLayer;
using WinDesktopApp.UserControls;

namespace WinDesktopApp.Forms
{
    public partial class ControlPage : Form
    {
        AdminInfoUC adminInfoUC;
        CarNewsUC carNewsUC;
        CarControlUC carControlUC;
        CommentsControlUC commentsControlUC;
        RentalsUC rentalsUC;
        List<UserControl> userControls;
        ProjectManager projectManager;
        

        public ControlPage(ProjectManager pm)
        {
            InitializeComponent();
            projectManager = pm;
            adminInfoUC = new AdminInfoUC(projectManager.PeopleManager, projectManager.AdministratorRepository, projectManager.CarManager, projectManager.RentManager, projectManager.NewsManager);
            carNewsUC = new CarNewsUC(projectManager.PeopleManager, projectManager.NewsManager);
            carControlUC = new CarControlUC(projectManager.RentManager, projectManager.CarManager, projectManager.ExtraManager, projectManager.PictureManager);
            commentsControlUC = new CommentsControlUC(projectManager.NewsManager, projectManager.CommentsManager, projectManager.PeopleManager);
            rentalsUC = new RentalsUC(projectManager.PeopleManager, projectManager.RentManager, projectManager.CarManager, projectManager.UserManager);
            userControls = new List<UserControl> { adminInfoUC, carNewsUC, carControlUC, commentsControlUC, rentalsUC };
            this.Controls.Add(panel2);
            AddUC();


            carControlUC.admInfo = adminInfoUC;
            carControlUC.rentalsUC = rentalsUC;
            carNewsUC.admInfo = adminInfoUC;
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

        private void BTNRent_Click(object sender, EventArgs e)
        {
            rentalsUC.Show();
            rentalsUC.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

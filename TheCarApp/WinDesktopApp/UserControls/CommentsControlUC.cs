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
using InterfaceLayer;

namespace DesktopApp
{
    public partial class CommentsControlUC : UserControl
    {
        INewsManager newsManager;
        ICommentsManager commentsManager;
        public CommentsControlUC(INewsManager nm, ICommentsManager cm)
        {
            InitializeComponent();
            newsManager = nm;
            commentsManager = cm;
            foreach (CarNews news in newsManager.news)
            {
                CBNews.Items.Add(news.Title);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            DisplayComments(CBNews.Text);
        }

        private void DisplayComments(string NewsTitle)
        {
            LBComments.Items.Clear();
            foreach (CarNews news in newsManager.news)
            {
                if (news.Title == NewsTitle)
                {
                    foreach (Comment comm in news.Comments)
                    {
                        LBComments.Items.Add(comm.Message);
                    }
                }
            }
        }

        private void BTNDelete_Click(object sender, EventArgs e)
        {
            if (LBComments.SelectedItem != null)
            {
                string DeleteComment = LBComments.SelectedItem.ToString();
                foreach (CarNews news in newsManager.news)
                {
                    if (news.Title == CBNews.Text)
                    {
                        foreach (Comment comm in news.Comments)
                        {
                            if (comm.Message == DeleteComment)
                            {
                                commentsManager.RemoveComment(news, comm);
                                DisplayComments(CBNews.Text);
                                break;
                            }
                            
                        }
                    }
                }
            }
            else 
            {
                MessageBox.Show("Please first select a comment!");
            }
        }
    }
}

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

namespace DesktopApp
{
    public partial class CommentsControlUC : UserControl
    {
        NewsManager newsManager;
        CommentsManager commentsManager;
        public CommentsControlUC(NewsManager nm, CommentsManager cm)
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
            LBComments.Items.Clear();
            foreach (CarNews news in newsManager.news)
            {
                if (news.Title == CBNews.Text)
                {
                    foreach (Comment comm in news.comments)
                    {
                        LBComments.Items.Add(comm.Message);
                    }
                }
            }
        }

        private void BTNDelete_Click(object sender, EventArgs e)
        {
            string DeleteComment = LBComments.SelectedItem.ToString();
            foreach (CarNews news in newsManager.news)
            {
                if (news.Title == CBNews.Text)
                {
                    foreach (Comment comm in news.comments)
                    {
                        if (comm.Message == DeleteComment)
                        {
                            news.RemoveComment(comm);
                        }
                    }
                }
            }
        }
    }
}

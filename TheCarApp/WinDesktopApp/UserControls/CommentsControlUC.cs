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
using EntityLayout;
using Manager_Layer;
using System.Xml.Linq;

namespace DesktopApp
{
    public partial class CommentsControlUC : UserControl
    {
        INewsManager newsManager;
        ICommentsManager commentsManager;
        IPeopleManager peopleManager;
        List<Comment> allComments;
        public CommentsControlUC(INewsManager nm, ICommentsManager cm, IPeopleManager pm)
        {
            InitializeComponent();
            newsManager = nm;
            commentsManager = cm;
            peopleManager = pm;
            allComments = new List<Comment>();
            foreach (CarNews news in newsManager.news)
            {
                CBNews.Items.Add(news.Title);
                foreach (var comm in news.Comments)
                {
                    allComments.Add(comm);
                }
            }
            InitializeGridView();
            FillDataGridView(allComments);
        }

        private void InitializeGridView()
        {
            this.DGVComments.ColumnCount = 3;
            this.DGVComments.Columns[0].Name = "Member";
            this.DGVComments.Columns[0].Width = 100;
            this.DGVComments.Columns[1].Name = "Date";
            this.DGVComments.Columns[1].Width = 100;
            this.DGVComments.Columns[2].Name = "Comment";
            this.DGVComments.Columns[2].Width = 350;


            var btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Delete";
            btnDelete.HeaderText = "Delete";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            DGVComments.Columns.Add(btnDelete);


        }

        private void FillDataGridView(List<Comment> comments)
        {
            var userDictionary = peopleManager.GetAllUsers().ToDictionary(user => user.Id, user => user.Username);

            this.DGVComments.Rows.Clear();

            foreach (var comment in comments)
            {
                if (userDictionary.TryGetValue(comment.UserId, out string username))
                {
                    this.DGVComments.Rows.Add(username, comment.Date.ToShortDateString(), comment.Message);
                }
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
            List<Comment> comments = new List<Comment>();
            foreach (CarNews news in newsManager.news)
            {
                if (news.Title == NewsTitle)
                {
                    foreach (Comment comm in news.Comments)
                    {
                        comments.Add(comm);
                    }
                }
            }
            FillDataGridView(comments);
        }

        private void DGVComments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVComments.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {

                    var Comment = DGVComments.Rows[e.RowIndex].Cells["Comment"].Value.ToString();

                    foreach (var news in newsManager.news)
                    {
                        foreach (var comm in news.Comments)
                        {
                            if (comm.Message == Comment)
                            {
                                commentsManager.RemoveComment(news, comm);
                                DisplayComments(CBNews.Text);
                                break;
                            }
                        }
                    }
                }
            }

        }
    }
}

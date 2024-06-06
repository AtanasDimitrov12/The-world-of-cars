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
            this.DGVComments.CellPainting += DGVComments_CellPainting;
        }

        private void InitializeGridView()
        {
            Font gridFont = new Font("Arial Rounded MT Bold", 10);

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

            DGVComments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVComments.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#344E41");
            DGVComments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGVComments.ColumnHeadersDefaultCellStyle.Font = new Font(gridFont, FontStyle.Bold);
            DGVComments.EnableHeadersVisualStyles = false;
            DGVComments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVComments.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#588157");
            DGVComments.DefaultCellStyle.SelectionForeColor = Color.White;
            DGVComments.BackgroundColor = ColorTranslator.FromHtml("#DAD7CD");
            DGVComments.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#A3B18A");
            DGVComments.DefaultCellStyle.Font = gridFont;
            DGVComments.ColumnHeadersDefaultCellStyle.Font = gridFont;
            DGVComments.RowHeadersDefaultCellStyle.Font = gridFont;
        }

        private void DGVComments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DGVComments.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var buttonRect = e.CellBounds;
                    var buttonColor = Color.White; 
                    var textColor = Color.Black; 

                    
                    if (e.ColumnIndex == DGVComments.Columns["Delete"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#3A5A40");
                        textColor = Color.White;
                    }

                    var adjustedRect = new Rectangle(buttonRect.X + 1, buttonRect.Y + 1, buttonRect.Width - 2, buttonRect.Height - 2);

                    using (Brush brush = new SolidBrush(buttonColor))
                    {
                        e.Graphics.FillRectangle(brush, adjustedRect);
                    }

                    var buttonText = (string)e.FormattedValue;
                    var textSize = TextRenderer.MeasureText(buttonText, e.CellStyle.Font);
                    var textLocation = new Point(
                        e.CellBounds.Left + (e.CellBounds.Width - textSize.Width) / 2,
                        e.CellBounds.Top + (e.CellBounds.Height - textSize.Height) / 2);

                    TextRenderer.DrawText(e.Graphics, buttonText, e.CellStyle.Font, textLocation, textColor);

                    e.Graphics.DrawRectangle(Pens.Black, adjustedRect);

                    if ((e.State & DataGridViewElementStates.Selected) != 0 || (e.State & DataGridViewElementStates.Displayed) != 0)
                    {
                        var hoverRect = new Rectangle(adjustedRect.X - 1, adjustedRect.Y - 1, adjustedRect.Width + 2, adjustedRect.Height + 2);
                        e.Graphics.DrawRectangle(Pens.DarkGray, hoverRect);
                    }

                    e.Handled = true;
                }
            }
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
            if (NewsTitle != "")
            {
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
            else 
            {
                FillDataGridView(allComments);
            }
            
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

        private void RBASC_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CBNews.Text))
            {
                foreach (CarNews news in newsManager.news)
                {
                    if (news.Title == CBNews.Text)
                    {
                        SortCommentsAscending(news.Comments);
                    }
                   
                }
            }
            else
            {
                SortCommentsAscending(allComments);
            }
        }

        private void RBDESC_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CBNews.Text))
            {
                foreach (CarNews news in newsManager.news)
                {
                    if (news.Title == CBNews.Text)
                    {
                        SortCommentsDescending(news.Comments);
                    }

                }
            }
            else
            {
                SortCommentsDescending(allComments);
            }
        }

        private void SortCommentsAscending(List<Comment> comments)
        {

            comments = comments.OrderBy(comm => comm.Date).ToList();

            FillDataGridView(comments);
        }

        private void SortCommentsDescending(List<Comment> comments)
        {

            comments = comments.OrderByDescending(comm => comm.Date).ToList();

            FillDataGridView(comments);
        }
    }
}

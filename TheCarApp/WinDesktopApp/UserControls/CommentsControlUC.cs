﻿using System.Data;
using InterfaceLayer;
using DTO;

namespace WinDesktopApp.UserControls
{
    public partial class CommentsControlUC : UserControl
    {
        INewsManager newsManager;
        ICommentsManager commentsManager;
        IPeopleManager peopleManager;
        List<CommentDTO> allComments;
        public CommentsControlUC(INewsManager nm, ICommentsManager cm, IPeopleManager pm)
        {
            InitializeComponent();
            newsManager = nm;
            commentsManager = cm;
            peopleManager = pm;
            allComments = new List<CommentDTO>();
            foreach (CarNewsDTO news in newsManager.News)
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
            this.DGVComments.Columns[0].Width = 50;
            this.DGVComments.Columns[1].Name = "Date";
            this.DGVComments.Columns[1].Width = 50;
            this.DGVComments.Columns[2].Name = "Comment";
            this.DGVComments.Columns[2].Width = 450;


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

        private void FillDataGridView(List<CommentDTO> comments)
        {
            var userDictionary = peopleManager.GetAllUsers().ToDictionary(user => user.Id, user => user.Username);

            this.DGVComments.Rows.Clear();

            foreach (var comment in comments)
            {
                if (userDictionary.TryGetValue(comment.UserId, out string username))
                {
                    this.DGVComments.Rows.Add(username, comment.CommentDate, comment.Content);
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
            List<CommentDTO> comments = new List<CommentDTO>();
            if (NewsTitle != "")
            {
                foreach (CarNewsDTO news in newsManager.News)
                {
                    if (news.Title == NewsTitle)
                    {
                        foreach (CommentDTO comm in news.Comments)
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

        private async void DGVComments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVComments.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {

                    var Comment = DGVComments.Rows[e.RowIndex].Cells["Comment"].Value.ToString();

                    foreach (var news in newsManager.News)
                    {
                        foreach (var comm in news.Comments)
                        {
                            if (comm.Content == Comment)
                            {
                                (bool Response, string errorMessage) = await commentsManager.RemoveCommentAsync(news, comm);
                                if (Response)
                                {
                                    MessageBox.Show("You successfully delete that comment!");
                                    DisplayComments(CBNews.Text);
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show($"Failed to remove comment: {errorMessage}");
                                }
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
                foreach (CarNewsDTO news in newsManager.News)
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
                foreach (CarNewsDTO news in newsManager.News)
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

        private void SortCommentsAscending(List<CommentDTO> comments)
        {

            comments = comments.OrderBy(comm => comm.CommentDate).ToList();

            FillDataGridView(comments);
        }

        private void SortCommentsDescending(List<CommentDTO> comments)
        {

            comments = comments.OrderByDescending(comm => comm.CommentDate).ToList();

            FillDataGridView(comments);
        }

        private void BTNShowAll_Click(object sender, EventArgs e)
        {
            FillDataGridView(allComments);
        }
    }
}

using Entity_Layer;
using Entity_Layer.Interfaces;
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
using Manager_Layer;
using EntityLayout;
using System.Text.RegularExpressions;

namespace DesktopApp
{
    public partial class CarNewsUC : UserControl
    {
        IPeopleManager peopleManager;
        INewsManager newsManager;
        List<CarNews> News;
        public AdminInfoUC admInfo { get; set; }
        public CarNewsUC(IPeopleManager pm, INewsManager nw)
        {
            InitializeComponent();
            this.peopleManager = pm;
            this.newsManager = nw;
            News = newsManager.news;
            InitializeGridView();
            FillDataGridView(News);
            this.DGVNews.CellPainting += DGVNews_CellPainting;

        }

        private void BTNAddNews_Click(object sender, EventArgs e)
        {
            AddNews addNews = new AddNews(null, newsManager, false);
            addNews.NewsAdded += AddNews_NewsAdded;
            addNews.Show();
        }

        private void AddNews_NewsAdded(object sender, EventArgs e)
        {
            FillDataGridView(News);
            admInfo.DisplayDataInfo();
        }

        private void InitializeGridView()
        {
            Font gridFont = new Font("Arial Rounded MT Bold", 10);

            this.DGVNews.ColumnCount = 3;
            this.DGVNews.Columns[0].Name = "Title";
            this.DGVNews.Columns[0].Width = 180;
            this.DGVNews.Columns[1].Name = "Author";
            this.DGVNews.Columns[1].Width = 130;
            this.DGVNews.Columns[2].Name = "Date";
            this.DGVNews.Columns[2].Width = 150;


            var btnView = new DataGridViewButtonColumn();
            btnView.Name = "View";
            btnView.HeaderText = "View";
            btnView.Text = "View";
            btnView.UseColumnTextForButtonValue = true;
            DGVNews.Columns.Add(btnView);

            var btnModify = new DataGridViewButtonColumn();
            btnModify.Name = "Modify";
            btnModify.HeaderText = "Modify";
            btnModify.Text = "Modify";

            btnModify.UseColumnTextForButtonValue = true;
            DGVNews.Columns.Add(btnModify);

            var btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Delete";
            btnDelete.HeaderText = "Delete";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            DGVNews.Columns.Add(btnDelete);


            DGVNews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVNews.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#344E41");
            DGVNews.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGVNews.ColumnHeadersDefaultCellStyle.Font = new Font(gridFont, FontStyle.Bold);
            DGVNews.EnableHeadersVisualStyles = false;
            DGVNews.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVNews.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#588157");
            DGVNews.DefaultCellStyle.SelectionForeColor = Color.White;
            DGVNews.BackgroundColor = ColorTranslator.FromHtml("#DAD7CD");
            DGVNews.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#A3B18A");
            DGVNews.DefaultCellStyle.Font = gridFont;
            DGVNews.ColumnHeadersDefaultCellStyle.Font = gridFont;
            DGVNews.RowHeadersDefaultCellStyle.Font = gridFont;

        }

        private void DGVNews_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DGVNews.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var buttonRect = e.CellBounds;
                    var buttonColor = Color.White; // Default color
                    var textColor = Color.Black; // Default text color

                    if (e.ColumnIndex == DGVNews.Columns["View"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#3A5A40");
                        //buttonColor = ColorTranslator.FromHtml("#588157");
                        textColor = Color.White;
                        //buttonColor = ColorTranslator.FromHtml("#A3B18A");
                    }
                    else if (e.ColumnIndex == DGVNews.Columns["Modify"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#588157");
                        textColor = Color.White;
                    }
                    else if (e.ColumnIndex == DGVNews.Columns["Delete"].Index)
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



        private void FillDataGridView(List<CarNews> news)
        {
            this.DGVNews.Rows.Clear();
            foreach (var carNews in news)
            {
                this.DGVNews.Rows.Add(carNews.Title, carNews.Author, carNews.ReleaseDate);
            }
        }

        private void RBASC_CheckedChanged(object sender, EventArgs e)
        {
            News.Sort(new CarNewsDateAscendingComparer());
            FillDataGridView(News);
        }

        private void RBDESC_CheckedChanged(object sender, EventArgs e)
        {
            News.Sort(new CarNewsDateDescendingComparer());
            FillDataGridView(News);
        }



        private void BTNSearchByTitle_Click(object sender, EventArgs e)
        {
            string title = TBNewsTitle.Text;
            var filteredNews = newsManager.news
                .Where(news => Regex.IsMatch(news.Title, Regex.Escape(title), RegexOptions.IgnoreCase))
                .ToList();
            FillDataGridView(filteredNews);
        }

        private void DGVNews_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVNews.Columns["Modify"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {

                    var newsTitle = DGVNews.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                    var newsAuthor = DGVNews.Rows[e.RowIndex].Cells["Author"].Value.ToString();

                    foreach (var selectedNews in newsManager.news)
                    {
                        if (selectedNews.Title == newsTitle && selectedNews.Author == newsAuthor)
                        {
                            AddNews addNews = new AddNews(selectedNews, newsManager, false);
                            addNews.NewsAdded += AddNews_NewsAdded;
                            
                            addNews.Show();
                            break;
                        }
                    }
                }
            }

            if (e.ColumnIndex == DGVNews.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var newsTitle = DGVNews.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                    var newsAuthor = DGVNews.Rows[e.RowIndex].Cells["Author"].Value.ToString();

                    foreach (var selectedNews in newsManager.news)
                    {
                        if (selectedNews.Title == newsTitle && selectedNews.Author == newsAuthor)
                        {
                            DialogResult result = MessageBox.Show(
        "Are you sure you want to delete that news?",
        "Confirmation",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

                            if (result == DialogResult.Yes)
                            {
                                if (newsManager.DeleteNews(selectedNews, out string errorMessage))
                                {
                                    FillDataGridView(newsManager.news);
                                    admInfo.DisplayDataInfo();
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show($"Failed to delete that news: {errorMessage}");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Deletion canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }

            if (e.ColumnIndex == DGVNews.Columns["View"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var newsTitle = DGVNews.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                    var newsAuthor = DGVNews.Rows[e.RowIndex].Cells["Author"].Value.ToString();

                    foreach (var selectedNews in newsManager.news)
                    {
                        if (selectedNews.Title == newsTitle && selectedNews.Author == newsAuthor)
                        {
                            AddNews addNews = new AddNews(selectedNews, newsManager, true);
                            addNews.Show();
                            break;
                        }
                    }
                }
            }
        }

        private void BTNShowAll_Click(object sender, EventArgs e)
        {
            FillDataGridView(newsManager.news);
        }
    }
}

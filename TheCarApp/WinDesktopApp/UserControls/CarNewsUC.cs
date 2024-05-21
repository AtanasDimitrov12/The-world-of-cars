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

namespace DesktopApp
{
    public partial class CarNewsUC : UserControl
    {
        IPeopleManager peopleManager;
        INewsManager newsManager;
        List<CarNews> News;
        public CarNewsUC(IPeopleManager pm, INewsManager nw)
        {
            InitializeComponent();
            this.peopleManager = pm;
            this.newsManager = nw;
            News = newsManager.news;
            InitializeGridView();
            FillDataGridView(News);
            
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
        }

        private void InitializeGridView()
        {
            this.DGVNews.ColumnCount = 3;
            this.DGVNews.Columns[0].Name = "Title";
            this.DGVNews.Columns[0].Width = 180;
            this.DGVNews.Columns[1].Name = "Author";
            this.DGVNews.Columns[1].Width = 130;
            this.DGVNews.Columns[2].Name = "Date";
            this.DGVNews.Columns[2].Width = 150;

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

            var btnView = new DataGridViewButtonColumn();
            btnView.Name = "View";
            btnView.HeaderText = "View";
            btnView.Text = "View";
            btnView.UseColumnTextForButtonValue = true;
            DGVNews.Columns.Add(btnView);
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
            var filteredNews = newsManager.news.Where(news => news.Title == title).ToList();
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
                            newsManager.DeleteNews(selectedNews);
                            FillDataGridView(newsManager.news);
                            break;
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
    }
}

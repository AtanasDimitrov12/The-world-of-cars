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
            DisplayNews(News);
        }

        private void BTNAddNews_Click(object sender, EventArgs e)
        {
            AddNews addNews = new AddNews(null, newsManager);
            addNews.Show();
        }

        private void BTNModifyNews_Click(object sender, EventArgs e)
        {
            string CarInfo = LBCarNews.SelectedItem.ToString(); //trqbva da napravq try/catch ako ne e izbrana kola 
            foreach (var news in newsManager.news)
            {
                if ($"{news.Title} - {news.ReleaseDate}" == CarInfo)
                {
                    AddNews addNews = new AddNews(news, newsManager);
                    addNews.Show();
                }
            }
        }

        private void RBASC_CheckedChanged(object sender, EventArgs e)
        {
            News.Sort(new CarNewsDateAscendingComparer());
            DisplayNews(News);
        }

        private void RBDESC_CheckedChanged(object sender, EventArgs e)
        {
            News.Sort(new CarNewsDateDescendingComparer());
            DisplayNews(News);
        }

        public void DisplayNews(List<CarNews> displayNews)
        {
            LBCarNews.Items.Clear();
            foreach (CarNews carNews in displayNews)
            {
                LBCarNews.Items.Add($"{carNews.Title} - {carNews.ReleaseDate}");
            }
        }

        private void BTNSearchByTitle_Click(object sender, EventArgs e)
        {
            LBCarNews.Items.Clear();
            string title = TBNewsTitle.Text;
            var filteredNews = newsManager.news.Where(news => news.Title == title).ToList();
            foreach (var news in filteredNews)
            {
                LBCarNews.Items.Add($"{news.Title} - {news.ReleaseDate}");
            }
        }
    }
}

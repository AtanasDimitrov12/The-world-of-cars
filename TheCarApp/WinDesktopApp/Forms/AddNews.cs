using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Entity_Layer;
using InterfaceLayer;

namespace DesktopApp
{
    public partial class AddNews : Form
    {
        INewsManager NewsManager;
        bool Modify = false;
        CarNews newsData;
        public AddNews(CarNews news, INewsManager newsManager)
        {
            InitializeComponent();
            newsData = news;
            NewsManager = newsManager;
            if (newsData != null)
            {
                Modify = true;
                LoadNewsData();
                BTNAdd.Text = "Update Car";
            }
        }

        private void LoadNewsData()
        { 
            TBNewsTitle.Text = newsData.Title;
            TBNewsAuthor.Text = newsData.Author;
            RTBNewsIntro.Text = newsData.ShortIntro;
            RTBNewsDescription.Text = newsData.NewsDescription;
            TBNewsImageURL.Text = newsData.ImageURL;
        }

        private void BTNAdd_Click(object sender, EventArgs e)
        {
            if (!Modify)
            {
                DateTime dateTime = DateTime.Now;
                CarNews news = new CarNews(RTBNewsDescription.Text, dateTime, TBNewsImageURL.Text, TBNewsTitle.Text, TBNewsAuthor.Text, RTBNewsIntro.Text);
                NewsManager.AddNews(news);
                MessageBox.Show("You successfully added this news!");
            }
            else 
            {
                newsData.Author = TBNewsAuthor.Text;
                newsData.Title = TBNewsTitle.Text;
                newsData.ShortIntro = RTBNewsIntro.Text;
                newsData.NewsDescription = RTBNewsDescription.Text;
                newsData.ImageURL = TBNewsImageURL.Text;
                NewsManager.UpdateNews(newsData);
                MessageBox.Show("You successfully updated this news!");
            }
            
            this.Close();
        }
    }
}

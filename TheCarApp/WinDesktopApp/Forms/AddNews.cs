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
        public event EventHandler NewsAdded;
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
                string ReturnMessage = NewsManager.AddNews(news);
                if (ReturnMessage == "done")
                {
                    MessageBox.Show("You successfully added this news!");
                    NewsAdded?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else { MessageBox.Show(ReturnMessage); }
            }
            else 
            {
                newsData.Author = TBNewsAuthor.Text;
                newsData.Title = TBNewsTitle.Text;
                newsData.ShortIntro = RTBNewsIntro.Text;
                newsData.NewsDescription = RTBNewsDescription.Text;
                newsData.ImageURL = TBNewsImageURL.Text;
                string ReturnMessage = NewsManager.UpdateNews(newsData);
                if (ReturnMessage == "done")
                {
                    MessageBox.Show("You successfully updated this news!");
                    NewsAdded?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else { MessageBox.Show(ReturnMessage); }
            }
            
        }
    }
}

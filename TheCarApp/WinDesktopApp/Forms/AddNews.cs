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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopApp
{
    public partial class AddNews : Form
    {
        INewsManager NewsManager;
        bool Modify = false;
        CarNews newsData;
        public event EventHandler NewsAdded;
        bool View;
        public AddNews(CarNews news, INewsManager newsManager, bool View)
        {
            InitializeComponent();
            newsData = news;
            NewsManager = newsManager;
            this.View = View;
            if (newsData != null)
            {
                Modify = true;
                LoadNewsData();
                BTNAdd.Text = "Update Car";
            }
            if (View)
            {
                BTNAdd.Text = "Close";
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
            if (!Modify && !View)
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
            else if (View)
            {
                this.Close();
            }
            else if (Modify == true)
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

        private void TBNewsTitle_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 50;
            if (TBNewsTitle.Text.Length > maxLength)
            {
                MessageBox.Show("Input is too long. Please enter a maximum of 50 characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNewsTitle.Text = TBNewsTitle.Text.Substring(0, maxLength);
                TBNewsTitle.SelectionStart = TBNewsTitle.Text.Length;
            }
        }


        private void TBNewsAuthor_TextChanged_1(object sender, EventArgs e)
        {
            const int maxLength = 50;
            if (TBNewsAuthor.Text.Length > maxLength)
            {
                MessageBox.Show("Input is too long. Please enter a maximum of 50 characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNewsAuthor.Text = TBNewsAuthor.Text.Substring(0, maxLength);
                TBNewsAuthor.SelectionStart = TBNewsAuthor.Text.Length;
            }
        }

    }
}

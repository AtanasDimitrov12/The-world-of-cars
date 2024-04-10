using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity_Layer;

namespace DesktopApp
{
    public partial class AddNews : Form
    {
        NewsManager NewsManager;
        public AddNews(NewsManager newsManager)
        {
            InitializeComponent();
            NewsManager = newsManager;
        }

        private void BTNAdd_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            CarNews news = new CarNews(RTBNewsDescription.Text, dateTime, TBNewsImageURL.Text, TBNewsTitle.Text, TBNewsAuthor.Text, RTBNewsIntro.Text);
            NewsManager.AddNews(news);
            this.Close();
        }
    }
}

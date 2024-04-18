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
using InterfaceLayer;

namespace DesktopApp
{
    public partial class AddNews : Form
    {
        INewsManager NewsManager;
        public AddNews(INewsManager newsManager)
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

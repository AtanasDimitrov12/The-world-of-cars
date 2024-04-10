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

namespace DesktopApp
{
    public partial class CarNewsUC : UserControl
    {
        PeopleManager peopleManager;
        NewsManager newsManager;
        public CarNewsUC(PeopleManager pm, NewsManager nw)
        {
            InitializeComponent();
            this.peopleManager = pm;
            this.newsManager = nw;
        }

        private void BTNAddNews_Click(object sender, EventArgs e)
        {
            AddNews addNews = new AddNews(newsManager);
            addNews.Show();
        }

        private void BTNModifyNews_Click(object sender, EventArgs e)
        {
            AddNews addNews = new AddNews(newsManager);
            addNews.Show();
        }
    }
}

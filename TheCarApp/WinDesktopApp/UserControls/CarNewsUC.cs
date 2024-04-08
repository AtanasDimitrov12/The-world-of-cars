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
        public CarNewsUC()
        {
            InitializeComponent();
        }

        private void BTNAddNews_Click(object sender, EventArgs e)
        {
            AddNews addNews = new AddNews();
            addNews.Show();
        }

        private void BTNModifyNews_Click(object sender, EventArgs e)
        {
            AddNews addNews = new AddNews();
            addNews.Show();
        }
    }
}

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
    public partial class CarControlUC : UserControl
    {
        public CarControlUC()
        {
            InitializeComponent();
        }

        private void BTNAddCar_Click(object sender, EventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.Show();
        }

        private void BTNModifyCar_Click(object sender, EventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.Show();
        }
    }
}

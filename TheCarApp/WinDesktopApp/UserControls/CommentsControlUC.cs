﻿using Entity_Layer;
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
    public partial class CommentsControlUC : UserControl
    {
        NewsManager newsManager;
        public CommentsControlUC(NewsManager nm)
        {
            InitializeComponent();
            newsManager = nm;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace DesktopApp
{
    partial class CarNewsUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox2 = new GroupBox();
            RBDESC = new RadioButton();
            RBASC = new RadioButton();
            label4 = new Label();
            groupBox3 = new GroupBox();
            BTNSearchByTitle = new Button();
            TBNewsTitle = new TextBox();
            label5 = new Label();
            BTNAddNews = new Button();
            groupBox1 = new GroupBox();
            DGVNews = new DataGridView();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVNews).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RBDESC);
            groupBox2.Controls.Add(RBASC);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(16, 23);
            groupBox2.Margin = new Padding(5, 4, 5, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 4, 5, 4);
            groupBox2.Size = new Size(240, 128);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Show news";
            // 
            // RBDESC
            // 
            RBDESC.AutoSize = true;
            RBDESC.Location = new Point(135, 71);
            RBDESC.Margin = new Padding(5, 4, 5, 4);
            RBDESC.Name = "RBDESC";
            RBDESC.Size = new Size(62, 24);
            RBDESC.TabIndex = 16;
            RBDESC.TabStop = true;
            RBDESC.Text = "Desc";
            RBDESC.UseVisualStyleBackColor = true;
            RBDESC.CheckedChanged += RBDESC_CheckedChanged;
            // 
            // RBASC
            // 
            RBASC.AutoSize = true;
            RBASC.Location = new Point(35, 71);
            RBASC.Margin = new Padding(5, 4, 5, 4);
            RBASC.Name = "RBASC";
            RBASC.Size = new Size(53, 24);
            RBASC.TabIndex = 15;
            RBASC.TabStop = true;
            RBASC.Text = "Asc";
            RBASC.UseVisualStyleBackColor = true;
            RBASC.CheckedChanged += RBASC_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F);
            label4.Location = new Point(41, 36);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(135, 23);
            label4.TabIndex = 14;
            label4.Text = "Sort by date:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BTNSearchByTitle);
            groupBox3.Controls.Add(TBNewsTitle);
            groupBox3.Controls.Add(label5);
            groupBox3.Location = new Point(16, 181);
            groupBox3.Margin = new Padding(5, 4, 5, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(5, 4, 5, 4);
            groupBox3.Size = new Size(240, 211);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Search news";
            // 
            // BTNSearchByTitle
            // 
            BTNSearchByTitle.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNSearchByTitle.Location = new Point(35, 127);
            BTNSearchByTitle.Margin = new Padding(5, 4, 5, 4);
            BTNSearchByTitle.Name = "BTNSearchByTitle";
            BTNSearchByTitle.Size = new Size(167, 67);
            BTNSearchByTitle.TabIndex = 19;
            BTNSearchByTitle.Text = "Search";
            BTNSearchByTitle.UseVisualStyleBackColor = true;
            BTNSearchByTitle.Click += BTNSearchByTitle_Click;
            // 
            // TBNewsTitle
            // 
            TBNewsTitle.Location = new Point(55, 87);
            TBNewsTitle.Margin = new Padding(5, 4, 5, 4);
            TBNewsTitle.Name = "TBNewsTitle";
            TBNewsTitle.Size = new Size(132, 27);
            TBNewsTitle.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F);
            label5.Location = new Point(41, 40);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(156, 23);
            label5.TabIndex = 17;
            label5.Text = "Search by title:";
            // 
            // BTNAddNews
            // 
            BTNAddNews.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddNews.Location = new Point(34, 48);
            BTNAddNews.Margin = new Padding(5, 4, 5, 4);
            BTNAddNews.Name = "BTNAddNews";
            BTNAddNews.Size = new Size(167, 59);
            BTNAddNews.TabIndex = 20;
            BTNAddNews.Text = "Add news";
            BTNAddNews.UseVisualStyleBackColor = true;
            BTNAddNews.Click += BTNAddNews_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BTNAddNews);
            groupBox1.Location = new Point(16, 437);
            groupBox1.Margin = new Padding(5, 4, 5, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 4, 5, 4);
            groupBox1.Size = new Size(240, 179);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Actions";
            // 
            // DGVNews
            // 
            DGVNews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVNews.Location = new Point(392, 116);
            DGVNews.Name = "DGVNews";
            DGVNews.RowHeadersWidth = 51;
            DGVNews.Size = new Size(691, 320);
            DGVNews.TabIndex = 22;
            DGVNews.CellContentClick += DGVNews_CellContentClick;
            // 
            // CarNewsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DGVNews);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Margin = new Padding(5, 4, 5, 4);
            Name = "CarNewsUC";
            Size = new Size(1156, 667);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVNews).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBDESC;
        private System.Windows.Forms.RadioButton RBASC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BTNSearchByTitle;
        private System.Windows.Forms.TextBox TBNewsTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTNAddNews;
        private System.Windows.Forms.GroupBox groupBox1;
        private DataGridView DGVNews;
    }
}

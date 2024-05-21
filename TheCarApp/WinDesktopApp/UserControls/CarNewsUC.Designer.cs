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
            groupBox2.BackColor = Color.FromArgb(163, 177, 138);
            groupBox2.Controls.Add(RBDESC);
            groupBox2.Controls.Add(RBASC);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 9.75F);
            groupBox2.Location = new Point(14, 17);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(210, 96);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Show news";
            // 
            // RBDESC
            // 
            RBDESC.AutoSize = true;
            RBDESC.Location = new Point(118, 53);
            RBDESC.Margin = new Padding(4, 3, 4, 3);
            RBDESC.Name = "RBDESC";
            RBDESC.Size = new Size(58, 19);
            RBDESC.TabIndex = 16;
            RBDESC.TabStop = true;
            RBDESC.Text = "Desc";
            RBDESC.UseVisualStyleBackColor = true;
            RBDESC.CheckedChanged += RBDESC_CheckedChanged;
            // 
            // RBASC
            // 
            RBASC.AutoSize = true;
            RBASC.Location = new Point(31, 53);
            RBASC.Margin = new Padding(4, 3, 4, 3);
            RBASC.Name = "RBASC";
            RBASC.Size = new Size(49, 19);
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
            label4.Location = new Point(36, 27);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(110, 18);
            label4.TabIndex = 14;
            label4.Text = "Sort by date:";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(163, 177, 138);
            groupBox3.Controls.Add(BTNSearchByTitle);
            groupBox3.Controls.Add(TBNewsTitle);
            groupBox3.Controls.Add(label5);
            groupBox3.Font = new Font("Arial Rounded MT Bold", 9.75F);
            groupBox3.Location = new Point(14, 136);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(210, 158);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Search news";
            // 
            // BTNSearchByTitle
            // 
            BTNSearchByTitle.BackColor = Color.FromArgb(88, 129, 87);
            BTNSearchByTitle.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNSearchByTitle.ForeColor = Color.White;
            BTNSearchByTitle.Location = new Point(31, 95);
            BTNSearchByTitle.Margin = new Padding(4, 3, 4, 3);
            BTNSearchByTitle.Name = "BTNSearchByTitle";
            BTNSearchByTitle.Size = new Size(146, 50);
            BTNSearchByTitle.TabIndex = 19;
            BTNSearchByTitle.Text = "Search";
            BTNSearchByTitle.UseVisualStyleBackColor = false;
            BTNSearchByTitle.Click += BTNSearchByTitle_Click;
            // 
            // TBNewsTitle
            // 
            TBNewsTitle.Location = new Point(48, 65);
            TBNewsTitle.Margin = new Padding(4, 3, 4, 3);
            TBNewsTitle.Name = "TBNewsTitle";
            TBNewsTitle.Size = new Size(116, 23);
            TBNewsTitle.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F);
            label5.Location = new Point(36, 30);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(128, 18);
            label5.TabIndex = 17;
            label5.Text = "Search by title:";
            // 
            // BTNAddNews
            // 
            BTNAddNews.BackColor = Color.FromArgb(88, 129, 87);
            BTNAddNews.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddNews.ForeColor = Color.White;
            BTNAddNews.Location = new Point(31, 55);
            BTNAddNews.Margin = new Padding(4, 3, 4, 3);
            BTNAddNews.Name = "BTNAddNews";
            BTNAddNews.Size = new Size(146, 44);
            BTNAddNews.TabIndex = 20;
            BTNAddNews.Text = "Add news";
            BTNAddNews.UseVisualStyleBackColor = false;
            BTNAddNews.Click += BTNAddNews_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(163, 177, 138);
            groupBox1.Controls.Add(BTNAddNews);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 9.75F);
            groupBox1.Location = new Point(14, 328);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(210, 134);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Actions";
            // 
            // DGVNews
            // 
            DGVNews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVNews.Location = new Point(277, 104);
            DGVNews.Margin = new Padding(3, 2, 3, 2);
            DGVNews.Name = "DGVNews";
            DGVNews.RowHeadersWidth = 51;
            DGVNews.Size = new Size(802, 240);
            DGVNews.TabIndex = 22;
            DGVNews.CellContentClick += DGVNews_CellContentClick;
            // 
            // CarNewsUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            Controls.Add(DGVNews);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CarNewsUC";
            Size = new Size(1160, 500);
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

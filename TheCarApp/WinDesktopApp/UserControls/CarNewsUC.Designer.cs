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
            LBCarNews = new ListBox();
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
            BTNModifyNews = new Button();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // LBCarNews
            // 
            LBCarNews.FormattingEnabled = true;
            LBCarNews.ItemHeight = 15;
            LBCarNews.Location = new Point(267, 33);
            LBCarNews.Margin = new Padding(4, 3, 4, 3);
            LBCarNews.Name = "LBCarNews";
            LBCarNews.Size = new Size(318, 424);
            LBCarNews.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RBDESC);
            groupBox2.Controls.Add(RBASC);
            groupBox2.Controls.Add(label4);
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
            RBDESC.Size = new Size(50, 19);
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
            RBASC.Size = new Size(44, 19);
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
            groupBox3.Controls.Add(BTNSearchByTitle);
            groupBox3.Controls.Add(TBNewsTitle);
            groupBox3.Controls.Add(label5);
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
            BTNSearchByTitle.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNSearchByTitle.Location = new Point(31, 95);
            BTNSearchByTitle.Margin = new Padding(4, 3, 4, 3);
            BTNSearchByTitle.Name = "BTNSearchByTitle";
            BTNSearchByTitle.Size = new Size(146, 50);
            BTNSearchByTitle.TabIndex = 19;
            BTNSearchByTitle.Text = "Search";
            BTNSearchByTitle.UseVisualStyleBackColor = true;
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
            BTNAddNews.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddNews.Location = new Point(30, 36);
            BTNAddNews.Margin = new Padding(4, 3, 4, 3);
            BTNAddNews.Name = "BTNAddNews";
            BTNAddNews.Size = new Size(146, 40);
            BTNAddNews.TabIndex = 20;
            BTNAddNews.Text = "Add news";
            BTNAddNews.UseVisualStyleBackColor = true;
            BTNAddNews.Click += BTNAddNews_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BTNModifyNews);
            groupBox1.Controls.Add(BTNAddNews);
            groupBox1.Location = new Point(14, 328);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(210, 134);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Actions";
            // 
            // BTNModifyNews
            // 
            BTNModifyNews.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNModifyNews.Location = new Point(30, 83);
            BTNModifyNews.Margin = new Padding(4, 3, 4, 3);
            BTNModifyNews.Name = "BTNModifyNews";
            BTNModifyNews.Size = new Size(146, 40);
            BTNModifyNews.TabIndex = 21;
            BTNModifyNews.Text = "Modify news";
            BTNModifyNews.UseVisualStyleBackColor = true;
            BTNModifyNews.Click += BTNModifyNews_Click;
            // 
            // CarNewsUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(LBCarNews);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CarNewsUC";
            Size = new Size(623, 500);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ListBox LBCarNews;
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
        private System.Windows.Forms.Button BTNModifyNews;
    }
}

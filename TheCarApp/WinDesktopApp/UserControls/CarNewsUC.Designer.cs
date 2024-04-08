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
            this.LBCarNews = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBDESC = new System.Windows.Forms.RadioButton();
            this.RBASC = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BTNSearchByTitle = new System.Windows.Forms.Button();
            this.TBNewsTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BTNAddNews = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTNModifyNews = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBCarNews
            // 
            this.LBCarNews.FormattingEnabled = true;
            this.LBCarNews.Location = new System.Drawing.Point(229, 29);
            this.LBCarNews.Name = "LBCarNews";
            this.LBCarNews.Size = new System.Drawing.Size(273, 368);
            this.LBCarNews.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBDESC);
            this.groupBox2.Controls.Add(this.RBASC);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 83);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show news";
            // 
            // RBDESC
            // 
            this.RBDESC.AutoSize = true;
            this.RBDESC.Location = new System.Drawing.Point(101, 46);
            this.RBDESC.Name = "RBDESC";
            this.RBDESC.Size = new System.Drawing.Size(50, 17);
            this.RBDESC.TabIndex = 16;
            this.RBDESC.TabStop = true;
            this.RBDESC.Text = "Desc";
            this.RBDESC.UseVisualStyleBackColor = true;
            // 
            // RBASC
            // 
            this.RBASC.AutoSize = true;
            this.RBASC.Location = new System.Drawing.Point(27, 46);
            this.RBASC.Name = "RBASC";
            this.RBASC.Size = new System.Drawing.Size(43, 17);
            this.RBASC.TabIndex = 15;
            this.RBASC.TabStop = true;
            this.RBASC.Text = "Asc";
            this.RBASC.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label4.Location = new System.Drawing.Point(31, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Sort by date:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BTNSearchByTitle);
            this.groupBox3.Controls.Add(this.TBNewsTitle);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 137);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search news";
            // 
            // BTNSearchByTitle
            // 
            this.BTNSearchByTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BTNSearchByTitle.Location = new System.Drawing.Point(27, 82);
            this.BTNSearchByTitle.Name = "BTNSearchByTitle";
            this.BTNSearchByTitle.Size = new System.Drawing.Size(125, 43);
            this.BTNSearchByTitle.TabIndex = 19;
            this.BTNSearchByTitle.Text = "Search";
            this.BTNSearchByTitle.UseVisualStyleBackColor = true;
            // 
            // TBNewsTitle
            // 
            this.TBNewsTitle.Location = new System.Drawing.Point(41, 56);
            this.TBNewsTitle.Name = "TBNewsTitle";
            this.TBNewsTitle.Size = new System.Drawing.Size(100, 20);
            this.TBNewsTitle.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label5.Location = new System.Drawing.Point(31, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Search by title:";
            // 
            // BTNAddNews
            // 
            this.BTNAddNews.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BTNAddNews.Location = new System.Drawing.Point(26, 31);
            this.BTNAddNews.Name = "BTNAddNews";
            this.BTNAddNews.Size = new System.Drawing.Size(125, 35);
            this.BTNAddNews.TabIndex = 20;
            this.BTNAddNews.Text = "Add news";
            this.BTNAddNews.UseVisualStyleBackColor = true;
            this.BTNAddNews.Click += new System.EventHandler(this.BTNAddNews_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTNModifyNews);
            this.groupBox1.Controls.Add(this.BTNAddNews);
            this.groupBox1.Location = new System.Drawing.Point(12, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 116);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // BTNModifyNews
            // 
            this.BTNModifyNews.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BTNModifyNews.Location = new System.Drawing.Point(26, 72);
            this.BTNModifyNews.Name = "BTNModifyNews";
            this.BTNModifyNews.Size = new System.Drawing.Size(125, 35);
            this.BTNModifyNews.TabIndex = 21;
            this.BTNModifyNews.Text = "Modify news";
            this.BTNModifyNews.UseVisualStyleBackColor = true;
            this.BTNModifyNews.Click += new System.EventHandler(this.BTNModifyNews_Click);
            // 
            // CarNewsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LBCarNews);
            this.Name = "CarNewsUC";
            this.Size = new System.Drawing.Size(534, 433);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

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

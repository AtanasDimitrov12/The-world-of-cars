namespace WinDesktopApp.UserControls
{
    partial class CommentsControlUC
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
            groupBox1 = new GroupBox();
            BTNShowAll = new Button();
            BTNSearch = new Button();
            CBNews = new ComboBox();
            DGVComments = new DataGridView();
            groupBox2 = new GroupBox();
            RBASC = new RadioButton();
            RBDESC = new RadioButton();
            label4 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVComments).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(163, 177, 138);
            groupBox1.Controls.Add(BTNShowAll);
            groupBox1.Controls.Add(BTNSearch);
            groupBox1.Controls.Add(CBNews);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox1.Location = new Point(59, 80);
            groupBox1.Margin = new Padding(5, 4, 5, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 4, 5, 4);
            groupBox1.Size = new Size(290, 253);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search per news";
            // 
            // BTNShowAll
            // 
            BTNShowAll.BackColor = Color.FromArgb(88, 129, 87);
            BTNShowAll.ForeColor = Color.White;
            BTNShowAll.Location = new Point(64, 186);
            BTNShowAll.Margin = new Padding(5, 4, 5, 4);
            BTNShowAll.Name = "BTNShowAll";
            BTNShowAll.Size = new Size(167, 59);
            BTNShowAll.TabIndex = 2;
            BTNShowAll.Text = "Show all";
            BTNShowAll.UseVisualStyleBackColor = false;
            BTNShowAll.Click += BTNShowAll_Click;
            // 
            // BTNSearch
            // 
            BTNSearch.BackColor = Color.FromArgb(88, 129, 87);
            BTNSearch.ForeColor = Color.White;
            BTNSearch.Location = new Point(64, 119);
            BTNSearch.Margin = new Padding(5, 4, 5, 4);
            BTNSearch.Name = "BTNSearch";
            BTNSearch.Size = new Size(167, 59);
            BTNSearch.TabIndex = 1;
            BTNSearch.Text = "Search";
            BTNSearch.UseVisualStyleBackColor = false;
            BTNSearch.Click += BTNSearch_Click;
            // 
            // CBNews
            // 
            CBNews.FormattingEnabled = true;
            CBNews.Location = new Point(23, 61);
            CBNews.Margin = new Padding(5, 4, 5, 4);
            CBNews.Name = "CBNews";
            CBNews.Size = new Size(249, 31);
            CBNews.TabIndex = 0;
            // 
            // DGVComments
            // 
            DGVComments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVComments.Location = new Point(387, 80);
            DGVComments.Margin = new Padding(3, 4, 3, 4);
            DGVComments.Name = "DGVComments";
            DGVComments.RowHeadersWidth = 51;
            DGVComments.Size = new Size(997, 493);
            DGVComments.TabIndex = 3;
            DGVComments.CellContentClick += DGVComments_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(163, 177, 138);
            groupBox2.Controls.Add(RBASC);
            groupBox2.Controls.Add(RBDESC);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox2.Location = new Point(59, 376);
            groupBox2.Margin = new Padding(5, 4, 5, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 4, 5, 4);
            groupBox2.Size = new Size(290, 197);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Show comments";
            // 
            // RBASC
            // 
            RBASC.AutoSize = true;
            RBASC.Location = new Point(50, 121);
            RBASC.Margin = new Padding(5, 4, 5, 4);
            RBASC.Name = "RBASC";
            RBASC.Size = new Size(73, 27);
            RBASC.TabIndex = 16;
            RBASC.TabStop = true;
            RBASC.Text = "ASC";
            RBASC.UseVisualStyleBackColor = true;
            RBASC.CheckedChanged += RBASC_CheckedChanged;
            // 
            // RBDESC
            // 
            RBDESC.AutoSize = true;
            RBDESC.Location = new Point(159, 121);
            RBDESC.Margin = new Padding(5, 4, 5, 4);
            RBDESC.Name = "RBDESC";
            RBDESC.Size = new Size(87, 27);
            RBDESC.TabIndex = 15;
            RBDESC.TabStop = true;
            RBDESC.Text = "DESC";
            RBDESC.UseVisualStyleBackColor = true;
            RBDESC.CheckedChanged += RBDESC_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F);
            label4.Location = new Point(75, 59);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(135, 23);
            label4.TabIndex = 14;
            label4.Text = "Sort by date:";
            // 
            // CommentsControlUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            Controls.Add(groupBox2);
            Controls.Add(DGVComments);
            Controls.Add(groupBox1);
            Margin = new Padding(5, 4, 5, 4);
            Name = "CommentsControlUC";
            Size = new Size(1463, 689);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVComments).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTNSearch;
        private System.Windows.Forms.ComboBox CBNews;
        private DataGridView DGVComments;
        private GroupBox groupBox2;
        private RadioButton RBASC;
        private RadioButton RBDESC;
        private Label label4;
        private Button BTNShowAll;
    }
}

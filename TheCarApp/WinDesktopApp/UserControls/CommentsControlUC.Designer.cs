namespace DesktopApp
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
            groupBox1.Controls.Add(BTNSearch);
            groupBox1.Controls.Add(CBNews);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox1.Location = new Point(146, 75);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(254, 151);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search per news";
            // 
            // BTNSearch
            // 
            BTNSearch.BackColor = Color.FromArgb(88, 129, 87);
            BTNSearch.ForeColor = Color.White;
            BTNSearch.Location = new Point(44, 90);
            BTNSearch.Margin = new Padding(4, 3, 4, 3);
            BTNSearch.Name = "BTNSearch";
            BTNSearch.Size = new Size(168, 37);
            BTNSearch.TabIndex = 1;
            BTNSearch.Text = "Search";
            BTNSearch.UseVisualStyleBackColor = false;
            BTNSearch.Click += BTNSearch_Click;
            // 
            // CBNews
            // 
            CBNews.FormattingEnabled = true;
            CBNews.Location = new Point(20, 46);
            CBNews.Margin = new Padding(4, 3, 4, 3);
            CBNews.Name = "CBNews";
            CBNews.Size = new Size(218, 26);
            CBNews.TabIndex = 0;
            // 
            // DGVComments
            // 
            DGVComments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVComments.Location = new Point(451, 75);
            DGVComments.Name = "DGVComments";
            DGVComments.Size = new Size(687, 339);
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
            groupBox2.Location = new Point(146, 251);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(254, 148);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Show comments";
            // 
            // RBASC
            // 
            RBASC.AutoSize = true;
            RBASC.Location = new Point(54, 91);
            RBASC.Margin = new Padding(4, 3, 4, 3);
            RBASC.Name = "RBASC";
            RBASC.Size = new Size(61, 22);
            RBASC.TabIndex = 16;
            RBASC.TabStop = true;
            RBASC.Text = "ASC";
            RBASC.UseVisualStyleBackColor = true;
            RBASC.CheckedChanged += RBASC_CheckedChanged;
            // 
            // RBDESC
            // 
            RBDESC.AutoSize = true;
            RBDESC.Location = new Point(139, 91);
            RBDESC.Margin = new Padding(4, 3, 4, 3);
            RBDESC.Name = "RBDESC";
            RBDESC.Size = new Size(72, 22);
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
            label4.Location = new Point(79, 48);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(110, 18);
            label4.TabIndex = 14;
            label4.Text = "Sort by date:";
            // 
            // CommentsControlUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            Controls.Add(groupBox2);
            Controls.Add(DGVComments);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CommentsControlUC";
            Size = new Size(1160, 502);
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
    }
}

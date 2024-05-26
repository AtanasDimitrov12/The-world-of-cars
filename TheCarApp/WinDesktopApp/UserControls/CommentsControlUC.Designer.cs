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
            groupBox2 = new GroupBox();
            label1 = new Label();
            DGVComments = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVComments).BeginInit();
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
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(163, 177, 138);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox2.Location = new Point(146, 258);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(254, 151);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Delete comment";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 53);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(184, 15);
            label1.TabIndex = 2;
            label1.Text = "Select and press the button";
            label1.Click += label1_Click;
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
            // CommentsControlUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            Controls.Add(DGVComments);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CommentsControlUC";
            Size = new Size(1160, 502);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVComments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTNSearch;
        private System.Windows.Forms.ComboBox CBNews;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private DataGridView DGVComments;
    }
}

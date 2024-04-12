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
            LBComments = new ListBox();
            groupBox2 = new GroupBox();
            label1 = new Label();
            BTNDelete = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BTNSearch);
            groupBox1.Controls.Add(CBNews);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox1.Location = new Point(35, 87);
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
            BTNSearch.Location = new Point(44, 90);
            BTNSearch.Margin = new Padding(4, 3, 4, 3);
            BTNSearch.Name = "BTNSearch";
            BTNSearch.Size = new Size(168, 37);
            BTNSearch.TabIndex = 1;
            BTNSearch.Text = "Search";
            BTNSearch.UseVisualStyleBackColor = true;
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
            // LBComments
            // 
            LBComments.FormattingEnabled = true;
            LBComments.ItemHeight = 15;
            LBComments.Location = new Point(326, 25);
            LBComments.Margin = new Padding(4, 3, 4, 3);
            LBComments.Name = "LBComments";
            LBComments.Size = new Size(355, 439);
            LBComments.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(BTNDelete);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox2.Location = new Point(35, 257);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(254, 151);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Delete news";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 54);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(158, 12);
            label1.TabIndex = 2;
            label1.Text = "Select and press the button";
            label1.Click += label1_Click;
            // 
            // BTNDelete
            // 
            BTNDelete.Location = new Point(44, 90);
            BTNDelete.Margin = new Padding(4, 3, 4, 3);
            BTNDelete.Name = "BTNDelete";
            BTNDelete.Size = new Size(168, 37);
            BTNDelete.TabIndex = 1;
            BTNDelete.Text = "Delete";
            BTNDelete.UseVisualStyleBackColor = true;
            BTNDelete.Click += BTNDelete_Click;
            // 
            // CommentsControlUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(LBComments);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CommentsControlUC";
            Size = new Size(718, 489);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTNSearch;
        private System.Windows.Forms.ComboBox CBNews;
        private System.Windows.Forms.ListBox LBComments;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNDelete;
    }
}

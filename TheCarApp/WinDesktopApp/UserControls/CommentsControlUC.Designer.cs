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
            groupBox1.Location = new Point(40, 116);
            groupBox1.Margin = new Padding(5, 4, 5, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 4, 5, 4);
            groupBox1.Size = new Size(290, 201);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search per news";
            // 
            // BTNSearch
            // 
            BTNSearch.Location = new Point(50, 120);
            BTNSearch.Margin = new Padding(5, 4, 5, 4);
            BTNSearch.Name = "BTNSearch";
            BTNSearch.Size = new Size(192, 49);
            BTNSearch.TabIndex = 1;
            BTNSearch.Text = "Search";
            BTNSearch.UseVisualStyleBackColor = true;
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
            // LBComments
            // 
            LBComments.FormattingEnabled = true;
            LBComments.Location = new Point(373, 33);
            LBComments.Margin = new Padding(5, 4, 5, 4);
            LBComments.Name = "LBComments";
            LBComments.Size = new Size(405, 584);
            LBComments.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(BTNDelete);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox2.Location = new Point(40, 343);
            groupBox2.Margin = new Padding(5, 4, 5, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 4, 5, 4);
            groupBox2.Size = new Size(290, 201);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Delete comment";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 72);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(193, 16);
            label1.TabIndex = 2;
            label1.Text = "Select and press the button";
            label1.Click += label1_Click;
            // 
            // BTNDelete
            // 
            BTNDelete.Location = new Point(50, 120);
            BTNDelete.Margin = new Padding(5, 4, 5, 4);
            BTNDelete.Name = "BTNDelete";
            BTNDelete.Size = new Size(192, 49);
            BTNDelete.TabIndex = 1;
            BTNDelete.Text = "Delete";
            BTNDelete.UseVisualStyleBackColor = true;
            BTNDelete.Click += BTNDelete_Click;
            // 
            // CommentsControlUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(LBComments);
            Controls.Add(groupBox1);
            Margin = new Padding(5, 4, 5, 4);
            Name = "CommentsControlUC";
            Size = new Size(821, 652);
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

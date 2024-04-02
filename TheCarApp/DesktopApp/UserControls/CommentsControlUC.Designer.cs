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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTNSearch = new System.Windows.Forms.Button();
            this.CBNews = new System.Windows.Forms.ComboBox();
            this.LBComments = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTNSearch);
            this.groupBox1.Controls.Add(this.CBNews);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.groupBox1.Location = new System.Drawing.Point(30, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search per news";
            // 
            // BTNSearch
            // 
            this.BTNSearch.Location = new System.Drawing.Point(38, 78);
            this.BTNSearch.Name = "BTNSearch";
            this.BTNSearch.Size = new System.Drawing.Size(144, 32);
            this.BTNSearch.TabIndex = 1;
            this.BTNSearch.Text = "Search";
            this.BTNSearch.UseVisualStyleBackColor = true;
            // 
            // CBNews
            // 
            this.CBNews.FormattingEnabled = true;
            this.CBNews.Location = new System.Drawing.Point(17, 40);
            this.CBNews.Name = "CBNews";
            this.CBNews.Size = new System.Drawing.Size(187, 26);
            this.CBNews.TabIndex = 0;
            // 
            // LBComments
            // 
            this.LBComments.FormattingEnabled = true;
            this.LBComments.Location = new System.Drawing.Point(279, 22);
            this.LBComments.Name = "LBComments";
            this.LBComments.Size = new System.Drawing.Size(305, 381);
            this.LBComments.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.BTNDelete);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.groupBox2.Location = new System.Drawing.Point(30, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 131);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete news";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select and press the button";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BTNDelete
            // 
            this.BTNDelete.Location = new System.Drawing.Point(38, 78);
            this.BTNDelete.Name = "BTNDelete";
            this.BTNDelete.Size = new System.Drawing.Size(144, 32);
            this.BTNDelete.TabIndex = 1;
            this.BTNDelete.Text = "Delete";
            this.BTNDelete.UseVisualStyleBackColor = true;
            // 
            // CommentsControlUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LBComments);
            this.Controls.Add(this.groupBox1);
            this.Name = "CommentsControlUC";
            this.Size = new System.Drawing.Size(615, 424);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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

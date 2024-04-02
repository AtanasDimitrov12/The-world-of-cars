namespace DesktopApp
{
    partial class AddNews
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBNewsImageURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBNewsAuthor = new System.Windows.Forms.TextBox();
            this.BTNAdd = new System.Windows.Forms.Button();
            this.RTBNewsDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RTBNewsIntro = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBNewsTitle = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TBNewsImageURL);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TBNewsAuthor);
            this.groupBox1.Controls.Add(this.BTNAdd);
            this.groupBox1.Controls.Add(this.RTBNewsDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.RTBNewsIntro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TBNewsTitle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 242);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new news";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label5.Location = new System.Drawing.Point(9, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Image URL:";
            // 
            // TBNewsImageURL
            // 
            this.TBNewsImageURL.Location = new System.Drawing.Point(113, 94);
            this.TBNewsImageURL.Name = "TBNewsImageURL";
            this.TBNewsImageURL.Size = new System.Drawing.Size(264, 20);
            this.TBNewsImageURL.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label4.Location = new System.Drawing.Point(9, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Author:";
            // 
            // TBNewsAuthor
            // 
            this.TBNewsAuthor.Location = new System.Drawing.Point(113, 61);
            this.TBNewsAuthor.Name = "TBNewsAuthor";
            this.TBNewsAuthor.Size = new System.Drawing.Size(100, 20);
            this.TBNewsAuthor.TabIndex = 15;
            // 
            // BTNAdd
            // 
            this.BTNAdd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BTNAdd.Location = new System.Drawing.Point(482, 139);
            this.BTNAdd.Name = "BTNAdd";
            this.BTNAdd.Size = new System.Drawing.Size(107, 86);
            this.BTNAdd.TabIndex = 14;
            this.BTNAdd.Text = "Add";
            this.BTNAdd.UseVisualStyleBackColor = true;
            this.BTNAdd.Click += new System.EventHandler(this.BTNAdd_Click);
            // 
            // RTBNewsDescription
            // 
            this.RTBNewsDescription.Location = new System.Drawing.Point(98, 139);
            this.RTBNewsDescription.Name = "RTBNewsDescription";
            this.RTBNewsDescription.Size = new System.Drawing.Size(354, 86);
            this.RTBNewsDescription.TabIndex = 13;
            this.RTBNewsDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label3.Location = new System.Drawing.Point(9, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "News:";
            // 
            // RTBNewsIntro
            // 
            this.RTBNewsIntro.Location = new System.Drawing.Point(392, 21);
            this.RTBNewsIntro.Name = "RTBNewsIntro";
            this.RTBNewsIntro.Size = new System.Drawing.Size(197, 72);
            this.RTBNewsIntro.TabIndex = 11;
            this.RTBNewsIntro.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.Location = new System.Drawing.Point(279, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Short intro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Title:";
            // 
            // TBNewsTitle
            // 
            this.TBNewsTitle.Location = new System.Drawing.Point(113, 30);
            this.TBNewsTitle.Name = "TBNewsTitle";
            this.TBNewsTitle.Size = new System.Drawing.Size(100, 20);
            this.TBNewsTitle.TabIndex = 8;
            // 
            // AddNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 267);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddNews";
            this.Text = "AddNews";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTNAdd;
        private System.Windows.Forms.RichTextBox RTBNewsDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox RTBNewsIntro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBNewsTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBNewsImageURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBNewsAuthor;
    }
}
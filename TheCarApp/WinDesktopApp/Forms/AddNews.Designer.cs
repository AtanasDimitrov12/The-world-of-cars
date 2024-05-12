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
            groupBox1 = new GroupBox();
            label5 = new Label();
            TBNewsImageURL = new TextBox();
            label4 = new Label();
            TBNewsAuthor = new TextBox();
            BTNAdd = new Button();
            RTBNewsDescription = new RichTextBox();
            label3 = new Label();
            RTBNewsIntro = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            TBNewsTitle = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(TBNewsImageURL);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(TBNewsAuthor);
            groupBox1.Controls.Add(BTNAdd);
            groupBox1.Controls.Add(RTBNewsDescription);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(RTBNewsIntro);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(TBNewsTitle);
            groupBox1.Location = new Point(16, 18);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(797, 372);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add new news";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F);
            label5.Location = new Point(12, 145);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(123, 23);
            label5.TabIndex = 18;
            label5.Text = "Image URL:";
            // 
            // TBNewsImageURL
            // 
            TBNewsImageURL.Location = new Point(151, 145);
            TBNewsImageURL.Margin = new Padding(4, 5, 4, 5);
            TBNewsImageURL.Name = "TBNewsImageURL";
            TBNewsImageURL.Size = new Size(351, 27);
            TBNewsImageURL.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F);
            label4.Location = new Point(12, 94);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(82, 23);
            label4.TabIndex = 16;
            label4.Text = "Author:";
            // 
            // TBNewsAuthor
            // 
            TBNewsAuthor.Location = new Point(151, 94);
            TBNewsAuthor.Margin = new Padding(4, 5, 4, 5);
            TBNewsAuthor.Name = "TBNewsAuthor";
            TBNewsAuthor.Size = new Size(178, 27);
            TBNewsAuthor.TabIndex = 15;
            // 
            // BTNAdd
            // 
            BTNAdd.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAdd.Location = new Point(643, 214);
            BTNAdd.Margin = new Padding(4, 5, 4, 5);
            BTNAdd.Name = "BTNAdd";
            BTNAdd.Size = new Size(143, 132);
            BTNAdd.TabIndex = 14;
            BTNAdd.Text = "Add";
            BTNAdd.UseVisualStyleBackColor = true;
            BTNAdd.Click += BTNAdd_Click;
            // 
            // RTBNewsDescription
            // 
            RTBNewsDescription.Location = new Point(131, 214);
            RTBNewsDescription.Margin = new Padding(4, 5, 4, 5);
            RTBNewsDescription.Name = "RTBNewsDescription";
            RTBNewsDescription.Size = new Size(471, 130);
            RTBNewsDescription.TabIndex = 13;
            RTBNewsDescription.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 12F);
            label3.Location = new Point(12, 249);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 23);
            label3.TabIndex = 12;
            label3.Text = "News:";
            // 
            // RTBNewsIntro
            // 
            RTBNewsIntro.Location = new Point(523, 32);
            RTBNewsIntro.Margin = new Padding(4, 5, 4, 5);
            RTBNewsIntro.Name = "RTBNewsIntro";
            RTBNewsIntro.Size = new Size(261, 109);
            RTBNewsIntro.TabIndex = 11;
            RTBNewsIntro.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(372, 63);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 23);
            label1.TabIndex = 10;
            label1.Text = "Short intro:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F);
            label2.Location = new Point(12, 46);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 23);
            label2.TabIndex = 9;
            label2.Text = "Title:";
            // 
            // TBNewsTitle
            // 
            TBNewsTitle.Location = new Point(151, 46);
            TBNewsTitle.Margin = new Padding(4, 5, 4, 5);
            TBNewsTitle.Name = "TBNewsTitle";
            TBNewsTitle.Size = new Size(178, 27);
            TBNewsTitle.TabIndex = 8;
            // 
            // AddNews
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 411);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AddNews";
            Text = "AddNews";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
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
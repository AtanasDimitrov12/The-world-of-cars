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
            pictureBoxNewsImage = new PictureBox();
            btnBrowseImage = new Button();
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
            ((System.ComponentModel.ISupportInitialize)pictureBoxNewsImage).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBoxNewsImage);
            groupBox1.Controls.Add(btnBrowseImage);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(TBNewsAuthor);
            groupBox1.Controls.Add(BTNAdd);
            groupBox1.Controls.Add(RTBNewsDescription);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(RTBNewsIntro);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(TBNewsTitle);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 9.75F);
            groupBox1.Location = new Point(16, 19);
            groupBox1.Margin = new Padding(5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5);
            groupBox1.Size = new Size(1067, 486);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add new news";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // pictureBoxNewsImage
            // 
            pictureBoxNewsImage.Location = new Point(270, 307);
            pictureBoxNewsImage.Name = "pictureBoxNewsImage";
            pictureBoxNewsImage.Size = new Size(267, 159);
            pictureBoxNewsImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxNewsImage.TabIndex = 18;
            pictureBoxNewsImage.TabStop = false;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.BackColor = Color.FromArgb(88, 129, 87);
            btnBrowseImage.Font = new Font("Arial Rounded MT Bold", 12F);
            btnBrowseImage.ForeColor = Color.White;
            btnBrowseImage.Location = new Point(11, 344);
            btnBrowseImage.Margin = new Padding(5);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(164, 72);
            btnBrowseImage.TabIndex = 17;
            btnBrowseImage.Text = "Add picture";
            btnBrowseImage.UseVisualStyleBackColor = false;
            btnBrowseImage.Click += btnBrowseImage_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F);
            label4.Location = new Point(11, 93);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(82, 23);
            label4.TabIndex = 16;
            label4.Text = "Author:";
            // 
            // TBNewsAuthor
            // 
            TBNewsAuthor.Location = new Point(131, 94);
            TBNewsAuthor.Margin = new Padding(5);
            TBNewsAuthor.Name = "TBNewsAuthor";
            TBNewsAuthor.Size = new Size(214, 26);
            TBNewsAuthor.TabIndex = 15;
            TBNewsAuthor.TextChanged += TBNewsAuthor_TextChanged_1;
            // 
            // BTNAdd
            // 
            BTNAdd.BackColor = Color.FromArgb(88, 129, 87);
            BTNAdd.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAdd.ForeColor = Color.White;
            BTNAdd.Location = new Point(894, 344);
            BTNAdd.Margin = new Padding(5);
            BTNAdd.Name = "BTNAdd";
            BTNAdd.Size = new Size(143, 132);
            BTNAdd.TabIndex = 14;
            BTNAdd.Text = "Add";
            BTNAdd.UseVisualStyleBackColor = false;
            BTNAdd.Click += BTNAdd_Click;
            // 
            // RTBNewsDescription
            // 
            RTBNewsDescription.Location = new Point(131, 154);
            RTBNewsDescription.Margin = new Padding(5);
            RTBNewsDescription.Name = "RTBNewsDescription";
            RTBNewsDescription.Size = new Size(897, 129);
            RTBNewsDescription.TabIndex = 13;
            RTBNewsDescription.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 12F);
            label3.Location = new Point(11, 190);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 23);
            label3.TabIndex = 12;
            label3.Text = "News:";
            // 
            // RTBNewsIntro
            // 
            RTBNewsIntro.Location = new Point(523, 32);
            RTBNewsIntro.Margin = new Padding(5);
            RTBNewsIntro.Name = "RTBNewsIntro";
            RTBNewsIntro.Size = new Size(505, 109);
            RTBNewsIntro.TabIndex = 11;
            RTBNewsIntro.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(373, 63);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 23);
            label1.TabIndex = 10;
            label1.Text = "Short intro:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F);
            label2.Location = new Point(11, 45);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 23);
            label2.TabIndex = 9;
            label2.Text = "Title:";
            // 
            // TBNewsTitle
            // 
            TBNewsTitle.Location = new Point(131, 45);
            TBNewsTitle.Margin = new Padding(5);
            TBNewsTitle.Name = "TBNewsTitle";
            TBNewsTitle.Size = new Size(214, 26);
            TBNewsTitle.TabIndex = 8;
            TBNewsTitle.TextChanged += TBNewsTitle_TextChanged;
            // 
            // AddNews
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(1097, 519);
            Controls.Add(groupBox1);
            Margin = new Padding(5);
            Name = "AddNews";
            Text = "AddNews";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNewsImage).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBNewsAuthor;
        private PictureBox pictureBoxNewsImage;
        private Button btnBrowseImage;
    }
}
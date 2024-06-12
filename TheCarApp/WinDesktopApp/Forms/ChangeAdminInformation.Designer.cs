namespace WinDesktopApp.Forms
{
    partial class ChangeAdminInformation
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
            BTNUpdateAdminInfo = new Button();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label7 = new Label();
            TBAdminUsername = new TextBox();
            TBAdminEmail = new TextBox();
            TBAdminPassword = new TextBox();
            TBAdminPhoneNumber = new TextBox();
            pictureBox1 = new PictureBox();
            BTNClose = new Button();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // BTNUpdateAdminInfo
            // 
            BTNUpdateAdminInfo.BackColor = Color.FromArgb(88, 129, 87);
            BTNUpdateAdminInfo.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNUpdateAdminInfo.ForeColor = Color.White;
            BTNUpdateAdminInfo.Location = new Point(45, 313);
            BTNUpdateAdminInfo.Margin = new Padding(5, 4, 5, 4);
            BTNUpdateAdminInfo.Name = "BTNUpdateAdminInfo";
            BTNUpdateAdminInfo.Size = new Size(133, 57);
            BTNUpdateAdminInfo.TabIndex = 8;
            BTNUpdateAdminInfo.Text = "Update";
            BTNUpdateAdminInfo.UseVisualStyleBackColor = false;
            BTNUpdateAdminInfo.Click += BTNUpdateAdminInfo_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 12F);
            label6.Location = new Point(33, 244);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(158, 23);
            label6.TabIndex = 17;
            label6.Text = "Phone number:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F);
            label5.Location = new Point(33, 40);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(117, 23);
            label5.TabIndex = 16;
            label5.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 12F);
            label3.Location = new Point(33, 112);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(69, 23);
            label3.TabIndex = 15;
            label3.Text = "Email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 12F);
            label7.Location = new Point(33, 176);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(113, 23);
            label7.TabIndex = 18;
            label7.Text = "Password:";
            // 
            // TBAdminUsername
            // 
            TBAdminUsername.Location = new Point(158, 41);
            TBAdminUsername.Margin = new Padding(3, 4, 3, 4);
            TBAdminUsername.Name = "TBAdminUsername";
            TBAdminUsername.Size = new Size(175, 26);
            TBAdminUsername.TabIndex = 19;
            // 
            // TBAdminEmail
            // 
            TBAdminEmail.Location = new Point(119, 113);
            TBAdminEmail.Margin = new Padding(3, 4, 3, 4);
            TBAdminEmail.Name = "TBAdminEmail";
            TBAdminEmail.Size = new Size(214, 26);
            TBAdminEmail.TabIndex = 20;
            // 
            // TBAdminPassword
            // 
            TBAdminPassword.Location = new Point(150, 177);
            TBAdminPassword.Margin = new Padding(3, 4, 3, 4);
            TBAdminPassword.Name = "TBAdminPassword";
            TBAdminPassword.Size = new Size(183, 26);
            TBAdminPassword.TabIndex = 21;
            // 
            // TBAdminPhoneNumber
            // 
            TBAdminPhoneNumber.Location = new Point(188, 244);
            TBAdminPhoneNumber.Margin = new Padding(3, 4, 3, 4);
            TBAdminPhoneNumber.Name = "TBAdminPhoneNumber";
            TBAdminPhoneNumber.Size = new Size(145, 26);
            TBAdminPhoneNumber.TabIndex = 22;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_transparent;
            pictureBox1.Location = new Point(512, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(383, 405);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // BTNClose
            // 
            BTNClose.BackColor = Color.FromArgb(88, 129, 87);
            BTNClose.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNClose.ForeColor = Color.White;
            BTNClose.Location = new Point(200, 313);
            BTNClose.Margin = new Padding(5, 4, 5, 4);
            BTNClose.Name = "BTNClose";
            BTNClose.Size = new Size(133, 57);
            BTNClose.TabIndex = 24;
            BTNClose.Text = "Close";
            BTNClose.UseVisualStyleBackColor = false;
            BTNClose.Click += BTNClose_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(163, 177, 138);
            groupBox2.Controls.Add(TBAdminPhoneNumber);
            groupBox2.Controls.Add(BTNClose);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(BTNUpdateAdminInfo);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(TBAdminPassword);
            groupBox2.Controls.Add(TBAdminUsername);
            groupBox2.Controls.Add(TBAdminEmail);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 9.75F);
            groupBox2.Location = new Point(35, 43);
            groupBox2.Margin = new Padding(5, 4, 5, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 4, 5, 4);
            groupBox2.Size = new Size(367, 378);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Show admin info";
            // 
            // ChangeAdminInformation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(999, 509);
            Controls.Add(groupBox2);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChangeAdminInformation";
            Text = "ChangeAdminInformation";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button BTNUpdateAdminInfo;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label7;
        private TextBox TBAdminUsername;
        private TextBox TBAdminEmail;
        private TextBox TBAdminPassword;
        private TextBox TBAdminPhoneNumber;
        private PictureBox pictureBox1;
        private Button BTNClose;
        private GroupBox groupBox2;
    }
}
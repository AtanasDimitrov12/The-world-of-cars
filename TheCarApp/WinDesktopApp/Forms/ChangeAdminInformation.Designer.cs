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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BTNUpdateAdminInfo
            // 
            BTNUpdateAdminInfo.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNUpdateAdminInfo.Location = new Point(105, 273);
            BTNUpdateAdminInfo.Margin = new Padding(4, 3, 4, 3);
            BTNUpdateAdminInfo.Name = "BTNUpdateAdminInfo";
            BTNUpdateAdminInfo.Size = new Size(116, 43);
            BTNUpdateAdminInfo.TabIndex = 8;
            BTNUpdateAdminInfo.Text = "Update";
            BTNUpdateAdminInfo.UseVisualStyleBackColor = true;
            BTNUpdateAdminInfo.Click += BTNUpdateAdminInfo_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 12F);
            label6.Location = new Point(42, 212);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(129, 18);
            label6.TabIndex = 17;
            label6.Text = "Phone number:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F);
            label5.Location = new Point(42, 59);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(95, 18);
            label5.TabIndex = 16;
            label5.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 12F);
            label3.Location = new Point(42, 113);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 18);
            label3.TabIndex = 15;
            label3.Text = "Email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 12F);
            label7.Location = new Point(42, 161);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(92, 18);
            label7.TabIndex = 18;
            label7.Text = "Password:";
            // 
            // TBAdminUsername
            // 
            TBAdminUsername.Location = new Point(144, 59);
            TBAdminUsername.Name = "TBAdminUsername";
            TBAdminUsername.Size = new Size(127, 23);
            TBAdminUsername.TabIndex = 19;
            // 
            // TBAdminEmail
            // 
            TBAdminEmail.Location = new Point(105, 113);
            TBAdminEmail.Name = "TBAdminEmail";
            TBAdminEmail.Size = new Size(127, 23);
            TBAdminEmail.TabIndex = 20;
            // 
            // TBAdminPassword
            // 
            TBAdminPassword.Location = new Point(141, 161);
            TBAdminPassword.Name = "TBAdminPassword";
            TBAdminPassword.Size = new Size(127, 23);
            TBAdminPassword.TabIndex = 21;
            // 
            // TBAdminPhoneNumber
            // 
            TBAdminPhoneNumber.Location = new Point(178, 212);
            TBAdminPhoneNumber.Name = "TBAdminPhoneNumber";
            TBAdminPhoneNumber.Size = new Size(127, 23);
            TBAdminPhoneNumber.TabIndex = 22;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_transparent;
            pictureBox1.Location = new Point(448, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(335, 304);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // ChangeAdminInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 382);
            Controls.Add(pictureBox1);
            Controls.Add(BTNUpdateAdminInfo);
            Controls.Add(TBAdminPhoneNumber);
            Controls.Add(TBAdminPassword);
            Controls.Add(TBAdminEmail);
            Controls.Add(TBAdminUsername);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Name = "ChangeAdminInformation";
            Text = "ChangeAdminInformation";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}
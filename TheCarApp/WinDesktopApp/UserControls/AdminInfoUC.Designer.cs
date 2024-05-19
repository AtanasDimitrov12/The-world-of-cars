namespace DesktopApp
{
    partial class AdminInfoUC
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
            groupBox2 = new GroupBox();
            BTNChangeAdminInfo = new Button();
            LBLAdminPhoneNumber = new Label();
            LBLAdminEmail = new Label();
            LBLAdminUsername = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BTNChangeAdminInfo);
            groupBox2.Controls.Add(LBLAdminPhoneNumber);
            groupBox2.Controls.Add(LBLAdminEmail);
            groupBox2.Controls.Add(LBLAdminUsername);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox2.Location = new Point(286, 82);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(279, 302);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Admin Info";
            // 
            // BTNChangeAdminInfo
            // 
            BTNChangeAdminInfo.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNChangeAdminInfo.Location = new Point(77, 212);
            BTNChangeAdminInfo.Name = "BTNChangeAdminInfo";
            BTNChangeAdminInfo.Size = new Size(115, 64);
            BTNChangeAdminInfo.TabIndex = 15;
            BTNChangeAdminInfo.Text = "Change information";
            BTNChangeAdminInfo.UseVisualStyleBackColor = true;
            BTNChangeAdminInfo.Click += BTNChangeAdminInfo_Click;
            // 
            // LBLAdminPhoneNumber
            // 
            LBLAdminPhoneNumber.AutoSize = true;
            LBLAdminPhoneNumber.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBLAdminPhoneNumber.Location = new Point(145, 161);
            LBLAdminPhoneNumber.Name = "LBLAdminPhoneNumber";
            LBLAdminPhoneNumber.Size = new Size(47, 15);
            LBLAdminPhoneNumber.TabIndex = 14;
            LBLAdminPhoneNumber.Text = "label9";
            // 
            // LBLAdminEmail
            // 
            LBLAdminEmail.AutoSize = true;
            LBLAdminEmail.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBLAdminEmail.Location = new Point(82, 104);
            LBLAdminEmail.Name = "LBLAdminEmail";
            LBLAdminEmail.Size = new Size(47, 15);
            LBLAdminEmail.TabIndex = 13;
            LBLAdminEmail.Text = "label8";
            // 
            // LBLAdminUsername
            // 
            LBLAdminUsername.AutoSize = true;
            LBLAdminUsername.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBLAdminUsername.Location = new Point(121, 50);
            LBLAdminUsername.Name = "LBLAdminUsername";
            LBLAdminUsername.Size = new Size(47, 15);
            LBLAdminUsername.TabIndex = 12;
            LBLAdminUsername.Text = "label7";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 12F);
            label6.Location = new Point(19, 158);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(129, 18);
            label6.TabIndex = 11;
            label6.Text = "Phone number:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F);
            label5.Location = new Point(19, 47);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(95, 18);
            label5.TabIndex = 10;
            label5.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 12F);
            label3.Location = new Point(19, 101);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 18);
            label3.TabIndex = 9;
            label3.Text = "Email:";
            // 
            // AdminInfoUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AdminInfoUC";
            Size = new Size(827, 481);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private Label LBLAdminPhoneNumber;
        private Label LBLAdminEmail;
        private Label LBLAdminUsername;
        private Label label6;
        private Label label5;
        private Label label3;
        private Button BTNChangeAdminInfo;
    }
}

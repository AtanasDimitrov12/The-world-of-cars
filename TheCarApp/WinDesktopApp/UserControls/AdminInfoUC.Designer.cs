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
            groupBox1 = new GroupBox();
            BTNUpdateAdminInfo = new Button();
            TBAdminInfo = new TextBox();
            label4 = new Label();
            LabelAdminInfo = new Label();
            RBAdminPhoneNumber = new RadioButton();
            RBAdminPassword = new RadioButton();
            RBAdminEmail = new RadioButton();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BTNUpdateAdminInfo);
            groupBox1.Controls.Add(TBAdminInfo);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(LabelAdminInfo);
            groupBox1.Controls.Add(RBAdminPhoneNumber);
            groupBox1.Controls.Add(RBAdminPassword);
            groupBox1.Controls.Add(RBAdminEmail);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(254, 70);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(287, 324);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Admin Info";
            // 
            // BTNUpdateAdminInfo
            // 
            BTNUpdateAdminInfo.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNUpdateAdminInfo.Location = new Point(76, 269);
            BTNUpdateAdminInfo.Margin = new Padding(4, 3, 4, 3);
            BTNUpdateAdminInfo.Name = "BTNUpdateAdminInfo";
            BTNUpdateAdminInfo.Size = new Size(121, 43);
            BTNUpdateAdminInfo.TabIndex = 8;
            BTNUpdateAdminInfo.Text = "Update";
            BTNUpdateAdminInfo.UseVisualStyleBackColor = true;
            BTNUpdateAdminInfo.Click += BTNUpdateAdminInfo_Click;
            // 
            // TBAdminInfo
            // 
            TBAdminInfo.Location = new Point(37, 222);
            TBAdminInfo.Margin = new Padding(4, 3, 4, 3);
            TBAdminInfo.Name = "TBAdminInfo";
            TBAdminInfo.Size = new Size(201, 23);
            TBAdminInfo.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F);
            label4.Location = new Point(34, 187);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(176, 18);
            label4.TabIndex = 6;
            label4.Text = "Type the information:";
            // 
            // LabelAdminInfo
            // 
            LabelAdminInfo.AutoSize = true;
            LabelAdminInfo.Font = new Font("Arial Rounded MT Bold", 12F);
            LabelAdminInfo.Location = new Point(61, 147);
            LabelAdminInfo.Margin = new Padding(4, 0, 4, 0);
            LabelAdminInfo.Name = "LabelAdminInfo";
            LabelAdminInfo.Size = new Size(126, 18);
            LabelAdminInfo.TabIndex = 5;
            LabelAdminInfo.Text = "Show from db..";
            // 
            // RBAdminPhoneNumber
            // 
            RBAdminPhoneNumber.AutoSize = true;
            RBAdminPhoneNumber.Location = new Point(166, 69);
            RBAdminPhoneNumber.Margin = new Padding(4, 3, 4, 3);
            RBAdminPhoneNumber.Name = "RBAdminPhoneNumber";
            RBAdminPhoneNumber.Size = new Size(104, 19);
            RBAdminPhoneNumber.TabIndex = 4;
            RBAdminPhoneNumber.TabStop = true;
            RBAdminPhoneNumber.Text = "Phone number";
            RBAdminPhoneNumber.UseVisualStyleBackColor = true;
            // 
            // RBAdminPassword
            // 
            RBAdminPassword.AutoSize = true;
            RBAdminPassword.Location = new Point(76, 69);
            RBAdminPassword.Margin = new Padding(4, 3, 4, 3);
            RBAdminPassword.Name = "RBAdminPassword";
            RBAdminPassword.Size = new Size(75, 19);
            RBAdminPassword.TabIndex = 3;
            RBAdminPassword.TabStop = true;
            RBAdminPassword.Text = "Password";
            RBAdminPassword.UseVisualStyleBackColor = true;
            // 
            // RBAdminEmail
            // 
            RBAdminEmail.AutoSize = true;
            RBAdminEmail.Location = new Point(10, 69);
            RBAdminEmail.Margin = new Padding(4, 3, 4, 3);
            RBAdminEmail.Name = "RBAdminEmail";
            RBAdminEmail.Size = new Size(54, 19);
            RBAdminEmail.TabIndex = 2;
            RBAdminEmail.TabStop = true;
            RBAdminEmail.Text = "Email";
            RBAdminEmail.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F);
            label2.Location = new Point(29, 30);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(180, 18);
            label2.TabIndex = 1;
            label2.Text = "What you will change:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(31, 110);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(178, 18);
            label1.TabIndex = 0;
            label1.Text = "Previous Information:";
            // 
            // AdminInfoUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AdminInfoUC";
            Size = new Size(827, 481);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTNUpdateAdminInfo;
        private System.Windows.Forms.TextBox TBAdminInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LabelAdminInfo;
        private System.Windows.Forms.RadioButton RBAdminPhoneNumber;
        private System.Windows.Forms.RadioButton RBAdminPassword;
        private System.Windows.Forms.RadioButton RBAdminEmail;
    }
}

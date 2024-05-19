namespace WinDesktopApp.Forms
{
    partial class AdminVerification
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
            label1 = new Label();
            TBAdminPass = new TextBox();
            BTNCheckPass = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(53, 38);
            label1.Name = "label1";
            label1.Size = new Size(347, 18);
            label1.TabIndex = 0;
            label1.Text = "Please enter admin's password to proceed";
            // 
            // TBAdminPass
            // 
            TBAdminPass.Location = new Point(131, 89);
            TBAdminPass.Name = "TBAdminPass";
            TBAdminPass.Size = new Size(197, 23);
            TBAdminPass.TabIndex = 1;
            // 
            // BTNCheckPass
            // 
            BTNCheckPass.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNCheckPass.Location = new Point(176, 136);
            BTNCheckPass.Name = "BTNCheckPass";
            BTNCheckPass.Size = new Size(102, 32);
            BTNCheckPass.TabIndex = 2;
            BTNCheckPass.Text = "Check Pass";
            BTNCheckPass.UseVisualStyleBackColor = true;
            BTNCheckPass.Click += BTNCheckPass_Click;
            // 
            // AdminVerification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 203);
            Controls.Add(BTNCheckPass);
            Controls.Add(TBAdminPass);
            Controls.Add(label1);
            Name = "AdminVerification";
            Text = "AdminVerification";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TBAdminPass;
        private Button BTNCheckPass;
    }
}
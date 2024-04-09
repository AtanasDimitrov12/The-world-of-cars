namespace WinDesktopApp.Forms
{
    partial class AddExtra
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
            BTNAddExtra = new Button();
            RTBExtraName = new RichTextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // BTNAddExtra
            // 
            BTNAddExtra.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddExtra.Location = new Point(79, 117);
            BTNAddExtra.Name = "BTNAddExtra";
            BTNAddExtra.Size = new Size(179, 58);
            BTNAddExtra.TabIndex = 0;
            BTNAddExtra.Text = "Add";
            BTNAddExtra.UseVisualStyleBackColor = true;
            // 
            // RTBExtraName
            // 
            RTBExtraName.Location = new Point(37, 42);
            RTBExtraName.Name = "RTBExtraName";
            RTBExtraName.Size = new Size(254, 69);
            RTBExtraName.TabIndex = 1;
            RTBExtraName.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(99, 9);
            label1.Name = "label1";
            label1.Size = new Size(127, 18);
            label1.TabIndex = 2;
            label1.Text = "Type the extra:";
            // 
            // AddExtra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 187);
            Controls.Add(label1);
            Controls.Add(RTBExtraName);
            Controls.Add(BTNAddExtra);
            Name = "AddExtra";
            Text = "AddExtra";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTNAddExtra;
        private RichTextBox RTBExtraName;
        private Label label1;
    }
}
namespace WinDesktopApp.Forms
{
    partial class AddPicture
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
            BTNAddPicture = new Button();
            TBPictureURL = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(46, 19);
            label1.Name = "label1";
            label1.Size = new Size(194, 18);
            label1.TabIndex = 5;
            label1.Text = "Type the picture's URL:";
            // 
            // BTNAddPicture
            // 
            BTNAddPicture.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddPicture.Location = new Point(68, 100);
            BTNAddPicture.Name = "BTNAddPicture";
            BTNAddPicture.Size = new Size(139, 40);
            BTNAddPicture.TabIndex = 3;
            BTNAddPicture.Text = "Add";
            BTNAddPicture.UseVisualStyleBackColor = true;
            // 
            // TBPictureURL
            // 
            TBPictureURL.Location = new Point(38, 59);
            TBPictureURL.Name = "TBPictureURL";
            TBPictureURL.Size = new Size(201, 23);
            TBPictureURL.TabIndex = 6;
            // 
            // AddPicture
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 155);
            Controls.Add(TBPictureURL);
            Controls.Add(label1);
            Controls.Add(BTNAddPicture);
            Name = "AddPicture";
            Text = "AddPicture";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BTNAddPicture;
        private TextBox TBPictureURL;
    }
}
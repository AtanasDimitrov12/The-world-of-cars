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
            groupBox1 = new GroupBox();
            BTN = new Button();
            TBSearch = new TextBox();
            DGVPictures = new DataGridView();
            BTNClose = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVPictures).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(54, 45);
            label1.Name = "label1";
            label1.Size = new Size(194, 18);
            label1.TabIndex = 5;
            label1.Text = "Type the picture's URL:";
            // 
            // BTNAddPicture
            // 
            BTNAddPicture.BackColor = Color.FromArgb(88, 129, 87);
            BTNAddPicture.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddPicture.Location = new Point(66, 213);
            BTNAddPicture.Name = "BTNAddPicture";
            BTNAddPicture.Size = new Size(165, 41);
            BTNAddPicture.TabIndex = 3;
            BTNAddPicture.Text = "Add new picture";
            BTNAddPicture.UseVisualStyleBackColor = false;
            BTNAddPicture.Click += BTNAddPicture_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(163, 177, 138);
            groupBox1.Controls.Add(BTN);
            groupBox1.Controls.Add(TBSearch);
            groupBox1.Controls.Add(BTNAddPicture);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(31, 24);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(302, 287);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add picture";
            // 
            // BTN
            // 
            BTN.BackColor = Color.FromArgb(88, 129, 87);
            BTN.Font = new Font("Arial Rounded MT Bold", 12F);
            BTN.Location = new Point(97, 125);
            BTN.Margin = new Padding(3, 2, 3, 2);
            BTN.Name = "BTN";
            BTN.Size = new Size(102, 40);
            BTN.TabIndex = 7;
            BTN.Text = "Search";
            BTN.UseVisualStyleBackColor = false;
            BTN.Click += BTN_Click;
            // 
            // TBSearch
            // 
            TBSearch.Location = new Point(40, 83);
            TBSearch.Margin = new Padding(3, 2, 3, 2);
            TBSearch.Name = "TBSearch";
            TBSearch.Size = new Size(217, 23);
            TBSearch.TabIndex = 6;
            // 
            // DGVPictures
            // 
            DGVPictures.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPictures.Location = new Point(376, 24);
            DGVPictures.Margin = new Padding(3, 2, 3, 2);
            DGVPictures.Name = "DGVPictures";
            DGVPictures.RowHeadersWidth = 51;
            DGVPictures.Size = new Size(433, 287);
            DGVPictures.TabIndex = 8;
            // 
            // BTNClose
            // 
            BTNClose.BackColor = Color.FromArgb(88, 129, 87);
            BTNClose.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNClose.Location = new Point(376, 324);
            BTNClose.Name = "BTNClose";
            BTNClose.Size = new Size(158, 43);
            BTNClose.TabIndex = 9;
            BTNClose.Text = "Close";
            BTNClose.UseVisualStyleBackColor = false;
            BTNClose.Click += BTNClose_Click;
            // 
            // AddPicture
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(853, 379);
            Controls.Add(BTNClose);
            Controls.Add(DGVPictures);
            Controls.Add(groupBox1);
            Name = "AddPicture";
            Text = "AddPicture";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVPictures).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button BTNAddPicture;
        private GroupBox groupBox1;
        private DataGridView DGVPictures;
        private Button BTN;
        private TextBox TBSearch;
        private Button BTNClose;
    }
}
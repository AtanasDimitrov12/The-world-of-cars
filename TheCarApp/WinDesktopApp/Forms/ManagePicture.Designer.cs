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
            DGVPictures = new DataGridView();
            TBSearch = new TextBox();
            BTN = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVPictures).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(46, 56);
            label1.Name = "label1";
            label1.Size = new Size(238, 23);
            label1.TabIndex = 5;
            label1.Text = "Type the picture's URL:";
            // 
            // BTNAddPicture
            // 
            BTNAddPicture.BackColor = Color.FromArgb(88, 129, 87);
            BTNAddPicture.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddPicture.Location = new Point(75, 284);
            BTNAddPicture.Margin = new Padding(3, 4, 3, 4);
            BTNAddPicture.Name = "BTNAddPicture";
            BTNAddPicture.Size = new Size(189, 53);
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
            groupBox1.Location = new Point(35, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(345, 383);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add picture";
            // 
            // DGVPictures
            // 
            DGVPictures.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPictures.Location = new Point(430, 32);
            DGVPictures.Name = "DGVPictures";
            DGVPictures.RowHeadersWidth = 51;
            DGVPictures.Size = new Size(495, 383);
            DGVPictures.TabIndex = 8;
            // 
            // TBSearch
            // 
            TBSearch.Location = new Point(90, 111);
            TBSearch.Name = "TBSearch";
            TBSearch.Size = new Size(163, 27);
            TBSearch.TabIndex = 6;
            // 
            // BTN
            // 
            BTN.BackColor = Color.FromArgb(88, 129, 87);
            BTN.Font = new Font("Arial Rounded MT Bold", 12F);
            BTN.Location = new Point(111, 167);
            BTN.Name = "BTN";
            BTN.Size = new Size(116, 53);
            BTN.TabIndex = 7;
            BTN.Text = "Search";
            BTN.UseVisualStyleBackColor = false;
            BTN.Click += BTN_Click;
            // 
            // AddPicture
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(975, 467);
            Controls.Add(DGVPictures);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
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
    }
}
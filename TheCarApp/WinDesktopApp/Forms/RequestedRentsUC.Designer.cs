namespace WinDesktopApp.Forms
{
    partial class RequestedRentsUC
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
            DGVRequestRents = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGVRequestRents).BeginInit();
            SuspendLayout();
            // 
            // DGVRequestRents
            // 
            DGVRequestRents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRequestRents.Location = new Point(39, 32);
            DGVRequestRents.Name = "DGVRequestRents";
            DGVRequestRents.RowHeadersWidth = 51;
            DGVRequestRents.Size = new Size(925, 426);
            DGVRequestRents.TabIndex = 0;
            // 
            // RequstedRentsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(994, 489);
            Controls.Add(DGVRequestRents);
            Name = "RequstedRentsUC";
            Text = "RequstedRentsUC";
            ((System.ComponentModel.ISupportInitialize)DGVRequestRents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVRequestRents;
    }
}
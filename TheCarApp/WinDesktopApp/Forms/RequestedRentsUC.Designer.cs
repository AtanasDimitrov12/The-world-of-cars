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
            BTNClose = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVRequestRents).BeginInit();
            SuspendLayout();
            // 
            // DGVRequestRents
            // 
            DGVRequestRents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRequestRents.Location = new Point(34, 24);
            DGVRequestRents.Margin = new Padding(3, 2, 3, 2);
            DGVRequestRents.Name = "DGVRequestRents";
            DGVRequestRents.RowHeadersWidth = 51;
            DGVRequestRents.Size = new Size(809, 320);
            DGVRequestRents.TabIndex = 0;
            DGVRequestRents.CellContentClick += DGVRequestRents_CellContentClick;
            // 
            // BTNClose
            // 
            BTNClose.BackColor = Color.FromArgb(88, 129, 87);
            BTNClose.Font = new Font("Arial Rounded MT Bold", 10.2F);
            BTNClose.ForeColor = Color.White;
            BTNClose.Location = new Point(374, 368);
            BTNClose.Margin = new Padding(3, 2, 3, 2);
            BTNClose.Name = "BTNClose";
            BTNClose.Size = new Size(132, 40);
            BTNClose.TabIndex = 19;
            BTNClose.Text = "Close";
            BTNClose.UseVisualStyleBackColor = false;
            BTNClose.Click += BTNClose_Click;
            // 
            // RequestedRentsUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(870, 428);
            Controls.Add(BTNClose);
            Controls.Add(DGVRequestRents);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RequestedRentsUC";
            Text = "RequstedRentsUC";
            ((System.ComponentModel.ISupportInitialize)DGVRequestRents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVRequestRents;
        private Button BTNClose;
    }
}
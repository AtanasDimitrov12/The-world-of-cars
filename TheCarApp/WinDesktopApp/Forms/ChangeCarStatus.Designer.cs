namespace WinDesktopApp.Forms
{
    partial class ChangeCarStatus
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
            label4 = new Label();
            label6 = new Label();
            label8 = new Label();
            groupBox1 = new GroupBox();
            BTNUpdate = new Button();
            CBChangeStatus = new ComboBox();
            label9 = new Label();
            groupBox2 = new GroupBox();
            BTNClose = new Button();
            TBBrand = new TextBox();
            TBStatus = new TextBox();
            TBModel = new TextBox();
            TBYear = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(19, 41);
            label1.Name = "label1";
            label1.Size = new Size(62, 18);
            label1.TabIndex = 0;
            label1.Text = "Brand:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F);
            label4.Location = new Point(19, 81);
            label4.Name = "label4";
            label4.Size = new Size(60, 18);
            label4.TabIndex = 2;
            label4.Text = "Model:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 12F);
            label6.Location = new Point(19, 124);
            label6.Name = "label6";
            label6.Size = new Size(50, 18);
            label6.TabIndex = 4;
            label6.Text = "Year:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 12F);
            label8.Location = new Point(19, 168);
            label8.Name = "label8";
            label8.Size = new Size(131, 18);
            label8.TabIndex = 6;
            label8.Text = "Current Status:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(163, 177, 138);
            groupBox1.Controls.Add(BTNUpdate);
            groupBox1.Controls.Add(CBChangeStatus);
            groupBox1.Controls.Add(label9);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(27, 24);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(235, 216);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Change Status";
            // 
            // BTNUpdate
            // 
            BTNUpdate.BackColor = Color.FromArgb(88, 129, 87);
            BTNUpdate.Font = new Font("Arial Rounded MT Bold", 10.2F);
            BTNUpdate.ForeColor = Color.White;
            BTNUpdate.Location = new Point(49, 127);
            BTNUpdate.Margin = new Padding(3, 2, 3, 2);
            BTNUpdate.Name = "BTNUpdate";
            BTNUpdate.Size = new Size(132, 38);
            BTNUpdate.TabIndex = 2;
            BTNUpdate.Text = "Update";
            BTNUpdate.UseVisualStyleBackColor = false;
            BTNUpdate.Click += BTNUpdate_Click;
            // 
            // CBChangeStatus
            // 
            CBChangeStatus.FormattingEnabled = true;
            CBChangeStatus.Location = new Point(32, 77);
            CBChangeStatus.Margin = new Padding(3, 2, 3, 2);
            CBChangeStatus.Name = "CBChangeStatus";
            CBChangeStatus.Size = new Size(170, 22);
            CBChangeStatus.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(49, 45);
            label9.Name = "label9";
            label9.Size = new Size(135, 14);
            label9.TabIndex = 0;
            label9.Text = "Select the new Status:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(163, 177, 138);
            groupBox2.Controls.Add(TBYear);
            groupBox2.Controls.Add(TBModel);
            groupBox2.Controls.Add(TBStatus);
            groupBox2.Controls.Add(TBBrand);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label6);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(306, 24);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(267, 216);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Car Information";
            // 
            // BTNClose
            // 
            BTNClose.BackColor = Color.FromArgb(88, 129, 87);
            BTNClose.Font = new Font("Arial Rounded MT Bold", 10.2F);
            BTNClose.ForeColor = Color.White;
            BTNClose.Location = new Point(243, 260);
            BTNClose.Margin = new Padding(3, 2, 3, 2);
            BTNClose.Name = "BTNClose";
            BTNClose.Size = new Size(132, 48);
            BTNClose.TabIndex = 3;
            BTNClose.Text = "Close";
            BTNClose.UseVisualStyleBackColor = false;
            BTNClose.Click += BTNClose_Click;
            // 
            // TBBrand
            // 
            TBBrand.Location = new Point(96, 42);
            TBBrand.Name = "TBBrand";
            TBBrand.Size = new Size(165, 21);
            TBBrand.TabIndex = 7;
            // 
            // TBStatus
            // 
            TBStatus.Location = new Point(156, 168);
            TBStatus.Name = "TBStatus";
            TBStatus.Size = new Size(105, 21);
            TBStatus.TabIndex = 8;
            // 
            // TBModel
            // 
            TBModel.Location = new Point(96, 82);
            TBModel.Name = "TBModel";
            TBModel.Size = new Size(165, 21);
            TBModel.TabIndex = 9;
            // 
            // TBYear
            // 
            TBYear.Location = new Point(96, 127);
            TBYear.Name = "TBYear";
            TBYear.Size = new Size(165, 21);
            TBYear.TabIndex = 10;
            // 
            // ChangeCarStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(599, 338);
            Controls.Add(BTNClose);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChangeCarStatus";
            Text = "ChangeCarStatus";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label4;
        private Label label6;
        private Label label8;
        private GroupBox groupBox1;
        private Button BTNUpdate;
        private ComboBox CBChangeStatus;
        private Label label9;
        private GroupBox groupBox2;
        private Button BTNClose;
        private TextBox TBYear;
        private TextBox TBModel;
        private TextBox TBStatus;
        private TextBox TBBrand;
    }
}
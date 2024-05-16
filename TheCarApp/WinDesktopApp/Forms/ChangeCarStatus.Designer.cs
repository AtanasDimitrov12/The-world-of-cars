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
            LBLBrand = new Label();
            LBLModel = new Label();
            label4 = new Label();
            LBLYear = new Label();
            label6 = new Label();
            LBLCurrentStatus = new Label();
            label8 = new Label();
            groupBox1 = new GroupBox();
            label9 = new Label();
            CBChangeStatus = new ComboBox();
            BTNUpdate = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(46, 51);
            label1.Name = "label1";
            label1.Size = new Size(76, 23);
            label1.TabIndex = 0;
            label1.Text = "Brand:";
            // 
            // LBLBrand
            // 
            LBLBrand.AutoSize = true;
            LBLBrand.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBLBrand.Location = new Point(128, 54);
            LBLBrand.Name = "LBLBrand";
            LBLBrand.Size = new Size(60, 20);
            LBLBrand.TabIndex = 1;
            LBLBrand.Text = "label2";
            // 
            // LBLModel
            // 
            LBLModel.AutoSize = true;
            LBLModel.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBLModel.Location = new Point(382, 54);
            LBLModel.Name = "LBLModel";
            LBLModel.Size = new Size(60, 20);
            LBLModel.TabIndex = 3;
            LBLModel.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F);
            label4.Location = new Point(301, 51);
            label4.Name = "label4";
            label4.Size = new Size(75, 23);
            label4.TabIndex = 2;
            label4.Text = "Model:";
            // 
            // LBLYear
            // 
            LBLYear.AutoSize = true;
            LBLYear.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBLYear.Location = new Point(611, 54);
            LBLYear.Name = "LBLYear";
            LBLYear.Size = new Size(60, 20);
            LBLYear.TabIndex = 5;
            LBLYear.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 12F);
            label6.Location = new Point(543, 51);
            label6.Name = "label6";
            label6.Size = new Size(62, 23);
            label6.TabIndex = 4;
            label6.Text = "Year:";
            // 
            // LBLCurrentStatus
            // 
            LBLCurrentStatus.AutoSize = true;
            LBLCurrentStatus.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBLCurrentStatus.Location = new Point(422, 135);
            LBLCurrentStatus.Name = "LBLCurrentStatus";
            LBLCurrentStatus.Size = new Size(60, 20);
            LBLCurrentStatus.TabIndex = 7;
            LBLCurrentStatus.Text = "label7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 12F);
            label8.Location = new Point(257, 132);
            label8.Name = "label8";
            label8.Size = new Size(159, 23);
            label8.TabIndex = 6;
            label8.Text = "Current Status:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BTNUpdate);
            groupBox1.Controls.Add(CBChangeStatus);
            groupBox1.Controls.Add(label9);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(247, 217);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 190);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Change Status";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(36, 36);
            label9.Name = "label9";
            label9.Size = new Size(170, 17);
            label9.TabIndex = 0;
            label9.Text = "Select the new Status:";
            // 
            // CBChangeStatus
            // 
            CBChangeStatus.FormattingEnabled = true;
            CBChangeStatus.Location = new Point(44, 69);
            CBChangeStatus.Name = "CBChangeStatus";
            CBChangeStatus.Size = new Size(151, 25);
            CBChangeStatus.TabIndex = 1;
            // 
            // BTNUpdate
            // 
            BTNUpdate.Font = new Font("Arial Rounded MT Bold", 10.2F);
            BTNUpdate.Location = new Point(44, 129);
            BTNUpdate.Name = "BTNUpdate";
            BTNUpdate.Size = new Size(151, 39);
            BTNUpdate.TabIndex = 2;
            BTNUpdate.Text = "Update";
            BTNUpdate.UseVisualStyleBackColor = true;
            BTNUpdate.Click += BTNUpdate_Click;
            // 
            // ChangeCarStatus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(LBLCurrentStatus);
            Controls.Add(label8);
            Controls.Add(LBLYear);
            Controls.Add(label6);
            Controls.Add(LBLModel);
            Controls.Add(label4);
            Controls.Add(LBLBrand);
            Controls.Add(label1);
            Name = "ChangeCarStatus";
            Text = "ChangeCarStatus";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label LBLBrand;
        private Label LBLModel;
        private Label label4;
        private Label LBLYear;
        private Label label6;
        private Label LBLCurrentStatus;
        private Label label8;
        private GroupBox groupBox1;
        private Button BTNUpdate;
        private ComboBox CBChangeStatus;
        private Label label9;
    }
}
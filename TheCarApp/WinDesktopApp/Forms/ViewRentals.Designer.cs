namespace WinDesktopApp.Forms
{
    partial class ViewRentals
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
            groupBox1 = new GroupBox();
            CBRentStatus = new ComboBox();
            TBRentStatus = new TextBox();
            TBTotalPrice = new TextBox();
            DTPEndDate = new DateTimePicker();
            DTPStartDate = new DateTimePicker();
            TBCar = new TextBox();
            TBUsername = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            BTNUpdate = new Button();
            BTNClose = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(163, 177, 138);
            groupBox1.Controls.Add(CBRentStatus);
            groupBox1.Controls.Add(TBRentStatus);
            groupBox1.Controls.Add(TBTotalPrice);
            groupBox1.Controls.Add(DTPEndDate);
            groupBox1.Controls.Add(DTPStartDate);
            groupBox1.Controls.Add(TBCar);
            groupBox1.Controls.Add(TBUsername);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox1.Location = new Point(31, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(918, 255);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Show rental";
            // 
            // CBRentStatus
            // 
            CBRentStatus.FormattingEnabled = true;
            CBRentStatus.Location = new Point(591, 178);
            CBRentStatus.Margin = new Padding(3, 2, 3, 2);
            CBRentStatus.Name = "CBRentStatus";
            CBRentStatus.Size = new Size(310, 26);
            CBRentStatus.TabIndex = 29;
            // 
            // TBRentStatus
            // 
            TBRentStatus.Location = new Point(591, 178);
            TBRentStatus.Margin = new Padding(3, 2, 3, 2);
            TBRentStatus.Name = "TBRentStatus";
            TBRentStatus.Size = new Size(310, 26);
            TBRentStatus.TabIndex = 28;
            // 
            // TBTotalPrice
            // 
            TBTotalPrice.Location = new Point(127, 178);
            TBTotalPrice.Margin = new Padding(3, 2, 3, 2);
            TBTotalPrice.Name = "TBTotalPrice";
            TBTotalPrice.Size = new Size(310, 26);
            TBTotalPrice.TabIndex = 27;
            // 
            // DTPEndDate
            // 
            DTPEndDate.CalendarFont = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DTPEndDate.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DTPEndDate.Location = new Point(591, 106);
            DTPEndDate.Margin = new Padding(3, 2, 3, 2);
            DTPEndDate.Name = "DTPEndDate";
            DTPEndDate.Size = new Size(310, 26);
            DTPEndDate.TabIndex = 26;
            DTPEndDate.ValueChanged += DTPEndDate_ValueChanged;
            // 
            // DTPStartDate
            // 
            DTPStartDate.CalendarFont = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DTPStartDate.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DTPStartDate.Location = new Point(127, 108);
            DTPStartDate.Margin = new Padding(3, 2, 3, 2);
            DTPStartDate.Name = "DTPStartDate";
            DTPStartDate.Size = new Size(310, 26);
            DTPStartDate.TabIndex = 25;
            DTPStartDate.ValueChanged += DTPStartDate_ValueChanged;
            // 
            // TBCar
            // 
            TBCar.Location = new Point(591, 46);
            TBCar.Margin = new Padding(3, 2, 3, 2);
            TBCar.Name = "TBCar";
            TBCar.Size = new Size(310, 26);
            TBCar.TabIndex = 24;
            // 
            // TBUsername
            // 
            TBUsername.Location = new Point(127, 46);
            TBUsername.Margin = new Padding(3, 2, 3, 2);
            TBUsername.Name = "TBUsername";
            TBUsername.Size = new Size(310, 26);
            TBUsername.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 12F);
            label6.Location = new Point(472, 178);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(107, 18);
            label6.TabIndex = 22;
            label6.Text = "Rent Status:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F);
            label5.Location = new Point(18, 178);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(99, 18);
            label5.TabIndex = 21;
            label5.Text = "Total Price:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F);
            label4.Location = new Point(472, 111);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(86, 18);
            label4.TabIndex = 20;
            label4.Text = "End Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 12F);
            label3.Location = new Point(18, 111);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(95, 18);
            label3.TabIndex = 19;
            label3.Text = "Start Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F);
            label2.Location = new Point(472, 49);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 18);
            label2.TabIndex = 18;
            label2.Text = "Car Info:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(18, 49);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 18);
            label1.TabIndex = 17;
            label1.Text = "Username:";
            // 
            // BTNUpdate
            // 
            BTNUpdate.BackColor = Color.FromArgb(88, 129, 87);
            BTNUpdate.Font = new Font("Arial Rounded MT Bold", 10.2F);
            BTNUpdate.ForeColor = Color.White;
            BTNUpdate.Location = new Point(373, 294);
            BTNUpdate.Margin = new Padding(3, 2, 3, 2);
            BTNUpdate.Name = "BTNUpdate";
            BTNUpdate.Size = new Size(132, 40);
            BTNUpdate.TabIndex = 18;
            BTNUpdate.Text = "Update";
            BTNUpdate.UseVisualStyleBackColor = false;
            BTNUpdate.Click += BTNUpdate_Click;
            // 
            // BTNClose
            // 
            BTNClose.BackColor = Color.FromArgb(88, 129, 87);
            BTNClose.Font = new Font("Arial Rounded MT Bold", 10.2F);
            BTNClose.ForeColor = Color.White;
            BTNClose.Location = new Point(522, 294);
            BTNClose.Margin = new Padding(3, 2, 3, 2);
            BTNClose.Name = "BTNClose";
            BTNClose.Size = new Size(132, 40);
            BTNClose.TabIndex = 19;
            BTNClose.Text = "Close";
            BTNClose.UseVisualStyleBackColor = false;
            BTNClose.Click += BTNClose_Click;
            // 
            // ViewRentals
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(981, 343);
            Controls.Add(BTNClose);
            Controls.Add(BTNUpdate);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ViewRentals";
            Text = "ViewRentals";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker DTPStartDate;
        private TextBox TBCar;
        private TextBox TBUsername;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox CBRentStatus;
        private TextBox TBRentStatus;
        private TextBox TBTotalPrice;
        private DateTimePicker DTPEndDate;
        private Button BTNUpdate;
        private Button BTNClose;
    }
}
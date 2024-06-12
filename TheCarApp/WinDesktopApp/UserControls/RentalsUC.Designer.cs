namespace WinDesktopApp.UserControls
{
    partial class RentalsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox2 = new GroupBox();
            BTNCheckRentals = new Button();
            LBLNumOfRentals = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            RBDESC = new RadioButton();
            RBASC = new RadioButton();
            label1 = new Label();
            groupBox3 = new GroupBox();
            BTNSearchByUsername = new Button();
            label2 = new Label();
            TBUsername = new TextBox();
            DGVRentals = new DataGridView();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVRentals).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(163, 177, 138);
            groupBox2.Controls.Add(BTNCheckRentals);
            groupBox2.Controls.Add(LBLNumOfRentals);
            groupBox2.Controls.Add(label5);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox2.Location = new Point(29, 464);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(250, 201);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Waiting rentals";
            // 
            // BTNCheckRentals
            // 
            BTNCheckRentals.BackColor = Color.FromArgb(88, 129, 87);
            BTNCheckRentals.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNCheckRentals.ForeColor = Color.White;
            BTNCheckRentals.Location = new Point(38, 120);
            BTNCheckRentals.Margin = new Padding(3, 4, 3, 4);
            BTNCheckRentals.Name = "BTNCheckRentals";
            BTNCheckRentals.Size = new Size(167, 59);
            BTNCheckRentals.TabIndex = 15;
            BTNCheckRentals.Text = "Check rentals";
            BTNCheckRentals.UseVisualStyleBackColor = false;
            BTNCheckRentals.Click += BTNCheckRentals_Click;
            // 
            // LBLNumOfRentals
            // 
            LBLNumOfRentals.AutoSize = true;
            LBLNumOfRentals.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBLNumOfRentals.Location = new Point(23, 56);
            LBLNumOfRentals.Name = "LBLNumOfRentals";
            LBLNumOfRentals.Size = new Size(34, 23);
            LBLNumOfRentals.TabIndex = 12;
            LBLNumOfRentals.Text = "12";
            LBLNumOfRentals.Click += LBLAdminUsername_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F);
            label5.Location = new Point(63, 56);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(167, 23);
            label5.TabIndex = 10;
            label5.Text = "requested rents";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(163, 177, 138);
            groupBox1.Controls.Add(RBDESC);
            groupBox1.Controls.Add(RBASC);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox1.Location = new Point(29, 23);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(250, 201);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Show rentals";
            // 
            // RBDESC
            // 
            RBDESC.AutoSize = true;
            RBDESC.Location = new Point(137, 103);
            RBDESC.Margin = new Padding(5, 4, 5, 4);
            RBDESC.Name = "RBDESC";
            RBDESC.Size = new Size(81, 27);
            RBDESC.TabIndex = 19;
            RBDESC.TabStop = true;
            RBDESC.Text = "Desc";
            RBDESC.UseVisualStyleBackColor = true;
            RBDESC.CheckedChanged += RBDESC_CheckedChanged;
            // 
            // RBASC
            // 
            RBASC.AutoSize = true;
            RBASC.Location = new Point(37, 103);
            RBASC.Margin = new Padding(5, 4, 5, 4);
            RBASC.Name = "RBASC";
            RBASC.Size = new Size(68, 27);
            RBASC.TabIndex = 18;
            RBASC.TabStop = true;
            RBASC.Text = "Asc";
            RBASC.UseVisualStyleBackColor = true;
            RBASC.CheckedChanged += RBASC_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(37, 52);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(186, 23);
            label1.TabIndex = 17;
            label1.Text = "Sort by start date:";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(163, 177, 138);
            groupBox3.Controls.Add(BTNSearchByUsername);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(TBUsername);
            groupBox3.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox3.Location = new Point(29, 243);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(250, 201);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Search rental";
            // 
            // BTNSearchByUsername
            // 
            BTNSearchByUsername.BackColor = Color.FromArgb(88, 129, 87);
            BTNSearchByUsername.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNSearchByUsername.ForeColor = Color.White;
            BTNSearchByUsername.Location = new Point(38, 127);
            BTNSearchByUsername.Margin = new Padding(5, 4, 5, 4);
            BTNSearchByUsername.Name = "BTNSearchByUsername";
            BTNSearchByUsername.Size = new Size(167, 59);
            BTNSearchByUsername.TabIndex = 22;
            BTNSearchByUsername.Text = "Search";
            BTNSearchByUsername.UseVisualStyleBackColor = false;
            BTNSearchByUsername.Click += BTNSearchByUsername_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F);
            label2.Location = new Point(42, 41);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(167, 23);
            label2.TabIndex = 20;
            label2.Text = "Search by User:";
            // 
            // TBUsername
            // 
            TBUsername.Location = new Point(23, 81);
            TBUsername.Margin = new Padding(5, 4, 5, 4);
            TBUsername.Name = "TBUsername";
            TBUsername.Size = new Size(196, 31);
            TBUsername.TabIndex = 21;
            TBUsername.TextChanged += TBNewsTitle_TextChanged;
            // 
            // DGVRentals
            // 
            DGVRentals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRentals.Location = new Point(315, 126);
            DGVRentals.Margin = new Padding(3, 4, 3, 4);
            DGVRentals.Name = "DGVRentals";
            DGVRentals.RowHeadersWidth = 51;
            DGVRentals.Size = new Size(1076, 419);
            DGVRentals.TabIndex = 17;
            DGVRentals.CellContentClick += DGVRentals_CellContentClick_1;
            // 
            // RentalsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            Controls.Add(DGVRentals);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RentalsUC";
            Size = new Size(1463, 689);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVRentals).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Button BTNCheckRentals;
        private Label LBLNumOfRentals;
        private Label label5;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private RadioButton RBDESC;
        private RadioButton RBASC;
        private Label label1;
        private Button BTNSearchByUsername;
        private Label label2;
        private TextBox TBUsername;
        private DataGridView DGVRentals;
    }
}

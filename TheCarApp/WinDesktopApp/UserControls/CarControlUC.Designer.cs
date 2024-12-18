﻿namespace WinDesktopApp.UserControls
{
    partial class CarControlUC
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
            groupBox1 = new GroupBox();
            BTNShowAll = new Button();
            BTNAddCar = new Button();
            groupBox3 = new GroupBox();
            TBSearchByYear = new TextBox();
            BTNSearch = new Button();
            label5 = new Label();
            groupBox2 = new GroupBox();
            RBDesc = new RadioButton();
            RBAsc = new RadioButton();
            label4 = new Label();
            DGVCars = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVCars).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(163, 177, 138);
            groupBox1.Controls.Add(BTNShowAll);
            groupBox1.Controls.Add(BTNAddCar);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 9.75F);
            groupBox1.Location = new Point(18, 464);
            groupBox1.Margin = new Padding(5, 4, 5, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 4, 5, 4);
            groupBox1.Size = new Size(240, 191);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Actions";
            // 
            // BTNShowAll
            // 
            BTNShowAll.BackColor = Color.FromArgb(88, 129, 87);
            BTNShowAll.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNShowAll.ForeColor = Color.White;
            BTNShowAll.Location = new Point(35, 41);
            BTNShowAll.Margin = new Padding(5, 4, 5, 4);
            BTNShowAll.Name = "BTNShowAll";
            BTNShowAll.Size = new Size(167, 59);
            BTNShowAll.TabIndex = 21;
            BTNShowAll.Text = "Show all";
            BTNShowAll.UseVisualStyleBackColor = false;
            BTNShowAll.Click += BTNShowAll_Click;
            // 
            // BTNAddCar
            // 
            BTNAddCar.BackColor = Color.FromArgb(88, 129, 87);
            BTNAddCar.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddCar.ForeColor = Color.White;
            BTNAddCar.Location = new Point(35, 116);
            BTNAddCar.Margin = new Padding(5, 4, 5, 4);
            BTNAddCar.Name = "BTNAddCar";
            BTNAddCar.Size = new Size(167, 59);
            BTNAddCar.TabIndex = 20;
            BTNAddCar.Text = "Add car";
            BTNAddCar.UseVisualStyleBackColor = false;
            BTNAddCar.Click += BTNAddCar_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(163, 177, 138);
            groupBox3.Controls.Add(TBSearchByYear);
            groupBox3.Controls.Add(BTNSearch);
            groupBox3.Controls.Add(label5);
            groupBox3.Font = new Font("Arial Rounded MT Bold", 9.75F);
            groupBox3.Location = new Point(18, 211);
            groupBox3.Margin = new Padding(5, 4, 5, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(5, 4, 5, 4);
            groupBox3.Size = new Size(240, 225);
            groupBox3.TabIndex = 24;
            groupBox3.TabStop = false;
            groupBox3.Text = "Search cars";
            // 
            // TBSearchByYear
            // 
            TBSearchByYear.Location = new Point(58, 88);
            TBSearchByYear.Margin = new Padding(3, 4, 3, 4);
            TBSearchByYear.Name = "TBSearchByYear";
            TBSearchByYear.Size = new Size(114, 26);
            TBSearchByYear.TabIndex = 20;
            // 
            // BTNSearch
            // 
            BTNSearch.BackColor = Color.FromArgb(88, 129, 87);
            BTNSearch.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNSearch.ForeColor = Color.White;
            BTNSearch.Location = new Point(35, 127);
            BTNSearch.Margin = new Padding(5, 4, 5, 4);
            BTNSearch.Name = "BTNSearch";
            BTNSearch.Size = new Size(167, 59);
            BTNSearch.TabIndex = 19;
            BTNSearch.Text = "Search";
            BTNSearch.UseVisualStyleBackColor = false;
            BTNSearch.Click += BTNSearch_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F);
            label5.Location = new Point(31, 40);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(164, 23);
            label5.TabIndex = 17;
            label5.Text = "Search by year:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(163, 177, 138);
            groupBox2.Controls.Add(RBDesc);
            groupBox2.Controls.Add(RBAsc);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(18, 30);
            groupBox2.Margin = new Padding(5, 4, 5, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 4, 5, 4);
            groupBox2.Size = new Size(240, 151);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Show cars";
            // 
            // RBDesc
            // 
            RBDesc.AutoSize = true;
            RBDesc.Location = new Point(35, 83);
            RBDesc.Margin = new Padding(5, 4, 5, 4);
            RBDesc.Name = "RBDesc";
            RBDesc.Size = new Size(59, 24);
            RBDesc.TabIndex = 16;
            RBDesc.TabStop = true;
            RBDesc.Text = "A-Z";
            RBDesc.UseVisualStyleBackColor = true;
            RBDesc.CheckedChanged += RBDesc_CheckedChanged;
            // 
            // RBAsc
            // 
            RBAsc.AutoSize = true;
            RBAsc.Location = new Point(133, 83);
            RBAsc.Margin = new Padding(5, 4, 5, 4);
            RBAsc.Name = "RBAsc";
            RBAsc.Size = new Size(59, 24);
            RBAsc.TabIndex = 15;
            RBAsc.TabStop = true;
            RBAsc.Text = "Z-A";
            RBAsc.UseVisualStyleBackColor = true;
            RBAsc.CheckedChanged += RBAsc_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F);
            label4.Location = new Point(46, 43);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(150, 23);
            label4.TabIndex = 14;
            label4.Text = "Sort by brand:";
            // 
            // DGVCars
            // 
            DGVCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVCars.Location = new Point(285, 98);
            DGVCars.Name = "DGVCars";
            DGVCars.RowHeadersWidth = 51;
            DGVCars.Size = new Size(1141, 482);
            DGVCars.TabIndex = 26;
            DGVCars.CellContentClick += DGVCars_CellContentClick;
            // 
            // CarControlUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            Controls.Add(DGVCars);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Margin = new Padding(5, 4, 5, 4);
            Name = "CarControlUC";
            Size = new Size(1463, 689);
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVCars).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTNAddCar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BTNSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBDesc;
        private System.Windows.Forms.RadioButton RBAsc;
        private System.Windows.Forms.Label label4;
        private TextBox TBSearchByYear;
        private DataGridView DGVCars;
        private Button BTNShowAll;
    }
}

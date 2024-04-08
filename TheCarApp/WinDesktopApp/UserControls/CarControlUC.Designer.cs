namespace DesktopApp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTNModifyCar = new System.Windows.Forms.Button();
            this.BTNAddCar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BTNSearch = new System.Windows.Forms.Button();
            this.TBSearchByYear = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBDesc = new System.Windows.Forms.RadioButton();
            this.RBAsc = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.LBCars = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTNModifyCar);
            this.groupBox1.Controls.Add(this.BTNAddCar);
            this.groupBox1.Location = new System.Drawing.Point(14, 282);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 116);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // BTNModifyCar
            // 
            this.BTNModifyCar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BTNModifyCar.Location = new System.Drawing.Point(26, 72);
            this.BTNModifyCar.Name = "BTNModifyCar";
            this.BTNModifyCar.Size = new System.Drawing.Size(125, 35);
            this.BTNModifyCar.TabIndex = 21;
            this.BTNModifyCar.Text = "Modify car";
            this.BTNModifyCar.UseVisualStyleBackColor = true;
            this.BTNModifyCar.Click += new System.EventHandler(this.BTNModifyCar_Click);
            // 
            // BTNAddCar
            // 
            this.BTNAddCar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BTNAddCar.Location = new System.Drawing.Point(26, 31);
            this.BTNAddCar.Name = "BTNAddCar";
            this.BTNAddCar.Size = new System.Drawing.Size(125, 35);
            this.BTNAddCar.TabIndex = 20;
            this.BTNAddCar.Text = "Add car";
            this.BTNAddCar.UseVisualStyleBackColor = true;
            this.BTNAddCar.Click += new System.EventHandler(this.BTNAddCar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BTNSearch);
            this.groupBox3.Controls.Add(this.TBSearchByYear);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(14, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 137);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search cars";
            // 
            // BTNSearch
            // 
            this.BTNSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BTNSearch.Location = new System.Drawing.Point(27, 82);
            this.BTNSearch.Name = "BTNSearch";
            this.BTNSearch.Size = new System.Drawing.Size(125, 43);
            this.BTNSearch.TabIndex = 19;
            this.BTNSearch.Text = "Search";
            this.BTNSearch.UseVisualStyleBackColor = true;
            // 
            // TBSearchByYear
            // 
            this.TBSearchByYear.Location = new System.Drawing.Point(41, 56);
            this.TBSearchByYear.Name = "TBSearchByYear";
            this.TBSearchByYear.Size = new System.Drawing.Size(100, 20);
            this.TBSearchByYear.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label5.Location = new System.Drawing.Point(23, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Search by year:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBDesc);
            this.groupBox2.Controls.Add(this.RBAsc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(14, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 83);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show cars";
            // 
            // RBDesc
            // 
            this.RBDesc.AutoSize = true;
            this.RBDesc.Location = new System.Drawing.Point(101, 46);
            this.RBDesc.Name = "RBDesc";
            this.RBDesc.Size = new System.Drawing.Size(50, 17);
            this.RBDesc.TabIndex = 16;
            this.RBDesc.TabStop = true;
            this.RBDesc.Text = "Desc";
            this.RBDesc.UseVisualStyleBackColor = true;
            // 
            // RBAsc
            // 
            this.RBAsc.AutoSize = true;
            this.RBAsc.Location = new System.Drawing.Point(27, 46);
            this.RBAsc.Name = "RBAsc";
            this.RBAsc.Size = new System.Drawing.Size(43, 17);
            this.RBAsc.TabIndex = 15;
            this.RBAsc.TabStop = true;
            this.RBAsc.Text = "Asc";
            this.RBAsc.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label4.Location = new System.Drawing.Point(26, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Sort by brand:";
            // 
            // LBCars
            // 
            this.LBCars.FormattingEnabled = true;
            this.LBCars.Location = new System.Drawing.Point(231, 27);
            this.LBCars.Name = "LBCars";
            this.LBCars.Size = new System.Drawing.Size(273, 368);
            this.LBCars.TabIndex = 22;
            // 
            // CarControlUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LBCars);
            this.Name = "CarControlUC";
            this.Size = new System.Drawing.Size(530, 414);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTNModifyCar;
        private System.Windows.Forms.Button BTNAddCar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BTNSearch;
        private System.Windows.Forms.TextBox TBSearchByYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBDesc;
        private System.Windows.Forms.RadioButton RBAsc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox LBCars;
    }
}

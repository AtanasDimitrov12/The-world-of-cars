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
            groupBox1 = new GroupBox();
            BTNModifyCar = new Button();
            BTNAddCar = new Button();
            groupBox3 = new GroupBox();
            TBSearchByYear = new TextBox();
            BTNSearch = new Button();
            label5 = new Label();
            groupBox2 = new GroupBox();
            RBDesc = new RadioButton();
            RBAsc = new RadioButton();
            label4 = new Label();
            LBCars = new ListBox();
            BTNAddPics = new Button();
            BTNAddExtras = new Button();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BTNAddPics);
            groupBox1.Controls.Add(BTNAddExtras);
            groupBox1.Controls.Add(BTNModifyCar);
            groupBox1.Controls.Add(BTNAddCar);
            groupBox1.Location = new Point(16, 281);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(210, 204);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Actions";
            // 
            // BTNModifyCar
            // 
            BTNModifyCar.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNModifyCar.Location = new Point(31, 158);
            BTNModifyCar.Margin = new Padding(4, 3, 4, 3);
            BTNModifyCar.Name = "BTNModifyCar";
            BTNModifyCar.Size = new Size(146, 40);
            BTNModifyCar.TabIndex = 21;
            BTNModifyCar.Text = "Modify car";
            BTNModifyCar.UseVisualStyleBackColor = true;
            BTNModifyCar.Click += BTNModifyCar_Click;
            // 
            // BTNAddCar
            // 
            BTNAddCar.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddCar.Location = new Point(31, 111);
            BTNAddCar.Margin = new Padding(4, 3, 4, 3);
            BTNAddCar.Name = "BTNAddCar";
            BTNAddCar.Size = new Size(146, 40);
            BTNAddCar.TabIndex = 20;
            BTNAddCar.Text = "Add car";
            BTNAddCar.UseVisualStyleBackColor = true;
            BTNAddCar.Click += BTNAddCar_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(TBSearchByYear);
            groupBox3.Controls.Add(BTNSearch);
            groupBox3.Controls.Add(label5);
            groupBox3.Location = new Point(16, 117);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(210, 158);
            groupBox3.TabIndex = 24;
            groupBox3.TabStop = false;
            groupBox3.Text = "Search cars";
            // 
            // TBSearchByYear
            // 
            TBSearchByYear.Location = new Point(51, 66);
            TBSearchByYear.Name = "TBSearchByYear";
            TBSearchByYear.Size = new Size(100, 23);
            TBSearchByYear.TabIndex = 20;
            // 
            // BTNSearch
            // 
            BTNSearch.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNSearch.Location = new Point(31, 95);
            BTNSearch.Margin = new Padding(4, 3, 4, 3);
            BTNSearch.Name = "BTNSearch";
            BTNSearch.Size = new Size(146, 50);
            BTNSearch.TabIndex = 19;
            BTNSearch.Text = "Search";
            BTNSearch.UseVisualStyleBackColor = true;
            BTNSearch.Click += BTNSearch_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F);
            label5.Location = new Point(27, 30);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(134, 18);
            label5.TabIndex = 17;
            label5.Text = "Search by year:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RBDesc);
            groupBox2.Controls.Add(RBAsc);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(16, 15);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(210, 96);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Show cars";
            // 
            // RBDesc
            // 
            RBDesc.AutoSize = true;
            RBDesc.Location = new Point(118, 53);
            RBDesc.Margin = new Padding(4, 3, 4, 3);
            RBDesc.Name = "RBDesc";
            RBDesc.Size = new Size(50, 19);
            RBDesc.TabIndex = 16;
            RBDesc.TabStop = true;
            RBDesc.Text = "Desc";
            RBDesc.UseVisualStyleBackColor = true;
            RBDesc.CheckedChanged += RBDesc_CheckedChanged;
            // 
            // RBAsc
            // 
            RBAsc.AutoSize = true;
            RBAsc.Location = new Point(31, 53);
            RBAsc.Margin = new Padding(4, 3, 4, 3);
            RBAsc.Name = "RBAsc";
            RBAsc.Size = new Size(44, 19);
            RBAsc.TabIndex = 15;
            RBAsc.TabStop = true;
            RBAsc.Text = "Asc";
            RBAsc.UseVisualStyleBackColor = true;
            RBAsc.CheckedChanged += RBAsc_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F);
            label4.Location = new Point(30, 27);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(121, 18);
            label4.TabIndex = 14;
            label4.Text = "Sort by brand:";
            // 
            // LBCars
            // 
            LBCars.FormattingEnabled = true;
            LBCars.ItemHeight = 15;
            LBCars.Location = new Point(270, 31);
            LBCars.Margin = new Padding(4, 3, 4, 3);
            LBCars.Name = "LBCars";
            LBCars.Size = new Size(318, 424);
            LBCars.TabIndex = 22;
            // 
            // BTNAddPics
            // 
            BTNAddPics.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddPics.Location = new Point(31, 63);
            BTNAddPics.Margin = new Padding(4, 3, 4, 3);
            BTNAddPics.Name = "BTNAddPics";
            BTNAddPics.Size = new Size(146, 40);
            BTNAddPics.TabIndex = 23;
            BTNAddPics.Text = "Add pictures";
            BTNAddPics.UseVisualStyleBackColor = true;
            BTNAddPics.Click += BTNAddPics_Click;
            // 
            // BTNAddExtras
            // 
            BTNAddExtras.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddExtras.Location = new Point(31, 16);
            BTNAddExtras.Margin = new Padding(4, 3, 4, 3);
            BTNAddExtras.Name = "BTNAddExtras";
            BTNAddExtras.Size = new Size(146, 40);
            BTNAddExtras.TabIndex = 22;
            BTNAddExtras.Text = "Add Extras";
            BTNAddExtras.UseVisualStyleBackColor = true;
            BTNAddExtras.Click += BTNAddExtras_Click;
            // 
            // CarControlUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(LBCars);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CarControlUC";
            Size = new Size(618, 502);
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTNModifyCar;
        private System.Windows.Forms.Button BTNAddCar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BTNSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBDesc;
        private System.Windows.Forms.RadioButton RBAsc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox LBCars;
        private TextBox TBSearchByYear;
        private Button BTNAddPics;
        private Button BTNAddExtras;
    }
}

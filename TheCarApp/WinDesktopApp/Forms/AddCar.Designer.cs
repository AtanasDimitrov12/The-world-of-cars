namespace DesktopApp
{
    partial class AddCar
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
            RTBCarDescription = new RichTextBox();
            label1 = new Label();
            label6 = new Label();
            TBCarModel = new TextBox();
            label7 = new Label();
            TBCarBrand = new TextBox();
            label8 = new Label();
            DTPCarFirstReg = new DateTimePicker();
            label9 = new Label();
            NUDCarMileage = new NumericUpDown();
            label10 = new Label();
            TBCarFuel = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            CBCarGearbox = new ComboBox();
            label16 = new Label();
            TBCarNumOfSeats = new TextBox();
            TBCarNumOfDoors = new TextBox();
            label17 = new Label();
            label18 = new Label();
            TBCarColor = new TextBox();
            TBCarVIN = new TextBox();
            label19 = new Label();
            TBCarPrice = new TextBox();
            label20 = new Label();
            label21 = new Label();
            groupBox1 = new GroupBox();
            BTNAddExtra = new Button();
            BTNRemoveExtra = new Button();
            CBCarExtras = new ComboBox();
            LBExtras = new ListBox();
            BTNAddCar = new Button();
            NUDCarEngineSize = new NumericUpDown();
            NUDCarPower = new NumericUpDown();
            groupBox2 = new GroupBox();
            LBPictures = new ListBox();
            BTNAddPicture = new Button();
            BTNRemovePicture = new Button();
            CBPictureURL = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)NUDCarMileage).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUDCarEngineSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDCarPower).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // RTBCarDescription
            // 
            RTBCarDescription.Location = new Point(490, 80);
            RTBCarDescription.Margin = new Padding(5, 4, 5, 4);
            RTBCarDescription.Name = "RTBCarDescription";
            RTBCarDescription.Size = new Size(654, 108);
            RTBCarDescription.TabIndex = 11;
            RTBCarDescription.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(490, 31);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 23);
            label1.TabIndex = 10;
            label1.Text = "Description:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 12F);
            label6.Location = new Point(27, 79);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(75, 23);
            label6.TabIndex = 22;
            label6.Text = "Model:";
            // 
            // TBCarModel
            // 
            TBCarModel.Location = new Point(145, 79);
            TBCarModel.Margin = new Padding(5, 4, 5, 4);
            TBCarModel.Name = "TBCarModel";
            TBCarModel.Size = new Size(188, 27);
            TBCarModel.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 12F);
            label7.Location = new Point(27, 31);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(76, 23);
            label7.TabIndex = 20;
            label7.Text = "Brand:";
            // 
            // TBCarBrand
            // 
            TBCarBrand.Location = new Point(145, 32);
            TBCarBrand.Margin = new Padding(5, 4, 5, 4);
            TBCarBrand.Name = "TBCarBrand";
            TBCarBrand.Size = new Size(188, 27);
            TBCarBrand.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 12F);
            label8.Location = new Point(27, 133);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(179, 23);
            label8.TabIndex = 23;
            label8.Text = "First registration:";
            // 
            // DTPCarFirstReg
            // 
            DTPCarFirstReg.Location = new Point(231, 133);
            DTPCarFirstReg.Margin = new Padding(5, 4, 5, 4);
            DTPCarFirstReg.Name = "DTPCarFirstReg";
            DTPCarFirstReg.Size = new Size(188, 27);
            DTPCarFirstReg.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Rounded MT Bold", 12F);
            label9.Location = new Point(27, 180);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(92, 23);
            label9.TabIndex = 25;
            label9.Text = "Mileage:";
            // 
            // NUDCarMileage
            // 
            NUDCarMileage.Location = new Point(145, 183);
            NUDCarMileage.Margin = new Padding(5, 4, 5, 4);
            NUDCarMileage.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NUDCarMileage.Name = "NUDCarMileage";
            NUDCarMileage.Size = new Size(190, 27);
            NUDCarMileage.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Rounded MT Bold", 12F);
            label10.Location = new Point(27, 231);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(57, 23);
            label10.TabIndex = 27;
            label10.Text = "Fuel:";
            // 
            // TBCarFuel
            // 
            TBCarFuel.Location = new Point(145, 231);
            TBCarFuel.Margin = new Padding(5, 4, 5, 4);
            TBCarFuel.Name = "TBCarFuel";
            TBCarFuel.Size = new Size(188, 27);
            TBCarFuel.TabIndex = 28;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Rounded MT Bold", 12F);
            label11.Location = new Point(27, 291);
            label11.Margin = new Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new Size(126, 23);
            label11.TabIndex = 29;
            label11.Text = "Engine size:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial Rounded MT Bold", 12F);
            label12.Location = new Point(27, 351);
            label12.Margin = new Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new Size(78, 23);
            label12.TabIndex = 31;
            label12.Text = "Power:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial Rounded MT Bold", 12F);
            label13.Location = new Point(306, 353);
            label13.Margin = new Padding(5, 0, 5, 0);
            label13.Name = "label13";
            label13.Size = new Size(35, 23);
            label13.TabIndex = 33;
            label13.Text = "hp";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial Rounded MT Bold", 12F);
            label14.Location = new Point(306, 293);
            label14.Margin = new Padding(5, 0, 5, 0);
            label14.Name = "label14";
            label14.Size = new Size(34, 23);
            label14.TabIndex = 34;
            label14.Text = "cc";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial Rounded MT Bold", 12F);
            label15.Location = new Point(27, 403);
            label15.Margin = new Padding(5, 0, 5, 0);
            label15.Name = "label15";
            label15.Size = new Size(100, 23);
            label15.TabIndex = 35;
            label15.Text = "Gearbox:";
            // 
            // CBCarGearbox
            // 
            CBCarGearbox.FormattingEnabled = true;
            CBCarGearbox.Items.AddRange(new object[] { "Manuel", "Automatish " });
            CBCarGearbox.Location = new Point(145, 404);
            CBCarGearbox.Margin = new Padding(5, 4, 5, 4);
            CBCarGearbox.Name = "CBCarGearbox";
            CBCarGearbox.Size = new Size(188, 28);
            CBCarGearbox.TabIndex = 36;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Arial Rounded MT Bold", 12F);
            label16.Location = new Point(27, 456);
            label16.Margin = new Padding(5, 0, 5, 0);
            label16.Name = "label16";
            label16.Size = new Size(177, 23);
            label16.TabIndex = 37;
            label16.Text = "Number of seats:";
            // 
            // TBCarNumOfSeats
            // 
            TBCarNumOfSeats.Location = new Point(226, 457);
            TBCarNumOfSeats.Margin = new Padding(5, 4, 5, 4);
            TBCarNumOfSeats.Name = "TBCarNumOfSeats";
            TBCarNumOfSeats.Size = new Size(107, 27);
            TBCarNumOfSeats.TabIndex = 38;
            // 
            // TBCarNumOfDoors
            // 
            TBCarNumOfDoors.Location = new Point(226, 509);
            TBCarNumOfDoors.Margin = new Padding(5, 4, 5, 4);
            TBCarNumOfDoors.Name = "TBCarNumOfDoors";
            TBCarNumOfDoors.Size = new Size(107, 27);
            TBCarNumOfDoors.TabIndex = 40;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial Rounded MT Bold", 12F);
            label17.Location = new Point(27, 508);
            label17.Margin = new Padding(5, 0, 5, 0);
            label17.Name = "label17";
            label17.Size = new Size(181, 23);
            label17.TabIndex = 39;
            label17.Text = "Number of doors:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Arial Rounded MT Bold", 12F);
            label18.Location = new Point(27, 564);
            label18.Margin = new Padding(5, 0, 5, 0);
            label18.Name = "label18";
            label18.Size = new Size(69, 23);
            label18.TabIndex = 41;
            label18.Text = "Color:";
            // 
            // TBCarColor
            // 
            TBCarColor.Location = new Point(145, 567);
            TBCarColor.Margin = new Padding(5, 4, 5, 4);
            TBCarColor.Name = "TBCarColor";
            TBCarColor.Size = new Size(188, 27);
            TBCarColor.TabIndex = 42;
            // 
            // TBCarVIN
            // 
            TBCarVIN.Location = new Point(145, 612);
            TBCarVIN.Margin = new Padding(5, 4, 5, 4);
            TBCarVIN.Name = "TBCarVIN";
            TBCarVIN.Size = new Size(188, 27);
            TBCarVIN.TabIndex = 44;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Arial Rounded MT Bold", 12F);
            label19.Location = new Point(27, 611);
            label19.Margin = new Padding(5, 0, 5, 0);
            label19.Name = "label19";
            label19.Size = new Size(51, 23);
            label19.TabIndex = 43;
            label19.Text = "VIN:";
            // 
            // TBCarPrice
            // 
            TBCarPrice.Location = new Point(194, 664);
            TBCarPrice.Margin = new Padding(5, 4, 5, 4);
            TBCarPrice.Name = "TBCarPrice";
            TBCarPrice.Size = new Size(82, 27);
            TBCarPrice.TabIndex = 46;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Arial Rounded MT Bold", 12F);
            label20.Location = new Point(27, 663);
            label20.Margin = new Padding(5, 0, 5, 0);
            label20.Name = "label20";
            label20.Size = new Size(147, 23);
            label20.TabIndex = 45;
            label20.Text = "Price per day:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Arial Rounded MT Bold", 12F);
            label21.Location = new Point(283, 664);
            label21.Margin = new Padding(5, 0, 5, 0);
            label21.Name = "label21";
            label21.Size = new Size(55, 23);
            label21.TabIndex = 47;
            label21.Text = "euro";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BTNAddExtra);
            groupBox1.Controls.Add(BTNRemoveExtra);
            groupBox1.Controls.Add(CBCarExtras);
            groupBox1.Location = new Point(463, 239);
            groupBox1.Margin = new Padding(5, 4, 5, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 4, 5, 4);
            groupBox1.Size = new Size(318, 457);
            groupBox1.TabIndex = 48;
            groupBox1.TabStop = false;
            groupBox1.Text = "Car's extras";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // BTNAddExtra
            // 
            BTNAddExtra.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddExtra.Location = new Point(110, 89);
            BTNAddExtra.Margin = new Padding(5, 4, 5, 4);
            BTNAddExtra.Name = "BTNAddExtra";
            BTNAddExtra.Size = new Size(117, 56);
            BTNAddExtra.TabIndex = 1;
            BTNAddExtra.Text = "Add";
            BTNAddExtra.UseVisualStyleBackColor = true;
            BTNAddExtra.Click += BTNAddExtra_Click;
            // 
            // BTNRemoveExtra
            // 
            BTNRemoveExtra.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNRemoveExtra.Location = new Point(105, 387);
            BTNRemoveExtra.Margin = new Padding(5, 4, 5, 4);
            BTNRemoveExtra.Name = "BTNRemoveExtra";
            BTNRemoveExtra.Size = new Size(117, 56);
            BTNRemoveExtra.TabIndex = 2;
            BTNRemoveExtra.Text = "Remove";
            BTNRemoveExtra.UseVisualStyleBackColor = true;
            BTNRemoveExtra.Click += BTNRemoveExtra_Click;
            // 
            // CBCarExtras
            // 
            CBCarExtras.FormattingEnabled = true;
            CBCarExtras.Location = new Point(59, 40);
            CBCarExtras.Margin = new Padding(5, 4, 5, 4);
            CBCarExtras.Name = "CBCarExtras";
            CBCarExtras.Size = new Size(220, 28);
            CBCarExtras.TabIndex = 0;
            // 
            // LBExtras
            // 
            LBExtras.FormattingEnabled = true;
            LBExtras.Location = new Point(489, 416);
            LBExtras.Margin = new Padding(5, 4, 5, 4);
            LBExtras.Name = "LBExtras";
            LBExtras.Size = new Size(275, 184);
            LBExtras.TabIndex = 49;
            // 
            // BTNAddCar
            // 
            BTNAddCar.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddCar.Location = new Point(507, 737);
            BTNAddCar.Margin = new Padding(5, 4, 5, 4);
            BTNAddCar.Name = "BTNAddCar";
            BTNAddCar.Size = new Size(235, 73);
            BTNAddCar.TabIndex = 50;
            BTNAddCar.Text = "Add Car";
            BTNAddCar.UseVisualStyleBackColor = true;
            BTNAddCar.Click += BTNAddCar_Click;
            // 
            // NUDCarEngineSize
            // 
            NUDCarEngineSize.Location = new Point(174, 291);
            NUDCarEngineSize.Margin = new Padding(5, 4, 5, 4);
            NUDCarEngineSize.Maximum = new decimal(new int[] { 7000, 0, 0, 0 });
            NUDCarEngineSize.Minimum = new decimal(new int[] { 900, 0, 0, 0 });
            NUDCarEngineSize.Name = "NUDCarEngineSize";
            NUDCarEngineSize.Size = new Size(126, 27);
            NUDCarEngineSize.TabIndex = 51;
            NUDCarEngineSize.Value = new decimal(new int[] { 900, 0, 0, 0 });
            // 
            // NUDCarPower
            // 
            NUDCarPower.Location = new Point(145, 353);
            NUDCarPower.Margin = new Padding(5, 4, 5, 4);
            NUDCarPower.Maximum = new decimal(new int[] { 1500, 0, 0, 0 });
            NUDCarPower.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            NUDCarPower.Name = "NUDCarPower";
            NUDCarPower.Size = new Size(153, 27);
            NUDCarPower.TabIndex = 52;
            NUDCarPower.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LBPictures);
            groupBox2.Controls.Add(BTNAddPicture);
            groupBox2.Controls.Add(BTNRemovePicture);
            groupBox2.Controls.Add(CBPictureURL);
            groupBox2.Location = new Point(827, 239);
            groupBox2.Margin = new Padding(5, 4, 5, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 4, 5, 4);
            groupBox2.Size = new Size(318, 457);
            groupBox2.TabIndex = 49;
            groupBox2.TabStop = false;
            groupBox2.Text = "Car's pictures";
            // 
            // LBPictures
            // 
            LBPictures.FormattingEnabled = true;
            LBPictures.Location = new Point(22, 177);
            LBPictures.Margin = new Padding(5, 4, 5, 4);
            LBPictures.Name = "LBPictures";
            LBPictures.Size = new Size(275, 184);
            LBPictures.TabIndex = 53;
            // 
            // BTNAddPicture
            // 
            BTNAddPicture.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddPicture.Location = new Point(110, 89);
            BTNAddPicture.Margin = new Padding(5, 4, 5, 4);
            BTNAddPicture.Name = "BTNAddPicture";
            BTNAddPicture.Size = new Size(117, 56);
            BTNAddPicture.TabIndex = 1;
            BTNAddPicture.Text = "Add";
            BTNAddPicture.UseVisualStyleBackColor = true;
            BTNAddPicture.Click += BTNAddPicture_Click;
            // 
            // BTNRemovePicture
            // 
            BTNRemovePicture.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNRemovePicture.Location = new Point(105, 387);
            BTNRemovePicture.Margin = new Padding(5, 4, 5, 4);
            BTNRemovePicture.Name = "BTNRemovePicture";
            BTNRemovePicture.Size = new Size(117, 56);
            BTNRemovePicture.TabIndex = 2;
            BTNRemovePicture.Text = "Remove";
            BTNRemovePicture.UseVisualStyleBackColor = true;
            BTNRemovePicture.Click += BTNRemovePicture_Click;
            // 
            // CBPictureURL
            // 
            CBPictureURL.FormattingEnabled = true;
            CBPictureURL.Location = new Point(55, 40);
            CBPictureURL.Margin = new Padding(5, 4, 5, 4);
            CBPictureURL.Name = "CBPictureURL";
            CBPictureURL.Size = new Size(220, 28);
            CBPictureURL.TabIndex = 0;
            // 
            // AddCar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 839);
            Controls.Add(groupBox2);
            Controls.Add(NUDCarPower);
            Controls.Add(NUDCarEngineSize);
            Controls.Add(BTNAddCar);
            Controls.Add(LBExtras);
            Controls.Add(groupBox1);
            Controls.Add(label21);
            Controls.Add(TBCarPrice);
            Controls.Add(label20);
            Controls.Add(TBCarVIN);
            Controls.Add(label19);
            Controls.Add(TBCarColor);
            Controls.Add(label18);
            Controls.Add(RTBCarDescription);
            Controls.Add(TBCarNumOfDoors);
            Controls.Add(label1);
            Controls.Add(label17);
            Controls.Add(TBCarNumOfSeats);
            Controls.Add(label16);
            Controls.Add(CBCarGearbox);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(TBCarFuel);
            Controls.Add(label10);
            Controls.Add(NUDCarMileage);
            Controls.Add(label9);
            Controls.Add(DTPCarFirstReg);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(TBCarModel);
            Controls.Add(label7);
            Controls.Add(TBCarBrand);
            Margin = new Padding(5, 4, 5, 4);
            Name = "AddCar";
            Text = "AddCar";
            ((System.ComponentModel.ISupportInitialize)NUDCarMileage).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUDCarEngineSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUDCarPower).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.RichTextBox RTBCarDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBCarModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBCarBrand;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DTPCarFirstReg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown NUDCarMileage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TBCarFuel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CBCarGearbox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TBCarNumOfSeats;
        private System.Windows.Forms.TextBox TBCarNumOfDoors;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TBCarColor;
        private System.Windows.Forms.TextBox TBCarVIN;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TBCarPrice;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTNAddExtra;
        private System.Windows.Forms.ComboBox CBCarExtras;
        private System.Windows.Forms.ListBox LBExtras;
        private System.Windows.Forms.Button BTNRemoveExtra;
        private System.Windows.Forms.Button BTNAddCar;
        private System.Windows.Forms.NumericUpDown NUDCarEngineSize;
        private System.Windows.Forms.NumericUpDown NUDCarPower;
        private GroupBox groupBox2;
        private ListBox LBPictures;
        private Button BTNAddPicture;
        private Button BTNRemovePicture;
        private ComboBox CBPictureURL;
    }
}
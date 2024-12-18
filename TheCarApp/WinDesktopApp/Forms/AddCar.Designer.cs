﻿namespace WinDesktopApp.Forms
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
            label6 = new Label();
            TBCarModel = new TextBox();
            label7 = new Label();
            TBCarBrand = new TextBox();
            label8 = new Label();
            DTPCarFirstReg = new DateTimePicker();
            label9 = new Label();
            NUDCarMileage = new NumericUpDown();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            CBCarGearbox = new ComboBox();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            TBCarVIN = new TextBox();
            label19 = new Label();
            TBCarPrice = new TextBox();
            label20 = new Label();
            label21 = new Label();
            groupBox1 = new GroupBox();
            BTNAddExtra = new Button();
            BTNAddExtras = new Button();
            BTNRemoveExtra = new Button();
            CBCarExtras = new ComboBox();
            LBExtras = new ListBox();
            BTNAddCar = new Button();
            NUDCarEngineSize = new NumericUpDown();
            NUDCarPower = new NumericUpDown();
            groupBox2 = new GroupBox();
            BTNAddPics = new Button();
            LBPictures = new ListBox();
            BTNAddPicture = new Button();
            BTNRemovePicture = new Button();
            CBPictureURL = new ComboBox();
            groupBox3 = new GroupBox();
            CBFuelType = new ComboBox();
            TBColor = new TextBox();
            CBColor = new ComboBox();
            TBGearbox = new TextBox();
            groupBox4 = new GroupBox();
            BTNClose = new Button();
            NUDSeats = new NumericUpDown();
            CBDoors = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)NUDCarMileage).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUDCarEngineSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDCarPower).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUDSeats).BeginInit();
            SuspendLayout();
            // 
            // RTBCarDescription
            // 
            RTBCarDescription.Location = new Point(21, 33);
            RTBCarDescription.Margin = new Padding(4, 3, 4, 3);
            RTBCarDescription.Name = "RTBCarDescription";
            RTBCarDescription.Size = new Size(554, 82);
            RTBCarDescription.TabIndex = 11;
            RTBCarDescription.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 12F);
            label6.Location = new Point(29, 54);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(60, 18);
            label6.TabIndex = 22;
            label6.Text = "Model:";
            // 
            // TBCarModel
            // 
            TBCarModel.Location = new Point(132, 55);
            TBCarModel.Margin = new Padding(4, 3, 4, 3);
            TBCarModel.Name = "TBCarModel";
            TBCarModel.Size = new Size(287, 23);
            TBCarModel.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 12F);
            label7.Location = new Point(29, 18);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(62, 18);
            label7.TabIndex = 20;
            label7.Text = "Brand:";
            // 
            // TBCarBrand
            // 
            TBCarBrand.Location = new Point(132, 15);
            TBCarBrand.Margin = new Padding(4, 3, 4, 3);
            TBCarBrand.Name = "TBCarBrand";
            TBCarBrand.Size = new Size(287, 23);
            TBCarBrand.TabIndex = 19;
            TBCarBrand.TextChanged += TBCarBrand_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 12F);
            label8.Location = new Point(29, 94);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(146, 18);
            label8.TabIndex = 23;
            label8.Text = "First registration:";
            // 
            // DTPCarFirstReg
            // 
            DTPCarFirstReg.Location = new Point(191, 94);
            DTPCarFirstReg.Margin = new Padding(4, 3, 4, 3);
            DTPCarFirstReg.Name = "DTPCarFirstReg";
            DTPCarFirstReg.Size = new Size(228, 23);
            DTPCarFirstReg.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Rounded MT Bold", 12F);
            label9.Location = new Point(29, 130);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(74, 18);
            label9.TabIndex = 25;
            label9.Text = "Mileage:";
            // 
            // NUDCarMileage
            // 
            NUDCarMileage.Location = new Point(132, 132);
            NUDCarMileage.Margin = new Padding(4, 3, 4, 3);
            NUDCarMileage.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NUDCarMileage.Name = "NUDCarMileage";
            NUDCarMileage.Size = new Size(287, 23);
            NUDCarMileage.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Rounded MT Bold", 12F);
            label10.Location = new Point(29, 168);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(47, 18);
            label10.TabIndex = 27;
            label10.Text = "Fuel:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Rounded MT Bold", 12F);
            label11.Location = new Point(29, 213);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(103, 18);
            label11.TabIndex = 29;
            label11.Text = "Engine size:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial Rounded MT Bold", 12F);
            label12.Location = new Point(29, 258);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(64, 18);
            label12.TabIndex = 31;
            label12.Text = "Power:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial Rounded MT Bold", 12F);
            label13.Location = new Point(391, 258);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(28, 18);
            label13.TabIndex = 33;
            label13.Text = "hp";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial Rounded MT Bold", 12F);
            label14.Location = new Point(391, 213);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(28, 18);
            label14.TabIndex = 34;
            label14.Text = "cc";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial Rounded MT Bold", 12F);
            label15.Location = new Point(29, 297);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(81, 18);
            label15.TabIndex = 35;
            label15.Text = "Gearbox:";
            // 
            // CBCarGearbox
            // 
            CBCarGearbox.FormattingEnabled = true;
            CBCarGearbox.Items.AddRange(new object[] { "Manuel", "Automatic " });
            CBCarGearbox.Location = new Point(132, 298);
            CBCarGearbox.Margin = new Padding(4, 3, 4, 3);
            CBCarGearbox.Name = "CBCarGearbox";
            CBCarGearbox.Size = new Size(287, 23);
            CBCarGearbox.TabIndex = 36;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Arial Rounded MT Bold", 12F);
            label16.Location = new Point(29, 337);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(143, 18);
            label16.TabIndex = 37;
            label16.Text = "Number of seats:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial Rounded MT Bold", 12F);
            label17.Location = new Point(29, 376);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(145, 18);
            label17.TabIndex = 39;
            label17.Text = "Number of doors:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Arial Rounded MT Bold", 12F);
            label18.Location = new Point(29, 413);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(56, 18);
            label18.TabIndex = 41;
            label18.Text = "Color:";
            // 
            // TBCarVIN
            // 
            TBCarVIN.Location = new Point(132, 448);
            TBCarVIN.Margin = new Padding(4, 3, 4, 3);
            TBCarVIN.Name = "TBCarVIN";
            TBCarVIN.Size = new Size(287, 23);
            TBCarVIN.TabIndex = 44;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Arial Rounded MT Bold", 12F);
            label19.Location = new Point(29, 448);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(41, 18);
            label19.TabIndex = 43;
            label19.Text = "VIN:";
            // 
            // TBCarPrice
            // 
            TBCarPrice.Location = new Point(156, 486);
            TBCarPrice.Margin = new Padding(4, 3, 4, 3);
            TBCarPrice.Name = "TBCarPrice";
            TBCarPrice.Size = new Size(210, 23);
            TBCarPrice.TabIndex = 46;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Arial Rounded MT Bold", 12F);
            label20.Location = new Point(29, 486);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(119, 18);
            label20.TabIndex = 45;
            label20.Text = "Price per day:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Arial Rounded MT Bold", 12F);
            label21.Location = new Point(374, 486);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(45, 18);
            label21.TabIndex = 47;
            label21.Text = "euro";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(163, 177, 138);
            groupBox1.Controls.Add(BTNAddExtra);
            groupBox1.Controls.Add(BTNAddExtras);
            groupBox1.Controls.Add(BTNRemoveExtra);
            groupBox1.Controls.Add(CBCarExtras);
            groupBox1.Controls.Add(LBExtras);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 9.75F);
            groupBox1.Location = new Point(510, 179);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(278, 368);
            groupBox1.TabIndex = 48;
            groupBox1.TabStop = false;
            groupBox1.Text = "Car's extras";
            // 
            // BTNAddExtra
            // 
            BTNAddExtra.BackColor = Color.FromArgb(88, 129, 87);
            BTNAddExtra.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddExtra.ForeColor = Color.White;
            BTNAddExtra.Location = new Point(88, 126);
            BTNAddExtra.Margin = new Padding(4, 3, 4, 3);
            BTNAddExtra.Name = "BTNAddExtra";
            BTNAddExtra.Size = new Size(102, 42);
            BTNAddExtra.TabIndex = 1;
            BTNAddExtra.Text = "Add";
            BTNAddExtra.UseVisualStyleBackColor = false;
            BTNAddExtra.Click += BTNAddExtra_Click;
            // 
            // BTNAddExtras
            // 
            BTNAddExtras.BackColor = Color.FromArgb(88, 129, 87);
            BTNAddExtras.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddExtras.ForeColor = Color.White;
            BTNAddExtras.Location = new Point(74, 29);
            BTNAddExtras.Margin = new Padding(4, 3, 4, 3);
            BTNAddExtras.Name = "BTNAddExtras";
            BTNAddExtras.Size = new Size(146, 40);
            BTNAddExtras.TabIndex = 53;
            BTNAddExtras.Text = "Manage Extras";
            BTNAddExtras.UseVisualStyleBackColor = false;
            BTNAddExtras.Click += BTNAddExtras_Click;
            // 
            // BTNRemoveExtra
            // 
            BTNRemoveExtra.BackColor = Color.FromArgb(88, 129, 87);
            BTNRemoveExtra.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNRemoveExtra.ForeColor = Color.White;
            BTNRemoveExtra.Location = new Point(88, 318);
            BTNRemoveExtra.Margin = new Padding(4, 3, 4, 3);
            BTNRemoveExtra.Name = "BTNRemoveExtra";
            BTNRemoveExtra.Size = new Size(102, 42);
            BTNRemoveExtra.TabIndex = 2;
            BTNRemoveExtra.Text = "Remove";
            BTNRemoveExtra.UseVisualStyleBackColor = false;
            BTNRemoveExtra.Click += BTNRemoveExtra_Click;
            // 
            // CBCarExtras
            // 
            CBCarExtras.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBCarExtras.FormattingEnabled = true;
            CBCarExtras.Location = new Point(38, 88);
            CBCarExtras.Margin = new Padding(4, 3, 4, 3);
            CBCarExtras.Name = "CBCarExtras";
            CBCarExtras.Size = new Size(206, 22);
            CBCarExtras.TabIndex = 0;
            // 
            // LBExtras
            // 
            LBExtras.FormattingEnabled = true;
            LBExtras.ItemHeight = 15;
            LBExtras.Location = new Point(24, 174);
            LBExtras.Margin = new Padding(4, 3, 4, 3);
            LBExtras.Name = "LBExtras";
            LBExtras.Size = new Size(241, 139);
            LBExtras.TabIndex = 49;
            // 
            // BTNAddCar
            // 
            BTNAddCar.BackColor = Color.FromArgb(88, 129, 87);
            BTNAddCar.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddCar.ForeColor = Color.White;
            BTNAddCar.Location = new Point(353, 565);
            BTNAddCar.Margin = new Padding(4, 3, 4, 3);
            BTNAddCar.Name = "BTNAddCar";
            BTNAddCar.Size = new Size(206, 55);
            BTNAddCar.TabIndex = 50;
            BTNAddCar.Text = "Add Car";
            BTNAddCar.UseVisualStyleBackColor = false;
            BTNAddCar.Click += BTNAddCar_Click;
            // 
            // NUDCarEngineSize
            // 
            NUDCarEngineSize.Location = new Point(132, 213);
            NUDCarEngineSize.Margin = new Padding(4, 3, 4, 3);
            NUDCarEngineSize.Maximum = new decimal(new int[] { 7000, 0, 0, 0 });
            NUDCarEngineSize.Minimum = new decimal(new int[] { 900, 0, 0, 0 });
            NUDCarEngineSize.Name = "NUDCarEngineSize";
            NUDCarEngineSize.Size = new Size(251, 23);
            NUDCarEngineSize.TabIndex = 51;
            NUDCarEngineSize.Value = new decimal(new int[] { 900, 0, 0, 0 });
            // 
            // NUDCarPower
            // 
            NUDCarPower.Location = new Point(132, 260);
            NUDCarPower.Margin = new Padding(4, 3, 4, 3);
            NUDCarPower.Maximum = new decimal(new int[] { 1500, 0, 0, 0 });
            NUDCarPower.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            NUDCarPower.Name = "NUDCarPower";
            NUDCarPower.Size = new Size(251, 23);
            NUDCarPower.TabIndex = 52;
            NUDCarPower.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(163, 177, 138);
            groupBox2.Controls.Add(BTNAddPics);
            groupBox2.Controls.Add(LBPictures);
            groupBox2.Controls.Add(BTNAddPicture);
            groupBox2.Controls.Add(BTNRemovePicture);
            groupBox2.Controls.Add(CBPictureURL);
            groupBox2.Font = new Font("Arial Rounded MT Bold", 9.75F);
            groupBox2.Location = new Point(828, 179);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(278, 368);
            groupBox2.TabIndex = 49;
            groupBox2.TabStop = false;
            groupBox2.Text = "Car's pictures";
            // 
            // BTNAddPics
            // 
            BTNAddPics.BackColor = Color.FromArgb(88, 129, 87);
            BTNAddPics.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddPics.ForeColor = Color.White;
            BTNAddPics.Location = new Point(59, 29);
            BTNAddPics.Margin = new Padding(4, 3, 4, 3);
            BTNAddPics.Name = "BTNAddPics";
            BTNAddPics.Size = new Size(164, 40);
            BTNAddPics.TabIndex = 54;
            BTNAddPics.Text = "Manage pictures";
            BTNAddPics.UseVisualStyleBackColor = false;
            BTNAddPics.Click += BTNAddPics_Click;
            // 
            // LBPictures
            // 
            LBPictures.FormattingEnabled = true;
            LBPictures.ItemHeight = 15;
            LBPictures.Location = new Point(19, 174);
            LBPictures.Margin = new Padding(4, 3, 4, 3);
            LBPictures.Name = "LBPictures";
            LBPictures.Size = new Size(241, 139);
            LBPictures.TabIndex = 53;
            // 
            // BTNAddPicture
            // 
            BTNAddPicture.BackColor = Color.FromArgb(88, 129, 87);
            BTNAddPicture.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddPicture.ForeColor = Color.White;
            BTNAddPicture.Location = new Point(87, 126);
            BTNAddPicture.Margin = new Padding(4, 3, 4, 3);
            BTNAddPicture.Name = "BTNAddPicture";
            BTNAddPicture.Size = new Size(102, 42);
            BTNAddPicture.TabIndex = 1;
            BTNAddPicture.Text = "Add";
            BTNAddPicture.UseVisualStyleBackColor = false;
            BTNAddPicture.Click += BTNAddPicture_Click;
            // 
            // BTNRemovePicture
            // 
            BTNRemovePicture.BackColor = Color.FromArgb(88, 129, 87);
            BTNRemovePicture.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNRemovePicture.ForeColor = Color.White;
            BTNRemovePicture.Location = new Point(87, 318);
            BTNRemovePicture.Margin = new Padding(4, 3, 4, 3);
            BTNRemovePicture.Name = "BTNRemovePicture";
            BTNRemovePicture.Size = new Size(102, 42);
            BTNRemovePicture.TabIndex = 2;
            BTNRemovePicture.Text = "Remove";
            BTNRemovePicture.UseVisualStyleBackColor = false;
            BTNRemovePicture.Click += BTNRemovePicture_Click;
            // 
            // CBPictureURL
            // 
            CBPictureURL.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBPictureURL.FormattingEnabled = true;
            CBPictureURL.Location = new Point(40, 88);
            CBPictureURL.Margin = new Padding(4, 3, 4, 3);
            CBPictureURL.Name = "CBPictureURL";
            CBPictureURL.Size = new Size(200, 22);
            CBPictureURL.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(163, 177, 138);
            groupBox3.Controls.Add(CBDoors);
            groupBox3.Controls.Add(NUDSeats);
            groupBox3.Controls.Add(CBFuelType);
            groupBox3.Controls.Add(TBColor);
            groupBox3.Controls.Add(CBColor);
            groupBox3.Controls.Add(TBGearbox);
            groupBox3.Controls.Add(CBCarGearbox);
            groupBox3.Controls.Add(TBCarBrand);
            groupBox3.Controls.Add(NUDCarPower);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(NUDCarEngineSize);
            groupBox3.Controls.Add(TBCarModel);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(DTPCarFirstReg);
            groupBox3.Controls.Add(TBCarPrice);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(NUDCarMileage);
            groupBox3.Controls.Add(TBCarVIN);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label16);
            groupBox3.Font = new Font("Arial Rounded MT Bold", 9.75F);
            groupBox3.Location = new Point(25, 23);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(458, 524);
            groupBox3.TabIndex = 53;
            groupBox3.TabStop = false;
            // 
            // CBFuelType
            // 
            CBFuelType.FormattingEnabled = true;
            CBFuelType.Items.AddRange(new object[] { "Petrol", "Diesel", "Electric", "Hybrid" });
            CBFuelType.Location = new Point(132, 168);
            CBFuelType.Name = "CBFuelType";
            CBFuelType.Size = new Size(287, 23);
            CBFuelType.TabIndex = 56;
            // 
            // TBColor
            // 
            TBColor.Location = new Point(132, 413);
            TBColor.Name = "TBColor";
            TBColor.Size = new Size(287, 23);
            TBColor.TabIndex = 55;
            // 
            // CBColor
            // 
            CBColor.FormattingEnabled = true;
            CBColor.Location = new Point(132, 413);
            CBColor.Name = "CBColor";
            CBColor.Size = new Size(287, 23);
            CBColor.TabIndex = 54;
            // 
            // TBGearbox
            // 
            TBGearbox.Location = new Point(132, 298);
            TBGearbox.Name = "TBGearbox";
            TBGearbox.Size = new Size(287, 23);
            TBGearbox.TabIndex = 53;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.FromArgb(163, 177, 138);
            groupBox4.Controls.Add(RTBCarDescription);
            groupBox4.Font = new Font("Arial Rounded MT Bold", 12F);
            groupBox4.Location = new Point(510, 23);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(596, 139);
            groupBox4.TabIndex = 54;
            groupBox4.TabStop = false;
            groupBox4.Text = "Description:";
            // 
            // BTNClose
            // 
            BTNClose.BackColor = Color.FromArgb(88, 129, 87);
            BTNClose.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNClose.ForeColor = Color.White;
            BTNClose.Location = new Point(584, 565);
            BTNClose.Margin = new Padding(4, 3, 4, 3);
            BTNClose.Name = "BTNClose";
            BTNClose.Size = new Size(206, 55);
            BTNClose.TabIndex = 55;
            BTNClose.Text = "Close form";
            BTNClose.UseVisualStyleBackColor = false;
            BTNClose.Click += BTNClose_Click_1;
            // 
            // NUDSeats
            // 
            NUDSeats.Location = new Point(203, 338);
            NUDSeats.Margin = new Padding(4, 3, 4, 3);
            NUDSeats.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NUDSeats.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            NUDSeats.Name = "NUDSeats";
            NUDSeats.Size = new Size(216, 23);
            NUDSeats.TabIndex = 57;
            NUDSeats.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // CBDoors
            // 
            CBDoors.FormattingEnabled = true;
            CBDoors.Items.AddRange(new object[] { "2/3", "4/5" });
            CBDoors.Location = new Point(203, 371);
            CBDoors.Name = "CBDoors";
            CBDoors.Size = new Size(216, 23);
            CBDoors.TabIndex = 58;
            // 
            // AddCar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(1130, 629);
            Controls.Add(BTNClose);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(BTNAddCar);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddCar";
            Text = "AddCar";
            ((System.ComponentModel.ISupportInitialize)NUDCarMileage).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUDCarEngineSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUDCarPower).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUDSeats).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.RichTextBox RTBCarDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBCarModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBCarBrand;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DTPCarFirstReg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown NUDCarMileage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CBCarGearbox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
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
        private Button BTNAddExtras;
        private Button BTNAddPics;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button BTNClose;
        private TextBox TBGearbox;
        private TextBox TBColor;
        private ComboBox CBColor;
        private ComboBox CBFuelType;
        private ComboBox CBDoors;
        private NumericUpDown NUDSeats;
    }
}
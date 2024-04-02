namespace DesktopApp
{
    partial class ControlPage
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BTNComments = new System.Windows.Forms.Button();
            this.BTNCarControl = new System.Windows.Forms.Button();
            this.BTNCarNews = new System.Windows.Forms.Button();
            this.BTNControlAdminInfo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Lime;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BTNComments, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.BTNCarControl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.BTNCarNews, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BTNControlAdminInfo, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 317);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BTNComments
            // 
            this.BTNComments.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BTNComments.Location = new System.Drawing.Point(3, 161);
            this.BTNComments.Name = "BTNComments";
            this.BTNComments.Size = new System.Drawing.Size(194, 70);
            this.BTNComments.TabIndex = 2;
            this.BTNComments.Text = "Comments";
            this.BTNComments.UseVisualStyleBackColor = true;
            this.BTNComments.Click += new System.EventHandler(this.BTNComments_Click);
            // 
            // BTNCarControl
            // 
            this.BTNCarControl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BTNCarControl.Location = new System.Drawing.Point(3, 240);
            this.BTNCarControl.Name = "BTNCarControl";
            this.BTNCarControl.Size = new System.Drawing.Size(194, 73);
            this.BTNCarControl.TabIndex = 3;
            this.BTNCarControl.Text = "Car Control";
            this.BTNCarControl.UseVisualStyleBackColor = true;
            this.BTNCarControl.Click += new System.EventHandler(this.BTNCarControl_Click);
            // 
            // BTNCarNews
            // 
            this.BTNCarNews.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BTNCarNews.Location = new System.Drawing.Point(3, 82);
            this.BTNCarNews.Name = "BTNCarNews";
            this.BTNCarNews.Size = new System.Drawing.Size(194, 73);
            this.BTNCarNews.TabIndex = 1;
            this.BTNCarNews.Text = "Car News";
            this.BTNCarNews.UseVisualStyleBackColor = true;
            this.BTNCarNews.Click += new System.EventHandler(this.BTNCarNews_Click);
            // 
            // BTNControlAdminInfo
            // 
            this.BTNControlAdminInfo.BackColor = System.Drawing.Color.Transparent;
            this.BTNControlAdminInfo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNControlAdminInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTNControlAdminInfo.Location = new System.Drawing.Point(3, 3);
            this.BTNControlAdminInfo.Name = "BTNControlAdminInfo";
            this.BTNControlAdminInfo.Size = new System.Drawing.Size(194, 73);
            this.BTNControlAdminInfo.TabIndex = 0;
            this.BTNControlAdminInfo.Text = "Admin Info";
            this.BTNControlAdminInfo.UseVisualStyleBackColor = false;
            this.BTNControlAdminInfo.Click += new System.EventHandler(this.BTNControlAdminInfo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 448);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(204, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 448);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DesktopApp.Properties.Resources.brabus;
            this.pictureBox1.Location = new System.Drawing.Point(181, 203);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to admin page";
            // 
            // ControlPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 449);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "ControlPage";
            this.Text = "ControlPage";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BTNCarNews;
        private System.Windows.Forms.Button BTNControlAdminInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTNComments;
        private System.Windows.Forms.Button BTNCarControl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
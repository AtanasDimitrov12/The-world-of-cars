﻿namespace DesktopApp
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
            tableLayoutPanel1 = new TableLayoutPanel();
            BTNComments = new Button();
            BTNCarControl = new Button();
            BTNCarNews = new Button();
            BTNControlAdminInfo = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Lime;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(BTNComments, 0, 2);
            tableLayoutPanel1.Controls.Add(BTNCarControl, 0, 3);
            tableLayoutPanel1.Controls.Add(BTNCarNews, 0, 1);
            tableLayoutPanel1.Controls.Add(BTNControlAdminInfo, 0, 0);
            tableLayoutPanel1.Location = new Point(1, 75);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.Size = new Size(233, 366);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // BTNComments
            // 
            BTNComments.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNComments.Location = new Point(4, 185);
            BTNComments.Margin = new Padding(4, 3, 4, 3);
            BTNComments.Name = "BTNComments";
            BTNComments.Size = new Size(225, 81);
            BTNComments.TabIndex = 2;
            BTNComments.Text = "Comments";
            BTNComments.UseVisualStyleBackColor = true;
            BTNComments.Click += BTNComments_Click;
            // 
            // BTNCarControl
            // 
            BTNCarControl.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNCarControl.Location = new Point(4, 276);
            BTNCarControl.Margin = new Padding(4, 3, 4, 3);
            BTNCarControl.Name = "BTNCarControl";
            BTNCarControl.Size = new Size(225, 84);
            BTNCarControl.TabIndex = 3;
            BTNCarControl.Text = "Car Control";
            BTNCarControl.UseVisualStyleBackColor = true;
            BTNCarControl.Click += BTNCarControl_Click;
            // 
            // BTNCarNews
            // 
            BTNCarNews.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNCarNews.Location = new Point(4, 94);
            BTNCarNews.Margin = new Padding(4, 3, 4, 3);
            BTNCarNews.Name = "BTNCarNews";
            BTNCarNews.Size = new Size(225, 84);
            BTNCarNews.TabIndex = 1;
            BTNCarNews.Text = "Car News";
            BTNCarNews.UseVisualStyleBackColor = true;
            BTNCarNews.Click += BTNCarNews_Click;
            // 
            // BTNControlAdminInfo
            // 
            BTNControlAdminInfo.BackColor = Color.Transparent;
            BTNControlAdminInfo.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNControlAdminInfo.ForeColor = SystemColors.ControlText;
            BTNControlAdminInfo.Location = new Point(4, 3);
            BTNControlAdminInfo.Margin = new Padding(4, 3, 4, 3);
            BTNControlAdminInfo.Name = "BTNControlAdminInfo";
            BTNControlAdminInfo.Size = new Size(225, 84);
            BTNControlAdminInfo.TabIndex = 0;
            BTNControlAdminInfo.Text = "Admin Info";
            BTNControlAdminInfo.UseVisualStyleBackColor = false;
            BTNControlAdminInfo.Click += BTNControlAdminInfo_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 517);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Location = new Point(238, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(728, 517);
            panel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(161, 158);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(387, 37);
            label1.TabIndex = 0;
            label1.Text = "Welcome to admin page";
            // 
            // ControlPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 518);
            Controls.Add(panel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ControlPage";
            Text = "ControlPage";
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BTNCarNews;
        private System.Windows.Forms.Button BTNControlAdminInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTNComments;
        private System.Windows.Forms.Button BTNCarControl;
        private System.Windows.Forms.Label label1;
    }
}
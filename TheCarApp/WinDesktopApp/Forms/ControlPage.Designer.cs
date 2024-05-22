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
            tableLayoutPanel1.BackColor = Color.FromArgb(52, 78, 65);
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(BTNComments, 0, 2);
            tableLayoutPanel1.Controls.Add(BTNCarControl, 0, 3);
            tableLayoutPanel1.Controls.Add(BTNCarNews, 0, 1);
            tableLayoutPanel1.Controls.Add(BTNControlAdminInfo, 0, 0);
            tableLayoutPanel1.Location = new Point(1, 100);
            tableLayoutPanel1.Margin = new Padding(5, 4, 5, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel1.Size = new Size(275, 488);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // BTNComments
            // 
            BTNComments.BackColor = Color.FromArgb(163, 177, 138);
            BTNComments.Font = new Font("Arial Rounded MT Bold", 14.25F);
            BTNComments.ForeColor = Color.White;
            BTNComments.Location = new Point(5, 248);
            BTNComments.Margin = new Padding(5, 4, 5, 4);
            BTNComments.Name = "BTNComments";
            BTNComments.Size = new Size(265, 113);
            BTNComments.TabIndex = 2;
            BTNComments.Text = "Comments";
            BTNComments.UseVisualStyleBackColor = false;
            BTNComments.Click += BTNComments_Click;
            // 
            // BTNCarControl
            // 
            BTNCarControl.BackColor = Color.FromArgb(163, 177, 138);
            BTNCarControl.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNCarControl.ForeColor = Color.White;
            BTNCarControl.Location = new Point(5, 370);
            BTNCarControl.Margin = new Padding(5, 4, 5, 4);
            BTNCarControl.Name = "BTNCarControl";
            BTNCarControl.Size = new Size(265, 114);
            BTNCarControl.TabIndex = 3;
            BTNCarControl.Text = "Car Control";
            BTNCarControl.UseVisualStyleBackColor = false;
            BTNCarControl.Click += BTNCarControl_Click;
            // 
            // BTNCarNews
            // 
            BTNCarNews.BackColor = Color.FromArgb(163, 177, 138);
            BTNCarNews.Font = new Font("Arial Rounded MT Bold", 14.25F);
            BTNCarNews.ForeColor = Color.White;
            BTNCarNews.Location = new Point(5, 126);
            BTNCarNews.Margin = new Padding(5, 4, 5, 4);
            BTNCarNews.Name = "BTNCarNews";
            BTNCarNews.Size = new Size(265, 113);
            BTNCarNews.TabIndex = 1;
            BTNCarNews.Text = "Car News";
            BTNCarNews.UseVisualStyleBackColor = false;
            BTNCarNews.Click += BTNCarNews_Click;
            // 
            // BTNControlAdminInfo
            // 
            BTNControlAdminInfo.BackColor = Color.FromArgb(163, 177, 138);
            BTNControlAdminInfo.Font = new Font("Arial Rounded MT Bold", 14.25F);
            BTNControlAdminInfo.ForeColor = Color.White;
            BTNControlAdminInfo.Location = new Point(5, 4);
            BTNControlAdminInfo.Margin = new Padding(5, 4, 5, 4);
            BTNControlAdminInfo.Name = "BTNControlAdminInfo";
            BTNControlAdminInfo.Size = new Size(265, 113);
            BTNControlAdminInfo.TabIndex = 0;
            BTNControlAdminInfo.Text = "Admin Info";
            BTNControlAdminInfo.UseVisualStyleBackColor = false;
            BTNControlAdminInfo.Click += BTNControlAdminInfo_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(52, 78, 65);
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(5, 4, 5, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(275, 689);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(218, 215, 205);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(280, 0);
            panel2.Margin = new Padding(5, 4, 5, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1379, 689);
            panel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(435, 167);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(485, 46);
            label1.TabIndex = 0;
            label1.Text = "Welcome to admin page";
            // 
            // ControlPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(1661, 691);
            Controls.Add(panel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Margin = new Padding(5, 4, 5, 4);
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
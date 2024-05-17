﻿namespace WinDesktopApp.Forms
{
    partial class AddExtra
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
            BTNAddExtra = new Button();
            RTBExtraName = new RichTextBox();
            label1 = new Label();
            DGVExtras = new DataGridView();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)DGVExtras).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // BTNAddExtra
            // 
            BTNAddExtra.Font = new Font("Arial Rounded MT Bold", 12F);
            BTNAddExtra.Location = new Point(60, 245);
            BTNAddExtra.Margin = new Padding(3, 4, 3, 4);
            BTNAddExtra.Name = "BTNAddExtra";
            BTNAddExtra.Size = new Size(205, 77);
            BTNAddExtra.TabIndex = 0;
            BTNAddExtra.Text = "Add";
            BTNAddExtra.UseVisualStyleBackColor = true;
            BTNAddExtra.Click += BTNAddExtra_Click;
            // 
            // RTBExtraName
            // 
            RTBExtraName.Location = new Point(25, 118);
            RTBExtraName.Margin = new Padding(3, 4, 3, 4);
            RTBExtraName.Name = "RTBExtraName";
            RTBExtraName.Size = new Size(290, 91);
            RTBExtraName.TabIndex = 1;
            RTBExtraName.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(82, 46);
            label1.Name = "label1";
            label1.Size = new Size(156, 23);
            label1.TabIndex = 2;
            label1.Text = "Type the extra:";
            // 
            // DGVExtras
            // 
            DGVExtras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVExtras.Location = new Point(421, 45);
            DGVExtras.Name = "DGVExtras";
            DGVExtras.RowHeadersWidth = 51;
            DGVExtras.Size = new Size(491, 415);
            DGVExtras.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BTNAddExtra);
            groupBox1.Controls.Add(RTBExtraName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(343, 338);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add new Extra";
            // 
            // AddExtra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 493);
            Controls.Add(groupBox1);
            Controls.Add(DGVExtras);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddExtra";
            Text = "AddExtra";
            ((System.ComponentModel.ISupportInitialize)DGVExtras).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BTNAddExtra;
        private RichTextBox RTBExtraName;
        private Label label1;
        private DataGridView DGVExtras;
        private GroupBox groupBox1;
    }
}
﻿namespace WallpaperSwitcher
{
    partial class IdentityForm
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
            label1 = new OutlinedLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 300F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(532, 42);
            label1.Name = "label1";
            label1.OutlineForeColor = Color.White;
            label1.OutlineWidth = 10F;
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(438, 532);
            label1.TabIndex = 0;
            label1.Text = "1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IdentityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 583);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "IdentityForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "IdentityForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OutlinedLabel label1;
    }
}
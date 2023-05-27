namespace WallpaperSwitcher.Forms
{
    partial class SettingsForm
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
            label1 = new Label();
            numIdentificationTimeout = new NumericUpDown();
            label2 = new Label();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numIdentificationTimeout).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(176, 17);
            label1.TabIndex = 0;
            label1.Text = "Screen identification timeout:";
            // 
            // numIdentificationTimeout
            // 
            numIdentificationTimeout.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numIdentificationTimeout.Location = new Point(194, 26);
            numIdentificationTimeout.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numIdentificationTimeout.Minimum = new decimal(new int[] { 500, 0, 0, 0 });
            numIdentificationTimeout.Name = "numIdentificationTimeout";
            numIdentificationTimeout.Size = new Size(58, 25);
            numIdentificationTimeout.TabIndex = 1;
            numIdentificationTimeout.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(258, 28);
            label2.Name = "label2";
            label2.Size = new Size(25, 17);
            label2.TabIndex = 2;
            label2.Text = "ms";
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.OK;
            button2.Location = new Point(424, 230);
            button2.Name = "button2";
            button2.Size = new Size(83, 25);
            button2.TabIndex = 4;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(335, 230);
            button1.Name = "button1";
            button1.Size = new Size(83, 25);
            button1.TabIndex = 5;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AcceptButton = button2;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button1;
            ClientSize = new Size(519, 267);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(numIdentificationTimeout);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)numIdentificationTimeout).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numIdentificationTimeout;
        private Label label2;
        private Button button2;
        private Button button1;
    }
}
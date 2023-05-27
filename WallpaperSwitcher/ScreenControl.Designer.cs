namespace WallpaperSwitcher
{
    partial class ScreenControl
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
            components = new System.ComponentModel.Container();
            pbPreview = new PictureBox();
            lblInfo = new Label();
            toolTip1 = new ToolTip(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            identifyToolStripMenuItem = new ToolStripMenuItem();
            outlinedLabel1 = new OutlinedLabel();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pbPreview
            // 
            pbPreview.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbPreview.Cursor = Cursors.Hand;
            pbPreview.Image = Properties.Resources.monitor;
            pbPreview.Location = new Point(3, 3);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(188, 144);
            pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pbPreview.TabIndex = 1;
            pbPreview.TabStop = false;
            pbPreview.MouseHover += pbPreview_MouseHover;
            // 
            // lblInfo
            // 
            lblInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblInfo.Location = new Point(3, 151);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(188, 72);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "Details";
            lblInfo.TextAlign = ContentAlignment.TopCenter;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(18, 18);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { identifyToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(119, 26);
            // 
            // identifyToolStripMenuItem
            // 
            identifyToolStripMenuItem.Name = "identifyToolStripMenuItem";
            identifyToolStripMenuItem.Size = new Size(118, 22);
            identifyToolStripMenuItem.Text = "Identify";
            // 
            // outlinedLabel1
            // 
            outlinedLabel1.BackColor = Color.Transparent;
            outlinedLabel1.Font = new Font("Segoe UI", 64F, FontStyle.Bold, GraphicsUnit.Point);
            outlinedLabel1.ForeColor = Color.Black;
            outlinedLabel1.Location = new Point(-3, 0);
            outlinedLabel1.Name = "outlinedLabel1";
            outlinedLabel1.OutlineForeColor = Color.White;
            outlinedLabel1.OutlineWidth = 10F;
            outlinedLabel1.Size = new Size(194, 115);
            outlinedLabel1.TabIndex = 3;
            outlinedLabel1.Text = "1";
            outlinedLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ScreenControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(outlinedLabel1);
            Controls.Add(lblInfo);
            Controls.Add(pbPreview);
            Name = "ScreenControl";
            Size = new Size(194, 235);
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pbPreview;
        private Label lblInfo;
        private ToolTip toolTip1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem identifyToolStripMenuItem;
        private OutlinedLabel outlinedLabel1;
    }
}

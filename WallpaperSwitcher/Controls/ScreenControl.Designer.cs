using WallpaperSwitcher.Controls;

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
            toolTip1 = new ToolTip(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            identifyToolStripMenuItem = new ToolStripMenuItem();
            lblId = new OutlinedLabel();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pbPreview
            // 
            pbPreview.Cursor = Cursors.Hand;
            pbPreview.Dock = DockStyle.Fill;
            pbPreview.Location = new Point(3, 3);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(342, 190);
            pbPreview.TabIndex = 1;
            pbPreview.TabStop = false;
            pbPreview.Click += pbPreview_Click;
            pbPreview.MouseEnter += pbPreview_MouseEnter;
            pbPreview.MouseLeave += pbPreview_MouseLeave;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(18, 18);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { identifyToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(115, 26);
            // 
            // identifyToolStripMenuItem
            // 
            identifyToolStripMenuItem.Name = "identifyToolStripMenuItem";
            identifyToolStripMenuItem.Size = new Size(114, 22);
            identifyToolStripMenuItem.Text = "Identify";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.BackColor = Color.Transparent;
            lblId.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point);
            lblId.ForeColor = Color.Black;
            lblId.Location = new Point(13, 13);
            lblId.Margin = new Padding(10, 10, 0, 0);
            lblId.Name = "lblId";
            lblId.OutlineForeColor = Color.White;
            lblId.OutlineWidth = 5F;
            lblId.Size = new Size(50, 59);
            lblId.TabIndex = 3;
            lblId.Text = "1";
            lblId.TextAlign = ContentAlignment.MiddleCenter;
            lblId.Visible = false;
            // 
            // ScreenControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblId);
            Controls.Add(pbPreview);
            Name = "ScreenControl";
            Padding = new Padding(3);
            Size = new Size(348, 196);
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pbPreview;
        private ToolTip toolTip1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem identifyToolStripMenuItem;
        private OutlinedLabel lblId;
    }
}

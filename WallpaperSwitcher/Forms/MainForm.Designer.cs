namespace WallpaperSwitcher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            reloadScreensToolStripMenuItem = new ToolStripMenuItem();
            identifyScreensToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            displaySettingsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblScreens = new ToolStripStatusLabel();
            button1 = new Button();
            button2 = new Button();
            btnDisplaySettings = new Button();
            screenLayoutPanel1 = new Controls.ScreenLayoutPanel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(18, 18);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(670, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reloadScreensToolStripMenuItem, identifyScreensToolStripMenuItem, toolStripSeparator1, displaySettingsToolStripMenuItem, settingsToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // reloadScreensToolStripMenuItem
            // 
            reloadScreensToolStripMenuItem.Name = "reloadScreensToolStripMenuItem";
            reloadScreensToolStripMenuItem.Size = new Size(166, 22);
            reloadScreensToolStripMenuItem.Text = "Reload Screens";
            reloadScreensToolStripMenuItem.Click += LoadScreens;
            // 
            // identifyScreensToolStripMenuItem
            // 
            identifyScreensToolStripMenuItem.Name = "identifyScreensToolStripMenuItem";
            identifyScreensToolStripMenuItem.Size = new Size(166, 22);
            identifyScreensToolStripMenuItem.Text = "Identify Screens";
            identifyScreensToolStripMenuItem.Click += IdentifyScreens;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(163, 6);
            // 
            // displaySettingsToolStripMenuItem
            // 
            displaySettingsToolStripMenuItem.Name = "displaySettingsToolStripMenuItem";
            displaySettingsToolStripMenuItem.Size = new Size(166, 22);
            displaySettingsToolStripMenuItem.Text = "Display Settings...";
            displaySettingsToolStripMenuItem.Click += OpenDisplaySettings;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(166, 22);
            settingsToolStripMenuItem.Text = "Settings...";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(163, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(166, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(116, 22);
            aboutToolStripMenuItem.Text = "About...";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(18, 18);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblScreens });
            statusStrip1.Location = new Point(0, 385);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(670, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblScreens
            // 
            lblScreens.Name = "lblScreens";
            lblScreens.Size = new Size(59, 17);
            lblScreens.Text = "Screens: 0";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(12, 336);
            button1.Name = "button1";
            button1.Size = new Size(121, 37);
            button1.TabIndex = 3;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += LoadScreens;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(139, 336);
            button2.Name = "button2";
            button2.Size = new Size(121, 37);
            button2.TabIndex = 4;
            button2.Text = "Identify";
            button2.UseVisualStyleBackColor = true;
            button2.Click += IdentifyScreens;
            // 
            // btnDisplaySettings
            // 
            btnDisplaySettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDisplaySettings.Location = new Point(537, 336);
            btnDisplaySettings.Name = "btnDisplaySettings";
            btnDisplaySettings.Size = new Size(121, 37);
            btnDisplaySettings.TabIndex = 5;
            btnDisplaySettings.Text = "Display Settings...";
            btnDisplaySettings.UseVisualStyleBackColor = true;
            btnDisplaySettings.Click += OpenDisplaySettings;
            // 
            // screenLayoutPanel1
            // 
            screenLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            screenLayoutPanel1.Location = new Point(12, 27);
            screenLayoutPanel1.Name = "screenLayoutPanel1";
            screenLayoutPanel1.ShowScreenModels = true;
            screenLayoutPanel1.ShowScreenNumbers = true;
            screenLayoutPanel1.ShowWallpaperPreviews = true;
            screenLayoutPanel1.Size = new Size(646, 303);
            screenLayoutPanel1.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 407);
            Controls.Add(screenLayoutPanel1);
            Controls.Add(btnDisplaySettings);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wallpaper Switcher";
            SizeChanged += MainForm_SizeChanged;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem reloadScreensToolStripMenuItem;
        private ToolStripMenuItem identifyScreensToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblScreens;
        private FlowLayoutPanel flowLayoutPanel1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private Button button1;
        private Button button2;
        private Button btnDisplaySettings;
        private ToolStripMenuItem displaySettingsToolStripMenuItem;
        private Controls.ScreenLayoutPanel screenLayoutPanel1;
    }
}
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using WallpaperSwitcher.Forms;
using WallpaperSwitcher.Utils;
using static WallpaperSwitcher.ManagedScreen;

namespace WallpaperSwitcher
{
    public partial class MainForm : Form
    {
        private List<ManagedScreen> managedScreens = new List<ManagedScreen>();
        private List<ScreenControl> screenControls = new List<ScreenControl>();
        public MainForm()
        {
            InitializeComponent();

            CreateScreenControls();
            DrawScreens(true);
        }

        private void DrawScreens(bool refreshPreview)
        {
            double PreviewScale = 1f;

            // build the virtual screen
            Rectangle rectangle = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);
            foreach (var screen in managedScreens)
            {
                rectangle = Rectangle.Union(rectangle, screen.Screen.Bounds);
            }
            var virtualScreen = rectangle;

            double workingAreaHeight = (float)panel1.Height / (float)virtualScreen.Height;
            double workingAreaWidth = (float)panel1.Width / (float)virtualScreen.Width;

            double scaling = Math.Min(workingAreaHeight, workingAreaWidth) * PreviewScale;

            int num2 = (int)(((double)panel1.Width - (double)(float)virtualScreen.Width * scaling) / 2.0);
            int num3 = (int)(((double)panel1.Height - (double)(float)virtualScreen.Height * scaling) / 2.0);

            for (int i = 0; i < managedScreens.Count(); i++)
            {
                ManagedScreen? screen = managedScreens[i];

                int x = (int)((double)(screen.Screen.Bounds.Location.X + Math.Abs(virtualScreen.X)) * scaling) + num2;
                int y = (int)((double)(screen.Screen.Bounds.Location.Y + Math.Abs(virtualScreen.Y)) * scaling) + num3;
                int width = (int)((double)screen.Screen.Bounds.Width * scaling);
                int height = (int)((double)screen.Screen.Bounds.Height * scaling);

                var control = screenControls[i];

                Debug.WriteLine($"Screen {i} - X: {x}, Y: {y}, Width: {width}, Height: {height}");

                control.SetBounds(x, y, width, height);

                if (refreshPreview)
                    control.RefreshPreview();

                /*
                var wallpaper = (IDesktopWallpaper)new DesktopWallpaperClass();
                var monitorId = wallpaper.GetMonitorDevicePathAt(i);
                var wallpaperRect = wallpaper.GetMonitorRECT(monitorId);
                var wallpaperPath = wallpaper.GetWallpaper(monitorId);

                using (var wImg = Image.FromFile(wallpaperPath))
                {
                    var resized = (Image)new Bitmap(wImg, new Size(button.Width, button.Height));
                    button.Image = resized;
                }*/

                panel1.Controls.Add(control);
            }
        }

        private void CreateScreenControls()
        {
            Screen[] screens = Screen.AllScreens;

            managedScreens.Clear();
            panel1.Controls.Clear();
            screenControls.Clear();

            for (uint i = 0; i < screens.Length; i++)
            {
                var userFriendlyId = i + 1;
                ManagedScreen screen = new ManagedScreen(screens[i], userFriendlyId);
                var control = CreateScreenControl(screen);
                control.RefreshPreview();
                control.Margin = new Padding(5);

                managedScreens.Add(screen);
                panel1.Controls.Add(control);
                screenControls.Add(control);
            }

            lblScreens.Text = $"Screens: {managedScreens.Count}";
        }

        private void reloadScreensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateScreenControls();
            DrawScreens(true);

        }

        private async void identifyScreensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var screen in managedScreens)
            {
                ShowIdentification(screen);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private ScreenControl CreateScreenControl(ManagedScreen screen)
        {
            ScreenControl screenControl = new ScreenControl(screen);
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            var identifyMenuItem = new ToolStripMenuItem() { Text = "Identify" };
            identifyMenuItem.Click += (s, e) => ShowIdentification(screen);
            contextMenu.Items.Add(identifyMenuItem);

            var locateMenuItem = new ToolStripMenuItem() { Text = "Open in Explorer" };
            locateMenuItem.Click += (s, e) => Process.Start("explorer.exe", $"/select, \"{screenControl.GetWallpaperPath()}\"");
            contextMenu.Items.Add(locateMenuItem);

            screenControl.ContextMenuStrip = contextMenu;
            return screenControl;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SettingsForm())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void ShowIdentification(ManagedScreen screen)
        {
            IdentityForm identityForm = new IdentityForm(screen, 2000);
            identityForm.Show();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            DrawScreens(true);
        }
    }
}
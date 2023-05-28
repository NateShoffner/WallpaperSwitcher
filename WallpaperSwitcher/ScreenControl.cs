using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using WallpaperSwitcher.Utils;

namespace WallpaperSwitcher
{
    public partial class ScreenControl : UserControl
    {
        public ScreenControl()
        {
            InitializeComponent();
        }

        public ScreenControl(ManagedScreen screen) : this()
        {
            Screen = screen;

            lblId.Parent = pbPreview;
            lblId.Text = screen.Id.ToString();

            lblInfo.Parent = pbPreview;

            var infoBuilder = new StringBuilder();
            infoBuilder.AppendLine(screen.Screen.DeviceFriendlyName());
            if (screen.Screen.Primary)
            {
                infoBuilder.AppendLine("(Primary)");
            }
            infoBuilder.AppendLine();
            lblInfo.Text = infoBuilder.ToString();

            var toolTipBuilder = new StringBuilder();
            toolTipBuilder.AppendLine($"Refresh Rate: {screen.ScreenSettings.dmDisplayFrequency}hz");
            toolTipBuilder.Append($"Resolution: {screen.Screen.Bounds.Width}x{screen.Screen.Bounds.Height}");

            if (screen.ScreenSettings.dmDisplayOrientation != ScreenOrientation.Angle0)
            {
                switch (screen.ScreenSettings.dmDisplayOrientation)
                {
                    case ScreenOrientation.Angle90:
                        toolTipBuilder.Append(" (Portrait)");
                        break;
                    case ScreenOrientation.Angle180:
                        toolTipBuilder.Append(" (Upside Down)");
                        break;
                    case ScreenOrientation.Angle270:
                        toolTipBuilder.Append(" (Portrait Upside Down)");
                        break;
                }
            }

            toolTip1.SetToolTip(pbPreview, toolTipBuilder.ToString());
        }

        public void RefreshPreview()
        {
            pbPreview.Image = DrawScreenPreview();
        }

        private Image DrawScreenPreview()
        {
            // live view of wallpaper
            var wallpaper = (IDesktopWallpaper)new DesktopWallpaperClass();
            var monitorId = wallpaper.GetMonitorDevicePathAt((uint)Screen.Id - 1);
            var wallpaperRect = wallpaper.GetMonitorRECT(monitorId);
            var wallpaperPath = wallpaper.GetWallpaper(monitorId);

            using (var wImg = Image.FromFile(wallpaperPath))
            {
                var resized = wImg.GetThumbnailImage(pbPreview.Width, pbPreview.Height, null, IntPtr.Zero);
                return resized;
            }
        }

        private void pbPreview_MouseLeave(object sender, EventArgs e)
        {
            lblId.Visible = false;
            lblInfo.Visible = true;
        }

        private void pbPreview_MouseEnter(object sender, EventArgs e)
        {
            lblId.Visible = true;
            lblInfo.Visible = false;
        }

        private void pbPreview_Click(object sender, EventArgs e)
        {
            // support iamge types
            using (var ofd = new OpenFileDialog()
            {
                Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png",
                Title = "Select Wallpaper"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var wallpaper = (IDesktopWallpaper)new DesktopWallpaperClass();
                    var monitorId = wallpaper.GetMonitorDevicePathAt((uint)Screen.Id - 1);
                    wallpaper.SetWallpaper(monitorId, ofd.FileName);
                    RefreshPreview();
                }
            }
        }

        private void ScreenControl_Paint(object sender, PaintEventArgs e)
        {
            const int BORDER_SIZE = 3;

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, SystemColors.WindowFrame, BORDER_SIZE, ButtonBorderStyle.Inset,
                                  SystemColors.WindowFrame, BORDER_SIZE, ButtonBorderStyle.Inset,
                                  SystemColors.WindowFrame, BORDER_SIZE, ButtonBorderStyle.Inset,
                                  SystemColors.WindowFrame, BORDER_SIZE, ButtonBorderStyle.Inset);
        }

        public ManagedScreen Screen { get; }

        public override ContextMenuStrip ContextMenuStrip
        {
            get => base.ContextMenuStrip;
            set
            {
                pbPreview.ContextMenuStrip = value;

                base.ContextMenuStrip = value;
            }
        }
    }
}

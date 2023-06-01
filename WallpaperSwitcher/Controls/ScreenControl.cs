using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using WallpaperSwitcher.Utils;

namespace WallpaperSwitcher
{
    public partial class ScreenControl : UserControl
    {
        public bool ShowWallpaperPreviews { get; set; } = true;

        public ScreenControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        public ScreenControl(ManagedScreen screen) : this()
        {
            Screen = screen;

            lblId.Parent = pbPreview;
            lblId.Text = screen.Id.ToString();

            var toolTipBuilder = new StringBuilder();

            screen.LoadSettings();

            toolTipBuilder.AppendLine($"Model: {screen.Screen.DeviceFriendlyName()}");
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

        /// <summary>
        /// Gets or sets whether the wallpaper preview will be lazily scaled to fit the preview box.
        /// </summary>
        public bool UseLazyScaling
        {
            get => pbPreview.SizeMode != PictureBoxSizeMode.Normal;
            set => pbPreview.SizeMode = value ? PictureBoxSizeMode.StretchImage : PictureBoxSizeMode.Normal;
        }

        public void RefreshPreview()
        {
            if (ShowWallpaperPreviews)
                pbPreview.Image = DrawScreenPreview();
            else
                pbPreview.Image = null;
        }

        public string GetWallpaperPath()
        {
            try
            {
                var wallpaper = (IDesktopWallpaper)new DesktopWallpaperClass();
                var monitorId = wallpaper.GetMonitorDevicePathAt((uint)Screen.Id - 1);
                return wallpaper.GetWallpaper(monitorId);
            }

            catch (COMException ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        private Image DrawScreenPreview()
        {
            var wallpaperPath = GetWallpaperPath();

            if (wallpaperPath == null)
                return null;

            using (var wImg = Image.FromFile(wallpaperPath))
            {
                var resized = wImg.GetThumbnailImage(pbPreview.Width, pbPreview.Height, null, IntPtr.Zero);
                return resized;
            }
        }

        private void pbPreview_MouseLeave(object sender, EventArgs e)
        {
            lblId.Visible = false;

            DrawBorder(Color.Gray);
        }

        private void pbPreview_MouseEnter(object sender, EventArgs e)
        {
            lblId.Visible = true;

            DrawBorder(Color.LightBlue);
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

        private void DrawBorder(Color color)
        {
            const int BORDER_SIZE = 4;

            using (var g = pbPreview.CreateGraphics())
            {
                ControlPaint.DrawBorder(g, pbPreview.ClientRectangle,
                                      color, BORDER_SIZE, ButtonBorderStyle.Solid,
                                      color, BORDER_SIZE, ButtonBorderStyle.Solid,
                                      color, BORDER_SIZE, ButtonBorderStyle.Solid,
                                      color, BORDER_SIZE, ButtonBorderStyle.Solid);
            }
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

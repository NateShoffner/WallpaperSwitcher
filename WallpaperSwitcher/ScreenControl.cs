using System.Drawing.Drawing2D;
using System.Text;

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

            pbPreview.Image = DrawScreenPreview(screen.Id);
            lblInfo.Text = screen.Screen.DeviceName;

            var sb = new StringBuilder();
            sb.AppendLine("Device Name: " + screen.ScreenSettings.dmDeviceName);
            sb.AppendLine($"Refresh Rate: {screen.ScreenSettings.dmDisplayFrequency}hz");
            sb.Append($"Resolution: {screen.Screen.Bounds.Width}x{screen.Screen.Bounds.Height}");

            if (screen.ScreenSettings.dmDisplayOrientation != ScreenOrientation.Angle0)
            {
                switch (screen.ScreenSettings.dmDisplayOrientation)
                {
                    case ScreenOrientation.Angle90:
                        sb.Append(" (Portrait)");
                        break;
                    case ScreenOrientation.Angle180:
                        sb.Append(" (Upside Down)");
                        break;
                    case ScreenOrientation.Angle270:
                        sb.Append(" (Portrait Upside Down)");
                        break;
                }
            }

            toolTip1.SetToolTip(pbPreview, sb.ToString());
        }

        private Bitmap DrawScreenPreview(int id)
        {
            var icon = Properties.Resources.monitor;
            var bitmap = new Bitmap(icon.Width, icon.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                // monitor icon
                var rect = new Rectangle(30, 29, 466, 307);
                graphics.DrawImage(icon, 0, 0, icon.Width, icon.Height);

                // live view of wallpaper
                var wallpaper = (IDesktopWallpaper)new DesktopWallpaperClass();
                var monitorId = wallpaper.GetMonitorDevicePathAt((uint)id - 1);
                var wallpaperRect = wallpaper.GetMonitorRECT(monitorId);
                var wallpaperPath = wallpaper.GetWallpaper(monitorId);

                using (var wImg = Image.FromFile(wallpaperPath))
                {
                    var resized = (Image)new Bitmap(wImg, new Size(rect.Width, rect.Height));
                    graphics.DrawImage(resized, rect.X, rect.Y);
                }

                // monitor ID
                const int fontSize = 64;



                /*

                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                using (GraphicsPath gp = new GraphicsPath())
                {
                    using (Pen outline = new Pen(Brushes.White, 25) { LineJoin = LineJoin.Round })
                    {
                        using (StringFormat sf = new StringFormat()
                        {
                            LineAlignment = StringAlignment.Near,
                            Alignment = StringAlignment.Center
                        })
                        {
                            using (Brush foreBrush = new SolidBrush(Color.Black))
                            {
                                gp.AddString(id.ToString(), Font.FontFamily, (int)FontStyle.Bold, graphics.DpiY * fontSize / 72, rect, sf);
                                graphics.SmoothingMode = SmoothingMode.HighQuality;
                                graphics.DrawPath(outline, gp);
                                graphics.FillPath(foreBrush, gp);
                            }
                        }
                    }
                } */
            }

            return bitmap;
        }

        private void pbPreview_MouseHover(object sender, EventArgs e)
        {

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

using System.Drawing.Drawing2D;
using System.Text;
using WallpaperSwitcher.Utils;

namespace WallpaperSwitcher
{
    public partial class ScreenControl : UserControl
    {
        private static Rectangle monitorPreviewRect = new Rectangle(30, 29, 466, 307);

        public ScreenControl()
        {
            InitializeComponent();
        }

        public ScreenControl(ManagedScreen screen) : this()
        {
            Screen = screen;

            lblId.Parent = pbPreview;
            lblId.Text = screen.Id.ToString();
            pbPreview.Image = DrawScreenPreview();

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

        private Bitmap DrawScreenPreview()
        {
            var icon = Properties.Resources.monitor;
            var bitmap = new Bitmap(icon.Width, icon.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                // monitor icon
                graphics.DrawImage(icon, 0, 0, icon.Width, icon.Height);

                // live view of wallpaper
                var wallpaper = (IDesktopWallpaper)new DesktopWallpaperClass();
                var monitorId = wallpaper.GetMonitorDevicePathAt((uint)Screen.Id - 1);
                var wallpaperRect = wallpaper.GetMonitorRECT(monitorId);
                var wallpaperPath = wallpaper.GetWallpaper(monitorId);

                using (var wImg = Image.FromFile(wallpaperPath))
                {
                    var resized = (Image)new Bitmap(wImg, new Size(monitorPreviewRect.Width, monitorPreviewRect.Height));
                    graphics.DrawImage(resized, monitorPreviewRect.X, monitorPreviewRect.Y);
                }

                // monitor ID
                /*
                const int FontSize = 64;
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
                                gp.AddString(Screen.Id.ToString(), Font.FontFamily, (int)FontStyle.Bold, graphics.DpiY * FontSize / 72, rect, sf);
                                graphics.SmoothingMode = SmoothingMode.HighQuality;
                                graphics.DrawPath(outline, gp);
                                graphics.FillPath(foreBrush, gp);
                            }
                        }
                    }
                }*/
            }

            return bitmap;
        }

        private void pbPreview_MouseHover(object sender, EventArgs e)
        {

        }

        private void pbPreview_MouseLeave(object sender, EventArgs e)
        {
            lblId.Visible = false;
        }

        private void pbPreview_MouseEnter(object sender, EventArgs e)
        {
            lblId.Visible = true;
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
                }   
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

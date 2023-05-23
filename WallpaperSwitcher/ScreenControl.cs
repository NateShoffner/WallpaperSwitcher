using System.Text;

namespace WallpaperSwitcher
{
    public partial class ScreenControl : UserControl
    {
        public ScreenControl()
        {
            InitializeComponent();
        }

        public ScreenControl(ManagedScreen screen, string screenName) : this()
        {
            Screen = screen;

            pictureBox1.Image = DrawIcon(screen.Id);
            lblInfo.Text = screen.Screen.DeviceName;

            var sb = new StringBuilder();
            sb.AppendLine("Device Name: " + screen.ScreenSettings.dmDeviceName);
            sb.AppendLine($"Refresh Rate: {screen.ScreenSettings.dmDisplayFrequency}hz");
            sb.Append($"Resolution: {screen.Screen.Bounds.Width}x{screen.Screen.Bounds.Height}");
            // if the screen is rotated, add that to the label
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

            toolTip1.SetToolTip(pictureBox1, sb.ToString());
        }

        private Bitmap DrawIcon(int id)
        {
            var icon = Properties.Resources.monitor;
            var bitmap = new Bitmap(icon.Width, icon.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                var rect = new Rectangle(30, 29, 466, 307);

                graphics.DrawImage(icon, 0, 0, icon.Width, icon.Height);
                StringFormat format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center,

                };

                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                graphics.DrawString(id.ToString(), new Font("Segoe UI", 64, FontStyle.Bold), Brushes.Black, rect, format);
            }

            return bitmap;

        }

        public ManagedScreen Screen { get; }
    }
}

using System.Collections.ObjectModel;
using System.Diagnostics;
using WallpaperSwitcher.Utils;

namespace WallpaperSwitcher.Controls
{
    public partial class ScreenLayoutPanel : UserControl
    {
        public bool ShowScreenNumbers { get; set; } = true;

        public bool ShowScreenModels { get; set; } = true;

        public bool ShowWallpaperPreviews { get; set; } = true;

        private List<ManagedScreen> managedScreens = new List<ManagedScreen>();

        private List<ScreenControl> screenControls = new List<ScreenControl>();

        public delegate void ScreenEventHandler(ManagedScreen screen);

        public event ScreenEventHandler ScreenIdentifyClick;

        public ReadOnlyCollection<ManagedScreen> ManagedScreens => managedScreens.AsReadOnly();

        public ScreenLayoutPanel()
        {
            InitializeComponent();
        }

        public void ClearScreens()
        {
            managedScreens.Clear();
            panel1.Controls.Clear();
            screenControls.Clear();
        }

        public void AddScreen(ManagedScreen screen)
        {
            var control = CreateScreenControl(screen);
            control.Margin = new Padding(5);
            screenControls.Add(control);
            managedScreens.Add(screen);
            panel1.Controls.Add(control);
        }

        public void AddScreens(ManagedScreen[] screens)
        {
            foreach (var screen in screens)
            {
                AddScreen(screen);
            }
        }

        public void DrawScreens()
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

                if (ShowWallpaperPreviews)
                    control.RefreshPreview();

                panel1.Controls.Add(control);
            }
        }

        private ScreenControl CreateScreenControl(ManagedScreen screen)
        {
            ScreenControl screenControl = new ScreenControl(screen);
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            var identifyMenuItem = new ToolStripMenuItem() { Text = "Identify" };
            identifyMenuItem.Click += (s, e) =>
            {
                if (ScreenIdentifyClick != null)
                    ScreenIdentifyClick(screen);
            };
            contextMenu.Items.Add(identifyMenuItem);

            var locateMenuItem = new ToolStripMenuItem() { Text = "Open in Explorer..." };
            locateMenuItem.Click += (s, e) => Process.Start("explorer.exe", $"/select, \"{screenControl.GetWallpaperPath()}\"");
            contextMenu.Items.Add(locateMenuItem);

            var positionMenuItem = new ToolStripMenuItem() { Text = "Position..." };

            foreach (var position in Enum.GetValues(typeof(DesktopWallpaperPosition)))
            {
                var positionItem = new ToolStripMenuItem() { Text = position.ToString() };
                var wallpaper = (IDesktopWallpaper)new DesktopWallpaperClass();

                var currentPosition = wallpaper.GetPosition();
                if (currentPosition == (DesktopWallpaperPosition)position)
                    positionItem.Checked = true;

                positionItem.Click += (s, e) =>
                {
                    wallpaper.SetPosition((DesktopWallpaperPosition)position);

                };
                positionMenuItem.DropDownItems.Add(positionItem);

            }

            contextMenu.Items.Add(positionMenuItem);
            screenControl.ContextMenuStrip = contextMenu;
            return screenControl;
        }
    }
}

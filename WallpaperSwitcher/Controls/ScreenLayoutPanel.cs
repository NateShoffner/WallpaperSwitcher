using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
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

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

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

        public void DrawScreens(bool skipPreview = false)
        {
            SuspendDrawing(this);

            double PreviewScale = 1f;

            // build the virtual screen

            var rectangle = managedScreens.Aggregate(new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue), (current, screen) 
                => Rectangle.Union(current, screen.Screen.Bounds));

            var virtualScreen = rectangle;

            double workingAreaHeight = (float)panel1.Height / (float)virtualScreen.Height;
            double workingAreaWidth = (float)panel1.Width / (float)virtualScreen.Width;

            double scaling = Math.Min(workingAreaHeight, workingAreaWidth) * PreviewScale;

            int relativeX = (int)(((double)panel1.Width - (double)(float)virtualScreen.Width * scaling) / 2.0);
            int relativeY = (int)(((double)panel1.Height - (double)(float)virtualScreen.Height * scaling) / 2.0);

            for (int i = 0; i < managedScreens.Count(); i++)
            {
                ManagedScreen? screen = managedScreens[i];

                int x = (int)((double)(screen.Screen.Bounds.Location.X + Math.Abs(virtualScreen.X)) * scaling) + relativeX;
                int y = (int)((double)(screen.Screen.Bounds.Location.Y + Math.Abs(virtualScreen.Y)) * scaling) + relativeY;
                int width = (int)((double)screen.Screen.Bounds.Width * scaling);
                int height = (int)((double)screen.Screen.Bounds.Height * scaling);

                var control = screenControls[i];

                Debug.WriteLine($"Screen {i} - X: {x}, Y: {y}, Width: {width}, Height: {height}");

                control.SetBounds(x, y, width, height);

                if (!skipPreview)
                    control.RefreshPreview();

                panel1.Controls.Add(control);
            }

            ResumeDrawing(this);
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

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }

        private void ScreenLayoutPanel_Load(object sender, EventArgs e)
        {
            // hook into the parent form's resize events so we can use them within our control
            if (!this.DesignMode)
            {
                var parent = Parent;

                while (!(parent is Form))
                    parent = parent.Parent;

                var form = parent as Form;

                if (form == null)
                    return;

                form.Resize += Parent_Resize;
                form.ResizeBegin += Parent_ResizeBegin;
                form.ResizeEnd += Parent_ResizeEnd;
            }
        }

        private void Parent_Resize(object? sender, EventArgs e)
        {
            DrawScreens(true);
        }

        private void Parent_ResizeBegin(object? sender, EventArgs e)
        {
            this.IsResizing = true;
            Debug.WriteLine("Resize started, enabling lazy scaling");

            foreach (var screenControl in screenControls)
            {
                screenControl.UseLazyScaling = true;
            }
        }

        private void Parent_ResizeEnd(object? sender, EventArgs e)
        {
            this.IsResizing = false;
            Debug.WriteLine("Resize ended, disabling lazy scaling");
            foreach (var screenControl in screenControls)
            {

                screenControl.UseLazyScaling = false;
            }

            DrawScreens();
        }

        public bool IsResizing { get; set; } = false;
    }
}

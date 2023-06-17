
using FontAwesome.Sharp;
using MaterialSkin;
using MaterialSkin.Controls;
using Shell32;
using System.Diagnostics;

namespace WallpaperSwitcher
{
    public partial class MainForm : MaterialForm
    {
        private FormWindowState _previousWindowState;

        public MainForm()
        {
            InitializeComponent();

            _previousWindowState = WindowState;

            // use tab header as key since index doesn't work for some reason, might be unique to the material drawer implementation?
            drawerImageList.Images.Add(tabPage1.Text, IconChar.Display.ToBitmap(Color.White));
            drawerImageList.Images.Add(tabPage2.Text, IconChar.Gear.ToBitmap(Color.White));
            drawerImageList.Images.Add(tabPage3.Text, IconChar.Info.ToBitmap(Color.White));

            foreach (TabPage tabPage in materialTabControl1.TabPages)
            {
                tabPage.ImageKey = tabPage.Text;
            }

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Red200, Primary.Purple100, Primary.Teal100, Accent.Blue200, TextShade.BLACK);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            screenLayoutPanel1.ScreenIdentifyClick += ShowIdentification;

            LoadScreens();
        }
        private void LoadScreens(object sender = null, EventArgs e = null)
        {
            var screens = Screen.AllScreens;

            screenLayoutPanel1.ClearScreens();

            for (uint i = 0; i < screens.Length; i++)
            {
                var userFriendlyId = i + 1;
                ManagedScreen screen = new ManagedScreen(screens[i], userFriendlyId);
                screenLayoutPanel1.AddScreen(screen);
            }

            screenLayoutPanel1.DrawScreens();
        }
        private void IdentifyScreens(object sender, EventArgs e)
        {
            foreach (var screen in screenLayoutPanel1.ManagedScreens)
            {
                ShowIdentification(screen);
            }
        }
        private void ShowIdentification(ManagedScreen screen)
        {
            IdentityForm identityForm = new IdentityForm(screen, 2000);
            identityForm.Show();
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //TODO maybe handle this in ScreenLayoutPanel

            if (WindowState != _previousWindowState)
                screenLayoutPanel1.DrawScreens();

            _previousWindowState = WindowState;
        }

        private void OpenDisplaySettings(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "ms-settings:display",
                UseShellExecute = true
            };

            Process.Start(psi);
        }

        private void ShowDesktop(object sender, EventArgs e)
        {
            ShellClass shell = new ShellClass();
            shell.MinimizeAll();
        }
    }
}
using System.Diagnostics;
using System.Management;
using WallpaperSwitcher.Forms;
using static WallpaperSwitcher.ManagedScreen;

namespace WallpaperSwitcher
{
    public partial class MainForm : Form
    {
        private List<ManagedScreen> managedScreens = new List<ManagedScreen>();

        public MainForm()
        {
            InitializeComponent();

            LoadScreens();
        }

        private DEVMODE GetScreenSettings(Screen screen)
        {
            DEVMODE vDevMode = new DEVMODE();
            EnumDisplaySettings(screen.DeviceName, -1, ref vDevMode);
            return vDevMode;
        }

        private void LoadScreens()
        {
            managedScreens.Clear();
            flowLayoutPanel1.Controls.Clear();

            Screen[] screens = Screen.AllScreens;

            for (int i = 0; i < screens.Length; i++)
            {
                var id = i + 1;

                ManagedScreen managedScreen = new ManagedScreen(screens[i], id);
                managedScreen.LoadSettings();
                managedScreens.Add(managedScreen);

                var control = CreateScreenControl(managedScreen);
                flowLayoutPanel1.Controls.Add(control);
            }

            lblScreens.Text = $"Screens: {screens.Length}";
        }

        private void reloadScreensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadScreens();
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
            contextMenu.Items.Add(new ToolStripMenuItem() { Text = "Identify" });
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
    }
}
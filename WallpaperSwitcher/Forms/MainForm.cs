using System.Diagnostics;
using WallpaperSwitcher.Forms;

namespace WallpaperSwitcher
{
    public partial class MainForm : Form
    {
        private FormWindowState _previousWindowState;

        public MainForm()
        {
            InitializeComponent();

            _previousWindowState = WindowState;

            screenLayoutPanel1.ScreenIdentifyClick += ShowIdentification;

            LoadScreens(this, EventArgs.Empty);
        }

        private void LoadScreens(object sender, EventArgs e)
        {
            var screens = Screen.AllScreens;

            screenLayoutPanel1.ClearScreens();

            for (uint i = 0; i < screens.Length; i++)
            {
                var userFriendlyId = i + 1;
                ManagedScreen screen = new ManagedScreen(screens[i], userFriendlyId);
                screenLayoutPanel1.AddScreen(screen);
            }

            lblScreens.Text = $"Screens: {screens.Length}";
            screenLayoutPanel1.DrawScreens();
        }

        private void IdentifyScreens(object sender, EventArgs e)
        {
            foreach (var screen in screenLayoutPanel1.ManagedScreens)
            {
                ShowIdentification(screen);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            if (WindowState != _previousWindowState)
                screenLayoutPanel1.DrawScreens();

            _previousWindowState = WindowState;
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            screenLayoutPanel1.DrawScreens();
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
    }
}
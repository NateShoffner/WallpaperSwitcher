using System.Diagnostics;
using System.Management;
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

            // loop through all the screens with a starting index of 1

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DesktopMonitor");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                Debug.WriteLine("-----------------------------------");
                Debug.WriteLine("Win32_DesktopMonitor instance");
                Debug.WriteLine("-----------------------------------");
                Debug.WriteLine("Description: {0}", queryObj["Description"]);
                Debug.WriteLine("DeviceID: {0}", queryObj["DeviceID"]);
                Debug.WriteLine("MonitorManufacturer: {0}", queryObj["MonitorManufacturer"]);
                Debug.WriteLine("MonitorType: {0}", queryObj["MonitorType"]);
                Debug.WriteLine("Name: {0}", queryObj["Name"]);
                Debug.WriteLine("PixelsPerXLogicalInch: {0}", queryObj["PixelsPerXLogicalInch"]);
                Debug.WriteLine("PixelsPerYLogicalInch: {0}", queryObj["PixelsPerYLogicalInch"]);   
                Debug.WriteLine("ScreenHeight: {0}", queryObj["ScreenHeight"]);

            }

            for (int i = 0; i < screens.Length; i++)
            {
                var id = i + 1;
                Screen screen = screens[i];
                string deviceName = screen.DeviceName;

                ManagedScreen managedScreen = new ManagedScreen(screen, id);
                managedScreen.LoadSettings();
                managedScreens.Add(managedScreen);
            

            ScreenControl screenControl = new ScreenControl(managedScreen, deviceName);

                flowLayoutPanel1.Controls.Add(screenControl);
            }

            lblScreens.Text = $"Screens: {screens.Length}";
        }

        private void reloadScreensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadScreens();
        }

        private async void identifyScreensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var forms = new List<IdentityForm>();

            foreach (ManagedScreen screen in managedScreens)
            {
                IdentityForm identityForm = new IdentityForm(screen.Screen, screen.Id.ToString());
                forms.Add(identityForm);
                identityForm.Show();
            }

            await Task.Delay(2000);

            foreach (IdentityForm form in forms)
            {
                form.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
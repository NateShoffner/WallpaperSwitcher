namespace WallpaperSwitcher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Version win8version = new Version(6, 2, 9200, 0);

            if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version < win8version)
            {
                MessageBox.Show("This application requires Windows 8 or newer.");
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
using Timer = System.Windows.Forms.Timer;

namespace WallpaperSwitcher
{
    public partial class IdentityForm : Form
    {
        public IdentityForm()
        {
            InitializeComponent();
        }

        public IdentityForm(ManagedScreen managedScreen, int timeout) : this()
        {
            Timeout = timeout;
            label1.Text = managedScreen.Id.ToString();

            const int margin = 20;
            Location = new Point(managedScreen.Screen.WorkingArea.Width - Width - margin, managedScreen.Screen.WorkingArea.Height - Height - margin);
        }

        public int Timeout { get; }

        private void IdentityForm_Load(object sender, EventArgs e)
        {
            Timer t = new Timer
            {
                Interval = Timeout
            };

            t.Tick += (o, e) => {

                t.Stop();
                Close();
            };


            t.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallpaperSwitcher
{
    public partial class IdentityForm : Form
    {
        public IdentityForm()
        {
            InitializeComponent();
        }

        public IdentityForm(Screen screen, string indicator) : this()
        {
            label1.OutlineForeColor = Color.Black;
            label1.ForeColor = Color.White;
            label1.Text = indicator;

            // make the form transparent
            BackColor = Color.Red;
            TransparencyKey = Color.Red;

            // full screen
            StartPosition = FormStartPosition.Manual;
            Location = screen.WorkingArea.Location;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }
    }
}

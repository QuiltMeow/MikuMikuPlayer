using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            UIHandler.registerHoverEvent(pbExit);
        }

        private void smallru8_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/smallru8");
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void AboutForm_MouseDown(object sender, MouseEventArgs e)
        {
            locationMouseDownHandler(e);
        }

        private void locationMouseDownHandler(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UIHandler.ReleaseCapture();
                UIHandler.SendMessage(Handle, UIHandler.WM_NCLBUTTONDOWN, UIHandler.HT_CAPTION, 0);
            }
        }

        private void pbBackground_MouseDown(object sender, MouseEventArgs e)
        {
            locationMouseDownHandler(e);
        }
    }
}
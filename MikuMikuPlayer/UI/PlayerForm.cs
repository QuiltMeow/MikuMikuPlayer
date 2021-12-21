using System;
using System.Drawing;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();
            windowControl = new Control[] { pbClose, pbMax, pbMin };

            registerMouseHoverEvent();
        }

        private void pbMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pbMax_Click(object sender, EventArgs e)
        {
            Program.uiHandler.player.toggleFullScreen();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void formLocationMouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UIHandler.ReleaseCapture();
                UIHandler.SendMessage(Handle, UIHandler.WM_NCLBUTTONDOWN, UIHandler.HT_CAPTION, 0);
            }
        }

        private readonly Control[] windowControl;

        protected void PlayerForm_Resize(object sender, EventArgs e)
        {
            if (windowControl != null)
            {
                int width = Size.Width;
                for (int i = 0; i < windowControl.Length; ++i)
                {
                    windowControl[i].Location = new Point(width - 50 - i * 40, 0);
                }
            }
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
        }
    }
}
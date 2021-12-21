using System;
using System.Drawing;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public partial class DSPlayerForm : PlayerForm
    {
        public bool barVisible
        {
            get;
            set;
        }

        public DSPlayerForm()
        {
            InitializeComponent();

            barVisible = true;
            registerStatusToggle();
        }

        private void registerStatusToggle()
        {
            Control[] toggleUIControl = new Control[] { this, panelPlayer, tbDuration, sbStatus };
            foreach (Control control in toggleUIControl)
            {
                control.MouseClick += new MouseEventHandler(toggleUIMouseClickEvent);
            }

            Control[] toggleFullScreenControl = new Control[] { this, panelPlayer, sbStatus };
            foreach (Control control in toggleFullScreenControl)
            {
                control.MouseDoubleClick += new MouseEventHandler(toggleFullScreenMouseDoubleClickEvent);
            }
        }

        private void toggleUIMouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                IPlayer player = Program.uiHandler.player;
                player.toggleUI();
            }
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == DSPlayer.WM_GRAPHNOTIFY)
            {
                DSPlayer player = Program.uiHandler.player as DSPlayer;
                int eventCode;
                int leftParameter, rightParameter;

                while (true)
                {
                    try
                    {
                        player.mediaEventEx.GetEvent(out eventCode, out leftParameter, out rightParameter, 0);
                        player.mediaEventEx.FreeEventParams(eventCode, leftParameter, rightParameter);
                        if (eventCode == DSPlayer.EC_COMPLETE)
                        {
                            if (player.isRandom())
                            {
                                player.addRandomPlayHistory();
                            }
                            player.playCompleteNext();
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            base.WndProc(ref message);
        }

        private void DSPlayerForm_SizeChanged(object sender, EventArgs e)
        {
            panelPlayer.Size = new Size(Size.Width - 24, Size.Height - 24);
            DSPlayer player = Program.uiHandler.player as DSPlayer;
            player.updateVideoPosition();
        }

        private void DSPlayerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && WindowState == FormWindowState.Maximized)
            {
                IPlayer player = Program.uiHandler.player;
                player.toggleFullScreen();
            }
        }

        private void toggleFullScreenMouseDoubleClickEvent(object sender, MouseEventArgs e)
        {
            IPlayer player = Program.uiHandler.player;
            player.toggleFullScreen();
        }
    }
}
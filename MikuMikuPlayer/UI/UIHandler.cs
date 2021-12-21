using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    partial class MainForm
    {
        private readonly EditHandler editHandler;
        private readonly TransperentHandler transperentHandler;

        private void registerMouseHoverEvent()
        {
            PictureBox[] nonToggle = new PictureBox[] { pbSetting, pbHelp, pbExit, pbPlayList, pbStop, pbPrev, pbNext, pbPlayer };
            foreach (PictureBox target in nonToggle)
            {
                UIHandler.registerHoverEvent(target);
            }
        }

        private void registerEditEvent()
        {
            Control[] register = new Control[] { pbSetting, pbHelp, pbExit, pbPlayList, pbPlay, pbStop, pbPrev, pbNext, pbVolume, pbReplay, pbRandom, pbPlayer, labelCurrentPlay };
            foreach (Control target in register)
            {
                target.MouseDown += new MouseEventHandler(editHandler.mouseDownEvent);
                target.MouseMove += new MouseEventHandler(editHandler.mouseMoveEditEvent);
            }
        }
    }

    partial class PlayerForm
    {
        #region 播放器大小調整

        private const int HTLEFT = 10, HTRIGHT = 11, HTTOP = 12, HTTOPLEFT = 13, HTTOPRIGHT = 14, HTBOTTOM = 15, HTBOTTOMLEFT = 16, HTBOTTOMRIGHT = 17,
            WM_NCHITTEST = 0x84, RESIZE_BORDER = 8;

        private Rectangle borderTop
        {
            get
            {
                return new Rectangle(0, 0, ClientSize.Width, RESIZE_BORDER);
            }
        }

        private Rectangle borderLeft
        {
            get
            {
                return new Rectangle(0, 0, RESIZE_BORDER, ClientSize.Height);
            }
        }

        private Rectangle borderBottom
        {
            get
            {
                return new Rectangle(0, ClientSize.Height - RESIZE_BORDER, ClientSize.Width, RESIZE_BORDER);
            }
        }

        private Rectangle borderRight
        {
            get
            {
                return new Rectangle(ClientSize.Width - RESIZE_BORDER, 0, RESIZE_BORDER, ClientSize.Height);
            }
        }

        private Rectangle borderTopLeft
        {
            get
            {
                return new Rectangle(0, 0, RESIZE_BORDER, RESIZE_BORDER);
            }
        }

        private Rectangle borderTopRight
        {
            get
            {
                return new Rectangle(ClientSize.Width - RESIZE_BORDER, 0, RESIZE_BORDER, RESIZE_BORDER);
            }
        }

        private Rectangle borderBottomLeft
        {
            get
            {
                return new Rectangle(0, ClientSize.Height - RESIZE_BORDER, RESIZE_BORDER, RESIZE_BORDER);
            }
        }

        private Rectangle borderBottomRight
        {
            get
            {
                return new Rectangle(ClientSize.Width - RESIZE_BORDER, ClientSize.Height - RESIZE_BORDER, RESIZE_BORDER, RESIZE_BORDER);
            }
        }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST)
            {
                Point cursor = PointToClient(Cursor.Position);
                if (borderTopLeft.Contains(cursor))
                {
                    message.Result = (IntPtr)HTTOPLEFT;
                }
                else if (borderTopRight.Contains(cursor))
                {
                    message.Result = (IntPtr)HTTOPRIGHT;
                }
                else if (borderBottomLeft.Contains(cursor))
                {
                    message.Result = (IntPtr)HTBOTTOMLEFT;
                }
                else if (borderBottomRight.Contains(cursor))
                {
                    message.Result = (IntPtr)HTBOTTOMRIGHT;
                }
                else if (borderTop.Contains(cursor))
                {
                    message.Result = (IntPtr)HTTOP;
                }
                else if (borderLeft.Contains(cursor))
                {
                    message.Result = (IntPtr)HTLEFT;
                }
                else if (borderRight.Contains(cursor))
                {
                    message.Result = (IntPtr)HTRIGHT;
                }
                else if (borderBottom.Contains(cursor))
                {
                    message.Result = (IntPtr)HTBOTTOM;
                }
            }
        }

        #endregion 播放器大小調整

        private void registerMouseHoverEvent()
        {
            PictureBox[] control = new PictureBox[] { pbMin, pbMax, pbClose };
            foreach (PictureBox target in control)
            {
                UIHandler.registerHoverEvent(target);
            }
        }
    }

    partial class PlayListForm
    {
        private void registerMouseHoverEvent()
        {
            PictureBox[] control = new PictureBox[] { pbHelp, pbExit, pbLoadList, pbSaveList };
            foreach (PictureBox target in control)
            {
                UIHandler.registerHoverEvent(target);
            }
        }
    }

    public class UIHandler
    {
        public readonly IPlayer player;
        public readonly SettingForm settingForm;
        public readonly PlayerForm playerForm;
        public readonly HelpForm helpForm;
        public readonly PlayListForm playListForm;
        public readonly AboutForm aboutForm;
        public readonly SpectrumForm spectrumForm;

        public UIHandler()
        {
            settingForm = new SettingForm();

            // 播放器視窗
            if (Program.settingManager.playerType == PlayerType.WINDOWS_MEDIA_PLAYER)
            {
                playerForm = new WMPlayerForm();
                player = new WMPlayer();
            }
            else
            {
                playerForm = new DSPlayerForm();
                player = new DSPlayer();
            }

            helpForm = new HelpForm();
            playListForm = new PlayListForm();
            aboutForm = new AboutForm();
            spectrumForm = new SpectrumForm();
        }

        public static void mouseHoverEvent(object sender, EventArgs e)
        {
            PictureBox target = sender as PictureBox;
            target.BackgroundImage = Program.skinManager.getImage(target.Name.Substring(2) + "Hover");
        }

        public static void mouseLeaveEvent(object sender, EventArgs e)
        {
            PictureBox target = sender as PictureBox;
            target.BackgroundImage = Program.skinManager.getImage(target.Name.Substring(2));
        }

        public static void loadPlayList(string file)
        {
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        while (fs.Position != fs.Length)
                        {
                            Program.uiHandler.player.appendMedia(br.ReadString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("播放清單開啟失敗 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void fileDragDropEvent(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (file.Length == 1 && file[0].EndsWith(".mikupl"))
            {
                Program.uiHandler.player.clearPlayList();
                loadPlayList(file[0]);
            }
            else
            {
                for (int i = 0; i < file.Length; ++i)
                {
                    Program.uiHandler.player.appendMedia(file[i]);
                }
            }
        }

        public static void fileDragEnterEvent(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public static void registerHoverEvent(Control target)
        {
            target.MouseEnter += new EventHandler(mouseHoverEvent);
            target.MouseLeave += new EventHandler(mouseLeaveEvent);
        }

        public void applyUI(bool init = false)
        {
            Program.settingManager.applyFont();
            Program.skinManager.applySkin(init);
        }

        public void reloadSettingList()
        {
            Program.skinManager.loadSkinList();
            settingForm.loadSetting();
        }

        public static void toggleVisible(Control control)
        {
            bool visible = control.Visible;
            control.Visible = !visible;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}
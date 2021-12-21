using System;
using System.Drawing;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public partial class MainForm : Form
    {
        private bool marqueeEnable, lockLocation;

        private Graphics graphicProgress;

        public MainForm()
        {
            InitializeComponent();

            editHandler = new EditHandler();
            transperentHandler = new TransperentHandler(this);

            registerMouseHoverEvent();
            registerEditEvent();

            MouseWheel += new MouseEventHandler(MainForm_MouseWheel);
            DragDrop += new DragEventHandler(UIHandler.fileDragDropEvent);
            DragEnter += new DragEventHandler(UIHandler.fileDragEnterEvent);

            transperentHandler.registerControlMouseEnterEvent(cmsRightMenu);
        }

        private void pbSetting_Click(object sender, EventArgs e)
        {
            if (!Program.settingManager.editable)
            {
                bool visible = !Program.uiHandler.settingForm.Visible;
                Program.uiHandler.settingForm.Visible = visible;

                if (visible)
                {
                    Program.uiHandler.reloadSettingList();
                }
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            if (!Program.settingManager.editable)
            {
                Close();
            }
        }

        private void pbPlayList_Click(object sender, EventArgs e)
        {
            if (!Program.settingManager.editable)
            {
                UIHandler.toggleVisible(Program.uiHandler.playListForm);
            }
        }

        private void pbHelp_Click(object sender, EventArgs e)
        {
            if (!Program.settingManager.editable)
            {
                Program.uiHandler.helpForm.applyMainHelp();
                Program.uiHandler.helpForm.Visible = true;
            }
        }

        private void pbPlay_Click(object sender, EventArgs e)
        {
            if (Program.uiHandler.player.hasMedia() && !Program.settingManager.editable)
            {
                if (Program.uiHandler.player.getStatus() == PlayerStatus.PLAY)
                {
                    Program.uiHandler.player.pause();
                }
                else
                {
                    Program.uiHandler.player.play();
                }
                updatePlayStatus();
            }
        }

        public void updatePlayStatus()
        {
            pbPlay.BackgroundImage = Program.uiHandler.player.getStatus() == PlayerStatus.PLAY ? Program.skinManager.getImage("PauseHover") : Program.skinManager.getImage("PlayHover");
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            if (!Program.settingManager.editable)
            {
                Program.uiHandler.player.stop();
                pbPlay.BackgroundImage = Program.skinManager.getImage("Play");
            }
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (!Program.settingManager.editable)
            {
                Program.uiHandler.player.prev();
            }
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            if (!Program.settingManager.editable)
            {
                Program.uiHandler.player.next();
            }
        }

        private void pbReplay_Click(object sender, EventArgs e)
        {
            if (!Program.settingManager.editable)
            {
                Program.uiHandler.player.toggleReplay();
                pbReplay_MouseEnter(sender, e);
            }
        }

        private void pbRandom_Click(object sender, EventArgs e)
        {
            if (!Program.settingManager.editable)
            {
                Program.uiHandler.player.toggleRandom();
                pbRandom_MouseEnter(sender, e);
            }
        }

        private void pbPlayer_Click(object sender, EventArgs e)
        {
            if (!Program.settingManager.editable)
            {
                UIHandler.toggleVisible(Program.uiHandler.playerForm);
            }
        }

        private static readonly Pen PEN_CLEAR = new Pen(SystemColors.Control, 2);
        private static readonly Pen PEN_PROGRESS = new Pen(Color.FromArgb(240, 70, 70), 2);

        private void timerMarquee_Tick(object sender, EventArgs e)
        {
            if (marqueeEnable)
            {
                labelCurrentPlay.Left -= 3;
                if (labelCurrentPlay.Left + labelCurrentPlay.Width <= 0)
                {
                    labelCurrentPlay.Left = 215;
                }
            }

            bool media = Program.uiHandler.player.hasMedia();
            labelCurrentPlay.Visible = media;

            double angle = 0;
            if (media)
            {
                angle = Program.uiHandler.player.getAngle();
            }

            try
            {
                Pen draw = PEN_CLEAR;
                graphicProgress.DrawArc(draw, 0, 0, pbPlay.Size.Width, pbPlay.Size.Height, 0, 360);

                draw = PEN_PROGRESS;
                graphicProgress.DrawArc(draw, 0, 0, pbPlay.Size.Width, pbPlay.Size.Height, 0, (float)angle);
            }
            catch
            {
            }
        }

        private void labelCurrentPlay_MouseEnter(object sender, EventArgs e)
        {
            marqueeEnable = false;
        }

        private void labelCurrentPlay_MouseLeave(object sender, EventArgs e)
        {
            marqueeEnable = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Program.initFileList != null)
            {
                foreach (string media in Program.initFileList)
                {
                    Program.uiHandler.player.appendMedia(media);
                }
            }
            graphicProgress = pbPlay.CreateGraphics();
            marqueeEnable = true;

            if (Program.initLocation.HasValue)
            {
                Location = Program.initLocation.Value;
            }
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            int volume = Program.uiHandler.player.getVolume();
            if (e.Delta > 0)
            {
                volume += 5;
            }
            else if (e.Delta < 0)
            {
                volume -= 5;
            }

            if (volume > 100)
            {
                volume = 100;
            }
            else if (volume < 0)
            {
                volume = 0;
            }

            Program.uiHandler.player.setVolume(volume);
            updateVolume();
        }

        public void updateVolume()
        {
            int volume = Program.uiHandler.player.getVolume();
            bool mute = Program.uiHandler.player.isMute();
            if (mute)
            {
                pbVolume.Visible = false;
            }
            else
            {
                pbVolume.Visible = true;
                int volumeShow = volume / 10;
                if (volumeShow <= 0)
                {
                    volumeShow = 1;
                }
                pbVolume.BackgroundImage = Program.skinManager.getImage("Volume_" + volumeShow);
            }

            if (volume > 50 && !mute)
            {
                BackgroundImage = Program.skinManager.getImage("MainAni");
            }
            else
            {
                BackgroundImage = Program.skinManager.getImage("Main");
            }
        }

        private void pbReplay_MouseEnter(object sender, EventArgs e)
        {
            pbReplay.BackgroundImage = Program.skinManager.getImage("Replay" + (Program.uiHandler.player.isReplay() ? "Toggle" : "") + "Hover");
        }

        private void pbReplay_MouseLeave(object sender, EventArgs e)
        {
            pbReplay.BackgroundImage = Program.skinManager.getImage("Replay" + (Program.uiHandler.player.isReplay() ? "Toggle" : ""));
        }

        private void pbRandom_MouseEnter(object sender, EventArgs e)
        {
            pbRandom.BackgroundImage = Program.skinManager.getImage("Random" + (Program.uiHandler.player.isRandom() ? "Toggle" : "") + "Hover");
        }

        private void pbRandom_MouseLeave(object sender, EventArgs e)
        {
            pbRandom.BackgroundImage = Program.skinManager.getImage("Random" + (Program.uiHandler.player.isRandom() ? "Toggle" : ""));
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!lockLocation && e.Button == MouseButtons.Left)
            {
                UIHandler.ReleaseCapture();
                UIHandler.SendMessage(Handle, UIHandler.WM_NCLBUTTONDOWN, UIHandler.HT_CAPTION, 0);
            }
        }

        private void pbPlay_MouseEnter(object sender, EventArgs e)
        {
            pbPlay.BackgroundImage = Program.skinManager.getImage((Program.uiHandler.player.getStatus() == PlayerStatus.PLAY ? "Pause" : "Play") + "Hover");
        }

        private void pbPlay_MouseLeave(object sender, EventArgs e)
        {
            pbPlay.BackgroundImage = Program.skinManager.getImage(Program.uiHandler.player.getStatus() == PlayerStatus.PLAY ? "Pause" : "Play");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.settingManager.saveConfig(true);
        }

        private void tsmiTopMost_Click(object sender, EventArgs e)
        {
            bool topMostStatus = !tsmiTopMost.Checked;

            TopMost = topMostStatus;
            tsmiTopMost.Checked = topMostStatus;
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point position = MousePosition;
                cmsRightMenu.Show(position);
            }
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            UIHandler.toggleVisible(Program.uiHandler.aboutForm);
        }

        private void tsmiOpacity_Click(object sender, EventArgs e)
        {
            bool opacity = !transperentHandler.enable;

            transperentHandler.enable = opacity;
            tsmiOpacity.Checked = opacity;
        }

        private void tsmiSpectrum_Click(object sender, EventArgs e)
        {
            UIHandler.toggleVisible(Program.uiHandler.spectrumForm);
        }

        private void tsmiRestart_Click(object sender, EventArgs e)
        {
            Program.selfRestart();
        }

        private void tsmiLockLocation_Click(object sender, EventArgs e)
        {
            bool lockLocationStatus = !tsmiLockLocation.Checked;

            lockLocation = lockLocationStatus;
            tsmiLockLocation.Checked = lockLocationStatus;
        }
    }
}
using QuartzTypeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Winamp.Components;

namespace MikuMikuPlayer
{
    // Direct Show 播放器 完整實作
    // 4 K 測試 : 通過
    public class DSPlayer : IPlayer, IPlayerControl
    {
        private const int WM_APP = 0x8000;
        public const int WM_GRAPHNOTIFY = WM_APP + 1;
        public const int EC_COMPLETE = 0x01;

        private const int WS_CHILD = 0x40000000;
        private const int WS_CLIPCHILDREN = 0x2000000;

        private DSPlayerForm form;
        private Timer timerStatusUpdate;

        private FilgraphManager filterGraphManager;
        private IBasicAudio basicAudio;

        public IVideoWindow videoWindow
        {
            get;
            private set;
        }

        private IMediaEvent mediaEvent;

        public IMediaEventEx mediaEventEx
        {
            get;
            private set;
        }

        private IMediaPosition mediaPosition;
        private IMediaControl mediaControl;

        private PlayerStatus currentStatus;

        private bool replay, random, originBar;
        private int currentPlay, duration, volume;

        private ISet<string> hasPlayTurn;
        private Stack<string> randomPlayHistory;
        private IList<string> playList;

        public DSPlayer()
        {
            currentStatus = PlayerStatus.DEFAULT;
            hasPlayTurn = new HashSet<string>();
            randomPlayHistory = new Stack<string>();
            playList = new List<string>();

            timerStatusUpdate = new Timer()
            {
                Interval = 900
            };
            timerStatusUpdate.Tick += new EventHandler(timerStatusUpdateTick);
            currentPlay = -1;
            volume = 50;
        }

        public void addRandomPlayHistory()
        {
            if (currentStatus == PlayerStatus.DEFAULT)
            {
                return;
            }
            randomPlayHistory.Push(playList[currentPlay]);
        }

        private int getPrevHistoryMedia()
        {
            string media = null;
            while (!playList.Contains(media) && randomPlayHistory.Count > 0)
            {
                media = randomPlayHistory.Pop();
            }

            if (!playList.Contains(media))
            {
                if (random)
                {
                    return getNextRandom(false);
                }

                int ret = currentPlay - 1;
                if (ret < 0)
                {
                    ret = playList.Count - 1;
                }
                return ret;
            }
            return playList.IndexOf(media);
        }

        private int getNextRandom(bool addPlayTurn = true)
        {
            if (hasPlayTurn.Count >= playList.Count)
            {
                hasPlayTurn.Clear();
            }

            int ret;
            string media;
            do
            {
                ret = Program.random.Next(playList.Count);
                media = playList[ret];
            } while (hasPlayTurn.Contains(media) || (playList.Count >= 2 && ret == currentPlay));

            if (addPlayTurn)
            {
                hasPlayTurn.Add(media);
            }
            return ret;
        }

        private void timerStatusUpdateTick(object sender, EventArgs e)
        {
            if (currentStatus == PlayerStatus.PLAY)
            {
                updateStatusBar();
            }
        }

        public void playCompleteNext()
        {
            if (random)
            {
                currentPlay = getNextRandom();
                openMedia(playList[currentPlay]);
                return;
            }

            if (++currentPlay >= playList.Count)
            {
                currentPlay = 0;
                openMedia(playList[currentPlay], replay);
                if (!replay)
                {
                    currentStatus = PlayerStatus.STOP;
                    updateStatusBar();
                }
            }
            else
            {
                openMedia(playList[currentPlay]);
            }
        }

        public void updateVideoPosition()
        {
            if (videoWindow == null)
            {
                return;
            }
            videoWindow.SetWindowPosition(0, 0, 0, 0);
            videoWindow.SetWindowPosition(form.panelPlayer.ClientRectangle.Left, form.panelPlayer.ClientRectangle.Top, form.panelPlayer.ClientRectangle.Width, form.panelPlayer.ClientRectangle.Height - (form.barVisible ? 32 : 0));
        }

        private void openMedia(string file, bool play = true)
        {
            cleanUp();
            filterGraphManager = new FilgraphManager();
            try
            {
                filterGraphManager.RenderFile(file);
            }
            catch (Exception ex)
            {
                MessageBox.Show("播放器渲染失敗 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                removeMedia(currentPlay);
                return;
            }

            basicAudio = filterGraphManager as IBasicAudio;
            setVolume(volume);
            try
            {
                videoWindow = filterGraphManager as IVideoWindow;
                videoWindow.Owner = (int)form.panelPlayer.Handle;
                videoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
                updateVideoPosition();
            }
            catch
            {
                videoWindow = null;
            }

            mediaEvent = filterGraphManager as IMediaEvent;
            mediaEventEx = filterGraphManager as IMediaEventEx;
            mediaEventEx.SetNotifyWindow((int)form.Handle, WM_GRAPHNOTIFY, 0);

            mediaPosition = filterGraphManager as IMediaPosition;
            mediaControl = filterGraphManager as IMediaControl;

            initDuration();
            if (play)
            {
                mediaControl.Run();
                currentStatus = PlayerStatus.PLAY;
            }
        }

        private void initDuration()
        {
            duration = (int)getDuration();
            int hour = duration / 3600;
            int minute = (duration - hour * 3600) / 60;
            int second = duration - (hour * 3600 + minute * 60);
            form.sbpDuration.Text = string.Format("{0:D2} : {1:D2} : {2:D2}", hour, minute, second);

            form.tbDuration.Value = 0;
            form.tbDuration.Maximum = duration;
        }

        private void cleanUp()
        {
            if (mediaControl != null)
            {
                mediaControl.Stop();
            }
            if (mediaEventEx != null)
            {
                mediaEventEx.SetNotifyWindow(0, 0, 0);
            }
            if (videoWindow != null)
            {
                videoWindow.Visible = 0;
                videoWindow.Owner = 0;
            }

            // 為什麼要我手動管記憶體 ...
            if (mediaControl != null)
            {
                Marshal.FinalReleaseComObject(mediaControl);
                mediaControl = null;
            }
            if (mediaPosition != null)
            {
                Marshal.FinalReleaseComObject(mediaPosition);
                mediaPosition = null;
            }
            if (mediaEventEx != null)
            {
                Marshal.FinalReleaseComObject(mediaEventEx);
                mediaEventEx = null;
            }
            if (mediaEvent != null)
            {
                Marshal.FinalReleaseComObject(mediaEvent);
                mediaEvent = null;
            }
            if (videoWindow != null)
            {
                Marshal.FinalReleaseComObject(videoWindow);
                videoWindow = null;
            }
            if (basicAudio != null)
            {
                Marshal.FinalReleaseComObject(basicAudio);
                basicAudio = null;
            }
            if (filterGraphManager != null)
            {
                Marshal.FinalReleaseComObject(filterGraphManager);
                filterGraphManager = null;
            }
        }

        public string getCurrentPlay()
        {
            try
            {
                string[] path = playList[currentPlay].Replace("\\", "/").Split('/');
                string[] file = path[path.Length - 1].Split('.');
                StringBuilder sb = new StringBuilder();
                if (file.Length == 1)
                {
                    sb.Append(path[path.Length - 1]);
                }
                else
                {
                    for (int i = 0; i < file.Length - 1; ++i)
                    {
                        sb.Append(file[i]).Append(".");
                    }
                    sb.Length -= 1;
                }
                return sb.ToString();
            }
            catch
            {
                return null;
            }
        }

        private void updatePlayStatus()
        {
            string nowMedia = getCurrentPlay();
            if (nowMedia != null)
            {
                Program.form.labelCurrentPlay.Text = nowMedia;
            }

            switch (currentStatus)
            {
                case PlayerStatus.DEFAULT:
                    {
                        form.sbpPlayerStatus.Text = "就緒";
                        break;
                    }
                case PlayerStatus.STOP:
                    {
                        form.sbpPlayerStatus.Text = "已停止";
                        Program.form.pbPlay.BackgroundImage = Program.skinManager.getImage("Play");
                        break;
                    }
                case PlayerStatus.PAUSE:
                    {
                        form.sbpPlayerStatus.Text = "暫停";
                        Program.form.pbPlay.BackgroundImage = Program.skinManager.getImage("Play");
                        break;
                    }
                case PlayerStatus.PLAY:
                    {
                        form.sbpPlayerStatus.Text = "播放中";
                        Program.form.pbPlay.BackgroundImage = Program.skinManager.getImage("Pause");
                        break;
                    }
            }
        }

        private void updateStatusBar()
        {
            updatePlayStatus();
            if (mediaPosition != null)
            {
                int second = (int)getCurrentPosition();
                form.tbDuration.Value = second;

                int hour = second / 3600;
                int minute = (second - hour * 3600) / 60;
                second = second - (hour * 3600 + minute * 60);
                form.sbpCurrentTime.Text = string.Format("{0:D2} : {1:D2} : {2:D2}", hour, minute, second);
            }
            else
            {
                form.sbpDuration.Text = "00 : 00 : 00";
                form.sbpCurrentTime.Text = "00 : 00 : 00";

                form.tbDuration.Value = 0;
                form.tbDuration.Maximum = 0;
            }
        }

        public void appendMedia(string file)
        {
            playList.Add(file);
            Program.uiHandler.playListForm.updatePlayList();

            if (currentStatus == PlayerStatus.DEFAULT)
            {
                playInList(0);
            }
        }

        public void clearPlayList()
        {
            playList.Clear();
            Program.uiHandler.playListForm.updatePlayList();
            reset();
        }

        public double getAngle()
        {
            if (mediaPosition == null)
            {
                return 0;
            }
            double duration = getDuration();
            if (duration == 0)
            {
                return 0;
            }
            return 360 * getCurrentPosition() / duration;
        }

        public double getCurrentPosition()
        {
            return mediaPosition.CurrentPosition;
        }

        public double getDuration()
        {
            return mediaPosition.Duration;
        }

        public IPlayerControl getPlayerControl()
        {
            return this;
        }

        public IList<string> getPlayList()
        {
            return playList;
        }

        public PlayerStatus getStatus()
        {
            return currentStatus;
        }

        public static int convertToPercentVolume(int volume)
        {
            return 100 + volume / 100;
        }

        public int getVolume()
        {
            return volume;
        }

        public bool hasMedia()
        {
            return playList.Count > 0;
        }

        public bool isRandom()
        {
            return random;
        }

        public bool isReplay()
        {
            return replay;
        }

        public void next()
        {
            if (!hasMedia() || playList.Count <= 1)
            {
                return;
            }

            if (random)
            {
                addRandomPlayHistory();
                currentPlay = getNextRandom();
            }
            else if (++currentPlay >= playList.Count)
            {
                currentPlay = 0;
            }
            openMedia(playList[currentPlay]);
        }

        public void pause()
        {
            if (mediaControl == null)
            {
                return;
            }
            mediaControl.Pause();
            currentStatus = PlayerStatus.PAUSE;
            updateStatusBar();
        }

        public void play()
        {
            if (mediaControl == null)
            {
                return;
            }

            try
            {
                mediaControl.Run();
                currentStatus = PlayerStatus.PLAY;
            }
            catch (Exception ex)
            {
                MessageBox.Show("播放檔案時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void playInList(int index)
        {
            if (random)
            {
                addRandomPlayHistory();
            }
            currentPlay = index;
            openMedia(playList[index]);
        }

        public void prev()
        {
            if (!hasMedia() || playList.Count <= 1)
            {
                return;
            }

            if (random)
            {
                currentPlay = getPrevHistoryMedia();
            }
            else if (--currentPlay < 0)
            {
                currentPlay = playList.Count - 1;
            }
            openMedia(playList[currentPlay]);
        }

        public void registerPlayer()
        {
            form = Program.uiHandler.playerForm as DSPlayerForm;
            form.tbDuration.Scroll += new WinampTrackBar.ScrollDelegate(trackBarScrollEvent);
            timerStatusUpdate.Start();
        }

        private void reset()
        {
            stop();
            cleanUp();
            currentStatus = PlayerStatus.DEFAULT;
            updateStatusBar();
        }

        public void removeMedia(int index)
        {
            playList.RemoveAt(index);
            Program.uiHandler.playListForm.updatePlayList();

            if (!hasMedia())
            {
                reset();
                return;
            }

            if (currentPlay == index)
            {
                stop();
                if (random)
                {
                    currentPlay = getNextRandom();
                }
                else if (currentPlay >= playList.Count)
                {
                    currentPlay = 0;
                }
                openMedia(playList[currentPlay], false);
                updateStatusBar();
            }
            else if (currentPlay > index)
            {
                --currentPlay;
            }
        }

        public void setVolume(int volume)
        {
            this.volume = volume;
            if (basicAudio == null)
            {
                return;
            }

            // 一些解碼器無法支援音量變更
            try
            {
                basicAudio.Volume = convertToDirectShowVolume(volume);
            }
            catch
            {
            }
        }

        public static int convertToDirectShowVolume(int volume)
        {
            return -10000 + volume * 100;
        }

        public void stop()
        {
            if (mediaControl == null)
            {
                return;
            }
            mediaControl.Stop();
            mediaPosition.CurrentPosition = 0;
            currentStatus = PlayerStatus.STOP;
            updateStatusBar();
        }

        public void toggleFullScreen()
        {
            FormWindowState now = form.WindowState;
            if (now == FormWindowState.Normal)
            {
                form.MaximumSize = new Size(0, 0);

                originBar = form.barVisible;
                form.barVisible = false;
                visibleUI(false, true);

                form.panelPlayer.Location = new Point(0, 0);
                form.WindowState = FormWindowState.Maximized;
                form.panelPlayer.Size = new Size(form.Width, form.Height);
                updateVideoPosition();
            }
            else
            {
                form.barVisible = originBar;
                visibleUI(true, true);
                visibleUI(originBar);

                form.panelPlayer.Location = new Point(12, 12);
                form.WindowState = FormWindowState.Normal;
                form.panelPlayer.Size = new Size(form.Width - 24, form.Height - 24);
                updateVideoPosition();

                form.MaximumSize = new Size(1000, 550);
            }
        }

        public void toggleRandom()
        {
            hasPlayTurn.Clear();
            randomPlayHistory.Clear();
            random = !random;
        }

        public void toggleReplay()
        {
            replay = !replay;
        }

        public void toggleUI()
        {
            form.barVisible = !form.barVisible;
            visibleUI(form.barVisible);
            updateVideoPosition();
        }

        private void visibleUI(bool visible, bool containControl = false)
        {
            form.tbDuration.Visible = form.sbStatus.Visible = visible;
            if (containControl)
            {
                form.pbMin.Visible = form.pbMax.Visible = form.pbClose.Visible = visible;
            }
        }

        public bool isMute()
        {
            return volume <= 0;
        }

        private void trackBarScrollEvent(object sender, EventArgs e)
        {
            if (mediaPosition != null)
            {
                mediaPosition.CurrentPosition = form.tbDuration.Value;
            }
        }
    }
}
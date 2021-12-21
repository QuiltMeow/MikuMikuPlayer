using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WMPLib;

namespace MikuMikuPlayer
{
    public class WMPlayer : IPlayer
    {
        private WMPlayerForm form;
        private WMPControl wmp;
        private Timer timerUpdate;

        public WMPlayer()
        {
            timerUpdate = new Timer()
            {
                Interval = 500
            };
            timerUpdate.Tick += new EventHandler(timerUpdateEvent);
        }

        private void timerUpdateEvent(object sender, EventArgs e)
        {
            Program.form.updateVolume(); // 沒有事件 只能輪詢
        }

        public string getCurrentPlay()
        {
            if (hasMedia())
            {
                return wmp.currentMedia.name;
            }
            return null;
        }

        private void playStateChangeEvent(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            string nowMedia = getCurrentPlay();
            if (nowMedia != null)
            {
                Program.form.labelCurrentPlay.Text = nowMedia;
            }

            switch (e.newState)
            {
                case 1: // 停止
                case 2: // 暫停
                    {
                        Program.form.pbPlay.BackgroundImage = Program.skinManager.getImage("Play");
                        break;
                    }
                case 3: // 播放
                    {
                        Program.form.pbPlay.BackgroundImage = Program.skinManager.getImage("Pause");
                        break;
                    }
            }
        }

        private void clickEvent(object sender, _WMPOCXEvents_ClickEvent e)
        {
            if (e.nButton == 2)
            {
                Program.uiHandler.player.toggleUI();
            }
        }

        public void appendMedia(string file)
        {
            wmp.currentPlaylist.appendItem(wmp.newMedia(file));
            Program.uiHandler.playListForm.updatePlayList();
        }

        public void clearPlayList()
        {
            wmp.currentPlaylist.clear();
            Program.uiHandler.playListForm.updatePlayList();
        }

        public double getAngle()
        {
            double duration = getDuration();
            if (duration == 0)
            {
                return 0;
            }
            return 360 * getCurrentPosition() / duration;
        }

        public double getCurrentPosition()
        {
            return wmp.Ctlcontrols.currentPosition;
        }

        public double getDuration()
        {
            return wmp.currentMedia.duration;
        }

        public IList<string> getPlayList()
        {
            IList<string> ret = new List<string>();
            for (int i = 0; i < wmp.currentPlaylist.count; ++i)
            {
                ret.Add(wmp.currentPlaylist.Item[i].sourceURL);
            }
            return ret;
        }

        public PlayerStatus getStatus()
        {
            WMPPlayState status = wmp.playState;
            switch (status)
            {
                case WMPPlayState.wmppsStopped:
                    {
                        return PlayerStatus.STOP;
                    }
                case WMPPlayState.wmppsUndefined:
                    {
                        return PlayerStatus.DEFAULT;
                    }
                case WMPPlayState.wmppsPaused:
                case WMPPlayState.wmppsReady:
                    {
                        return PlayerStatus.PAUSE;
                    }
                default:
                    {
                        return PlayerStatus.PLAY;
                    }
            }
        }

        public int getVolume()
        {
            return wmp.settings.volume;
        }

        public bool hasMedia()
        {
            return wmp.currentMedia != null;
        }

        public bool isRandom()
        {
            return wmp.settings.getMode("shuffle");
        }

        public bool isReplay()
        {
            return wmp.settings.getMode("loop");
        }

        public void next()
        {
            wmp.Ctlcontrols.next();
        }

        public void pause()
        {
            wmp.Ctlcontrols.pause();
        }

        public void play()
        {
            wmp.Ctlcontrols.play();
        }

        public void playInList(int index)
        {
            wmp.Ctlcontrols.playItem(wmp.currentPlaylist.get_Item(index));
        }

        public void prev()
        {
            wmp.Ctlcontrols.previous();
        }

        public void removeMedia(int index)
        {
            wmp.currentPlaylist.removeItem(wmp.currentPlaylist.Item[index]);
            Program.uiHandler.playListForm.updatePlayList();
        }

        public void setVolume(int volume)
        {
            wmp.settings.volume = volume;
        }

        public void stop()
        {
            wmp.Ctlcontrols.stop();
        }

        public void toggleRandom()
        {
            wmp.settings.setMode("shuffle", !isRandom());
        }

        public void toggleReplay()
        {
            wmp.settings.setMode("loop", !isReplay());
        }

        public IPlayerControl getPlayerControl()
        {
            return wmp;
        }

        public void toggleFullScreen()
        {
            bool fullScreen = wmp.fullScreen;
            wmp.fullScreen = !fullScreen;
        }

        public void registerPlayer()
        {
            form = Program.uiHandler.playerForm as WMPlayerForm;
            wmp = form.wmp;
            wmp.enableContextMenu = false;
            wmp.uiMode = "none";

            wmp.ClickEvent += new AxWMPLib._WMPOCXEvents_ClickEventHandler(clickEvent);
            wmp.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(playStateChangeEvent);

            wmp.Visible = true;
            timerUpdate.Start();
        }

        public void toggleUI()
        {
            switch (wmp.uiMode)
            {
                case "none":
                    {
                        wmp.uiMode = "full";
                        break;
                    }
                case "full":
                    {
                        wmp.uiMode = "none";
                        break;
                    }
            }
        }

        public bool isMute()
        {
            return getVolume() <= 0 || wmp.settings.mute;
        }
    }
}
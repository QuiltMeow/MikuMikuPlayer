using DiscordRPC;
using System;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public class RPCClient
    {
        public const int DISCORD_PIPE = -1;
        public const string CLIENT_ID = "702003041934639114";

        private static readonly DiscordRPC.Logging.LogLevel logLevel;

        private Timer timerUpdate;
        private DiscordRpcClient rpc;

        static RPCClient()
        {
            logLevel = DiscordRPC.Logging.LogLevel.Trace;
        }

        public RPCClient()
        {
            start();
        }

        private void start()
        {
            rpc = new DiscordRpcClient(CLIENT_ID, DISCORD_PIPE, new DiscordRPC.Logging.ConsoleLogger(logLevel, true), false);
            rpc.Initialize();

            timerUpdate = new Timer()
            {
                Interval = 3000
            };
            timerUpdate.Tick += new EventHandler(timerUpdateTick);
            timerUpdate.Start();
        }

        private static string sanitizeRPString(string data)
        {
            return data.Substring(0, data.Length > 128 ? 128 : data.Length);
        }

        private void timerUpdateTick(object sender, EventArgs e)
        {
            rpc.Invoke();
            RichPresence rp = createRP();
            rpc.SetPresence(rp);
        }

        private static RichPresence createRP()
        {
            IPlayer player = Program.uiHandler.player;
            PlayerStatus status = player.getStatus();
            string currentPlay = player.getCurrentPlay();

            RichPresence rp = new RichPresence()
            {
                Assets = new Assets()
                {
                    LargeImageText = "Miku Miku 播放器"
                }
            };

            switch (status)
            {
                case PlayerStatus.DEFAULT:
                    {
                        rp.Details = "就緒";
                        break;
                    }
                case PlayerStatus.STOP:
                    {
                        rp.Details = "已停止";
                        break;
                    }
                case PlayerStatus.PAUSE:
                    {
                        rp.Details = "暫停中";
                        break;
                    }
                case PlayerStatus.PLAY:
                    {
                        rp.Details = "播放中";
                        break;
                    }
                default:
                    {
                        rp.Details = "未知";
                        break;
                    }
            }

            if (currentPlay != null)
            {
                rp.State = sanitizeRPString("播放檔案 : " + currentPlay);
            }

            if (player.getVolume() > 50 && !player.isMute())
            {
                rp.Assets.LargeImageKey = "miku_ani";
            }
            else
            {
                rp.Assets.LargeImageKey = "miku";
            }
            return rp;
        }
    }
}
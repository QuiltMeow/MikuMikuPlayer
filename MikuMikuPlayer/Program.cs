using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

/** 喵 ~ 喵 ~ 喵 ~
  * 貓貓最可愛了唷 <3
  * 原始作者 : smallru8
  * 程式重構 : 棉被 & 小棉被 (完全重寫)
  * Code Review : Pass
  */

namespace MikuMikuPlayer
{
    public static class Program
    {
        private static readonly bool CHECK_MULTI_INSTANCE = true;
        public static readonly bool ENABLE_DISCORD_RPC = true;

        public static UIHandler uiHandler
        {
            get;
            private set;
        }

        public static SettingManager settingManager
        {
            get;
            private set;
        }

        public static SkinManager skinManager
        {
            get;
            private set;
        }

        public static MainForm form
        {
            get;
            private set;
        }

        public static string[] initFileList
        {
            get;
            private set;
        }

        public static Point? initLocation
        {
            get;
            private set;
        }

        public static Random random
        {
            get;
            private set;
        }

        public static RPCClient rpc
        {
            get;
            private set;
        }

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
#if _CONVERT_LEGACY_SETTING
            ConfigParser.configYmlToBinary("config.yml");
            ConfigParser.skinYmlToBinary("skin.yml");
#endif

            if (CHECK_MULTI_INSTANCE)
            {
                Process currentProcess = Process.GetCurrentProcess();
                string processName = currentProcess.ProcessName;
                if (Process.GetProcessesByName(processName).Length > 1)
                {
                    MessageBox.Show("已偵測到其他播放器正在執行", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            random = new Random(Guid.NewGuid().GetHashCode());

            if (args.Length > 0)
            {
                initFileList = new string[args.Length];
                for (int i = 0; i < args.Length; ++i)
                {
                    initFileList[i] = args[i];
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new MainForm();

            settingManager = new SettingManager();
            skinManager = new SkinManager();
            initLocation = settingManager.loadConfig(true);

            uiHandler = new UIHandler();
            uiHandler.player.registerPlayer();
            uiHandler.applyUI(true);

            if (ENABLE_DISCORD_RPC)
            {
                rpc = new RPCClient();
            }

            form.timerMarquee.Start();
            Application.Run(form);
        }

        public static void fail(string message = null)
        {
            if (message != null)
            {
                MessageBox.Show(message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Environment.Exit(1);
        }

        public static void selfRestart()
        {
            settingManager.saveConfig(true);

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.Arguments = "/c ping 127.0.0.1 -n 2 && start MikuMikuLauncher";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            psi.CreateNoWindow = true;
            psi.FileName = "cmd.exe";
            Process.Start(psi);
            Environment.Exit(Environment.ExitCode);
        }
    }
}
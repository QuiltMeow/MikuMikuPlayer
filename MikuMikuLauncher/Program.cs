using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MikuMikuLauncher
{
    public static class Program
    {
        private const int CHANGEABLE_CONTROL_COUNT = 13;

        public static string getPlayerType()
        {
            try
            {
                using (FileStream fs = new FileStream("config.ew", FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        br.ReadString();
                        for (int i = 1; i <= CHANGEABLE_CONTROL_COUNT; ++i)
                        {
                            br.ReadInt32();
                            br.ReadInt32();
                        }
                        return br.ReadString();
                    }
                }
            }
            catch
            {
                return "WMP";
            }
        }

        public static string parseURLFile(string path)
        {
            try
            {
                string line = File.ReadLines(path).Skip(4).Take(1).First();
                return line.Replace("URL=", "");
            }
            catch
            {
                return null;
            }
        }

        public static IList<string> parseText(string path)
        {
            IList<string> ret = new List<string>();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            ret.Add(line);
                        }
                    }
                }
                return ret;
            }
            catch
            {
                return null;
            }
        }

        public static void run(string[] args)
        {
            Process process = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            info.CreateNoWindow = true;

            process.StartInfo = info;
            process.Start();

            StringBuilder sb = new StringBuilder();
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; ++i)
                {
                    string[] split = args[i].Split('.');
                    string extension = split[split.Length - 1].ToUpper();
                    switch (extension)
                    {
                        // 展開文字文件路徑 主要用於提供 http 播放
                        case "TXT":
                            {
                                IList<string> fileList = parseText(args[i]);
                                if (fileList != null)
                                {
                                    foreach (string file in fileList)
                                    {
                                        sb.Append(" ").Append(file);
                                    }
                                }
                                break;
                            }
                        case "URL":
                            {
                                string url = parseURLFile(args[i]);
                                if (url != null)
                                {
                                    sb.Append(" ").Append(url);
                                }
                                break;
                            }
                        default:
                            {
                                sb.Append(" ").Append(args[i]);
                                break;
                            }
                    }
                }
            }

            using (StreamWriter sw = process.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    // 解決 Windows Media Player 在多顯卡環境下以 Nvidia 顯卡執行時造成崩潰問題
                    if (getPlayerType() == "WMP")
                    {
                        sw.WriteLine("set SHIM_MCCOMPAT=0x800000000");
                    }
                    sw.WriteLine("start MikuMikuPlayer" + sb.ToString());
                }
            }
            Application.Exit();
        }

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            run(args);
        }
    }
}
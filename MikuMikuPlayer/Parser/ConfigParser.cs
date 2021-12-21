using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    // 設定檔案相容轉換器
    public class ConfigParser
    {
        private const string VERSION = "[MikuMikuWMP-Beta-1812.5]";

        public static void configYmlToBinary(string file)
        {
            string font;
            IList<Point> controlLocation = new List<Point>();

            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        sr.ReadLine();
                        font = sr.ReadLine().Split(' ')[1];
                        sr.ReadLine();
                        sr.ReadLine();
                        for (int i = 0; i < 11; ++i)
                        {
                            controlLocation.Add(parseLocation(sr.ReadLine()));
                        }
                        sr.ReadLine();
                        for (int i = 0; i < 2; ++i)
                        {
                            controlLocation.Add(parseLocation(sr.ReadLine()));
                        }
                    }
                }

                using (FileStream fs = new FileStream(file + ".ew", FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(font == "SetoFont" ? "Default" : font);
                        foreach (Point location in controlLocation)
                        {
                            bw.Write(location.X);
                            bw.Write(location.Y);
                        }
                        bw.Write("WMP");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("設定檔案轉換失敗 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void configBinaryToYml(string file)
        {
            string[] settingKey = new string[] { "setting", "play", "stop", "close", "next", "previous", "video", "shuffle", "cycle", "musicLs", "qA", "marquee", "vol" };

            string font;
            IList<Point> controlLocation = new List<Point>();

            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        font = br.ReadString();
                        for (int i = 0; i < settingKey.Length; ++i)
                        {
                            int x = br.ReadInt32();
                            int y = br.ReadInt32();
                            controlLocation.Add(new Point(x, y));
                        }
                    }
                }

                using (FileStream fs = new FileStream(file + ".yml", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(VERSION);
                        sw.WriteLine("Font: " + (font == "Default" ? "SetoFont" : font));
                        sw.WriteLine("Components:");
                        sw.WriteLine(space(4) + "Button: L T");
                        for (int i = 0; i < controlLocation.Count; ++i)
                        {
                            if (settingKey[i] == "marquee")
                            {
                                sw.WriteLine(space(4) + "Lable: L T"); // ?
                            }
                            sw.WriteLine(space(8) + settingKey[i] + ": " + controlLocation[i].X + " " + controlLocation[i].Y);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("設定檔案轉換失敗 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string space(int count)
        {
            return new StringBuilder().Append(' ', count).ToString();
        }

        private static Point parseLocation(string data)
        {
            string[] pattern = data.Split(':')[1].Trim().Split(' ');
            return new Point(int.Parse(pattern[0]), int.Parse(pattern[1]));
        }

        public static void skinYmlToBinary(string file)
        {
            string skin;

            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        sr.ReadLine();
                        skin = sr.ReadLine().Split(':')[1].Trim();
                    }
                }

                using (FileStream fs = new FileStream(file + ".ew", FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(skin);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("外觀檔案轉換失敗 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void playListYmlToBinary(string file)
        {
            IList<string> playList = new List<string>();

            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            playList.Add(sr.ReadLine());
                        }
                    }
                }

                using (FileStream fs = new FileStream(file + ".mikupl", FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        foreach (string path in playList)
                        {
                            bw.Write(path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("播放清單檔案轉換失敗 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
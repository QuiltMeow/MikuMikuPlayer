using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public class SettingManager
    {
        public PlayerType playerType
        {
            get;
            set;
        }

        public string currentSkin
        {
            get;
            set;
        }

        public bool editable
        {
            get;
            set;
        }

        public string selectFont
        {
            get;
            set;
        }

        public FontFamily[] fontFamily
        {
            get;
            set;
        }

        public IList<Control> changeableLocationControl
        {
            get;
            set;
        }

        public IOrderedDictionary defaultLocation
        {
            get;
            set;
        }

        public SettingManager()
        {
            initDefaultLocation();
            initConfig();
            loadFont();
        }

        private void initConfig()
        {
            if (!File.Exists("config.ew"))
            {
                createConfig();
            }
        }

        private void initDefaultLocation()
        {
            changeableLocationControl = new List<Control>()
            {
                Program.form.pbSetting,
                Program.form.pbPlay,
                Program.form.pbStop,
                Program.form.pbExit,
                Program.form.pbNext,
                Program.form.pbPrev,
                Program.form.pbPlayer,
                Program.form.pbRandom,
                Program.form.pbReplay,
                Program.form.pbPlayList,
                Program.form.pbHelp,
                Program.form.labelCurrentPlay,
                Program.form.pbVolume
            };

            defaultLocation = new OrderedDictionary() {
                { Program.form.pbSetting, Program.form.pbSetting.Location },
                { Program.form.pbPlay, Program.form.pbPlay.Location },
                { Program.form.pbStop, Program.form.pbStop.Location },
                { Program.form.pbExit, Program.form.pbExit.Location },
                { Program.form.pbNext, Program.form.pbNext.Location },
                { Program.form.pbPrev, Program.form.pbPrev.Location },
                { Program.form.pbPlayer, Program.form.pbPlayer.Location },
                { Program.form.pbRandom, Program.form.pbRandom.Location },
                { Program.form.pbReplay, Program.form.pbReplay.Location },
                { Program.form.pbPlayList,Program.form.pbPlayList.Location },
                { Program.form.pbHelp, Program.form.pbHelp.Location },
                { Program.form.labelCurrentPlay, Program.form.labelCurrentPlay.Location },
                { Program.form.pbVolume, Program.form.pbVolume.Location }
            };
        }

        public void createConfig()
        {
            try
            {
                using (FileStream fs = new FileStream("config.ew", FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write("Default");
                        foreach (Point point in defaultLocation.Values)
                        {
                            bw.Write(point.X);
                            bw.Write(point.Y);
                        }
                        bw.Write("WMP");
                    }
                }
            }
            catch (Exception ex)
            {
                Program.fail("設定檔案建立失敗 : " + ex.Message);
            }
        }

        private void loadFont()
        {
            InstalledFontCollection installFontCollection = new InstalledFontCollection();
            fontFamily = new FontFamily[installFontCollection.Families.Length + 1];
            for (int i = 0; i < installFontCollection.Families.Length; ++i)
            {
                fontFamily[i + 1] = installFontCollection.Families[i];
            }

            PrivateFontCollection privateFontCollection = new PrivateFontCollection();
            using (MemoryStream ms = new MemoryStream(FontResource.Font))
            {
                byte[] fontData = ms.ToArray();
                unsafe
                {
                    fixed (byte* fontDataPointer = fontData)
                    {
                        uint installFontCount = 0;
                        AddFontMemResourceEx((IntPtr)fontDataPointer, (uint)fontData.Length, IntPtr.Zero, ref installFontCount);
                        privateFontCollection.AddMemoryFont((IntPtr)fontDataPointer, fontData.Length);
                    }
                }
            }
            fontFamily[0] = privateFontCollection.Families[0];
        }

        public Point? loadConfig(bool loadLocation = false)
        {
            try
            {
                using (FileStream fs = new FileStream("config.ew", FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        selectFont = br.ReadString();
                        foreach (Control control in changeableLocationControl)
                        {
                            int x = br.ReadInt32();
                            int y = br.ReadInt32();
                            control.Location = new Point(x, y);
                        }
                        playerType = br.ReadString() == "WMP" ? PlayerType.WINDOWS_MEDIA_PLAYER : PlayerType.DIRECT_SHOW_PLAYER;

                        if (loadLocation)
                        {
                            try
                            {
                                int appX = br.ReadInt32();
                                int appY = br.ReadInt32();
                                return new Point(appX, appY);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Program.fail("設定檔案讀取失敗 : " + ex.Message);
            }
            return null;
        }

        public byte[] loadConfigMemory()
        {
            IList<Point> location = new List<Point>();
            try
            {
                using (FileStream fs = new FileStream("config.ew", FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        br.ReadString();
                        for (int i = 1; i <= changeableLocationControl.Count; ++i)
                        {
                            int x = br.ReadInt32();
                            int y = br.ReadInt32();
                            location.Add(new Point(x, y));
                        }
                    }
                }
            }
            catch
            {
                location.Clear();
                foreach (Point point in defaultLocation.Values)
                {
                    location.Add(new Point(point.X, point.Y));
                }
            }

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    bw.Write(selectFont);
                    foreach (Point point in location)
                    {
                        bw.Write(point.X);
                        bw.Write(point.Y);
                    }
                    bw.Write(playerType == PlayerType.WINDOWS_MEDIA_PLAYER ? "WMP" : "DSP");
                    return ms.ToArray();
                }
            }
            throw new EWException("串流開啟失敗");
        }

        public void saveConfig(bool saveLocation = false)
        {
            try
            {
                using (FileStream fs = new FileStream("config.ew", FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(selectFont);
                        foreach (Control control in changeableLocationControl)
                        {
                            bw.Write(control.Location.X);
                            bw.Write(control.Location.Y);
                        }
                        bw.Write(playerType == PlayerType.WINDOWS_MEDIA_PLAYER ? "WMP" : "DSP");

                        if (saveLocation)
                        {
                            Point location = Program.form.Location;
                            bw.Write(location.X);
                            bw.Write(location.Y);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Program.fail("設定檔案儲存失敗 : " + ex.Message);
            }
        }

        public int getFontIndex()
        {
            if (selectFont == "Default")
            {
                return 0;
            }
            else
            {
                for (int i = 1; i < fontFamily.Length; ++i)
                {
                    if (fontFamily[i].Name == selectFont)
                    {
                        return i;
                    }
                }
            }
            throw new EWException("找不到指定字型");
        }

        public void applyFont()
        {
            SettingForm settingForm = Program.uiHandler.settingForm;
            HelpForm helpForm = Program.uiHandler.helpForm;
            PlayListForm playListForm = Program.uiHandler.playListForm;
            MainForm mainForm = Program.form;
            SpectrumForm spectrumForm = Program.uiHandler.spectrumForm;

            int fontIndex;
            try
            {
                fontIndex = getFontIndex();
            }
            catch (EWException ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fontIndex = 0;
            }
            Font defaultFont = new Font(fontFamily[fontIndex], 9);
            Font bigFont = new Font(fontFamily[fontIndex], 12);

            settingForm.labelSetting.Font = bigFont;
            settingForm.labelPlayerType.Font = settingForm.cbPlayerType.Font = settingForm.labelFont.Font
                = settingForm.labelPreview.Font = settingForm.labelLockStatus.Font = settingForm.labelSkin.Font
                = settingForm.btnResetUI.Font = settingForm.btnSkinLocation.Font = settingForm.btnSaveSkin.Font
                = settingForm.btnResetSetting.Font = settingForm.btnApply.Font = settingForm.cbFont.Font
                = settingForm.cbSkin.Font = settingForm.chkLockUI.Font = settingForm.btnUpdateList.Font
                = settingForm.btnUndo.Font = settingForm.labelCurrentFont.Font = settingForm.labelCurrentSkin.Font
                = settingForm.llCodec.Font = defaultFont;

            settingForm.labelCurrentFont.Text = "目前套用 : " + fontFamily[fontIndex].Name;

            helpForm.labelHelp.Font = helpForm.labelHelpContent.Font = helpForm.labelPlayList.Font
                = helpForm.labelReplay.Font = helpForm.labelRandom.Font = helpForm.labelPlayer.Font
                = bigFont;

            playListForm.lbPlayList.Font = bigFont;
            mainForm.labelCurrentPlay.Font = new Font(fontFamily[fontIndex], 9.75F);

            spectrumForm.labelLeft.Font = spectrumForm.labelRight.Font = spectrumForm.labelDeviceList.Font
                = spectrumForm.cbDeviceList.Font = spectrumForm.btnEnable.Font = defaultFont;
        }

        [DllImport("gdi32.dll")]
        public static extern IntPtr AddFontMemResourceEx(IntPtr pointerFont, uint fontSize, IntPtr pointerReserve, [In] ref uint pointerInstallFontCount);
    }
}
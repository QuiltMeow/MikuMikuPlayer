using Ionic.Zip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;

namespace MikuMikuPlayer
{
    public class SkinManager
    {
        public const string DEFAULT_SKIN = "Default";

        private readonly IDictionary<string, Image> component;

        public IList<string> skinList
        {
            get;
            private set;
        }

        public SkinManager()
        {
            component = new Dictionary<string, Image>();
            initSkinConfig();
            loadSkinList();

            loadSkinConfig();
            loadDefaultSkin();
            setupSkin(Program.settingManager.currentSkin, true);
        }

        private void loadSkinConfig()
        {
            try
            {
                using (FileStream fs = new FileStream("skin.ew", FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        string skinName = br.ReadString();
                        Program.settingManager.currentSkin = skinName;
                    }
                }
            }
            catch (Exception ex)
            {
                Program.fail("外觀檔案讀取失敗 : " + ex.Message);
            }
        }

        private void loadDefaultSkin()
        {
            ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                string resourceKey = entry.Key.ToString();
                Image resource = (Image)entry.Value;
                component[resourceKey] = resource;
            }
        }

        public void loadSkinList()
        {
            skinList = new List<string>()
            {
                DEFAULT_SKIN
            };

            foreach (string path in Directory.GetFiles("skin", "*.zip"))
            {
                string[] split = path.Split('\\');
                skinList.Add(split[split.Length - 1]);
            }
        }

        private static void initSkinConfig()
        {
            if (!Directory.Exists("skin"))
            {
                Directory.CreateDirectory("skin");
            }

            if (!File.Exists("skin.ew"))
            {
                try
                {
                    using (FileStream fs = new FileStream("skin.ew", FileMode.Create, FileAccess.Write))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fs))
                        {
                            bw.Write(DEFAULT_SKIN);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.fail("外觀檔案建立失敗 : " + ex.Message);
                }
            }
        }

        public Image getImage(string imageName)
        {
            if (component.ContainsKey(imageName))
            {
                return component[imageName];
            }
            return null;
        }

        public void applySkin(bool init)
        {
            MainForm target = Program.form;
            target.BackgroundImage = getImage("Main");
            target.pbExit.BackgroundImage = getImage("Exit");
            target.pbStop.BackgroundImage = getImage("Stop");
            target.pbPrev.BackgroundImage = getImage("Prev");
            target.pbNext.BackgroundImage = getImage("Next");
            target.pbPlayList.BackgroundImage = getImage("PlayList");
            target.pbReplay.BackgroundImage = getImage("Replay");
            target.pbRandom.BackgroundImage = getImage("Random");
            target.pbHelp.BackgroundImage = getImage("Help");
            target.pbPlayer.BackgroundImage = getImage("Player");
            target.pbSetting.BackgroundImage = getImage("Setting");

            PlayerForm playerForm = Program.uiHandler.playerForm;
            playerForm.pbMin.BackgroundImage = getImage("Min");
            playerForm.pbMax.BackgroundImage = getImage("Max");
            playerForm.pbClose.BackgroundImage = getImage("Close");
            playerForm.BackgroundImage = getImage("BgPlayer");

            PlayListForm playListForm = Program.uiHandler.playListForm;
            playListForm.pbExit.BackgroundImage = getImage("Exit");
            playListForm.pbHelp.BackgroundImage = getImage("Help");
            playListForm.pbLoadList.BackgroundImage = getImage("LoadList");
            playListForm.pbSaveList.BackgroundImage = getImage("SaveList");
            playListForm.BackgroundImage = getImage("BgPlayList");

            SettingForm settingForm = Program.uiHandler.settingForm;
            settingForm.BackgroundImage = getImage("BgPlayer");
            settingForm.labelCurrentSkin.Text = "目前套用 : " + Program.settingManager.currentSkin;

            applyHelpFormIcon();
            if (init)
            {
                target.pbVolume.BackgroundImage = getImage("Volume_5");
                target.pbPlay.BackgroundImage = getImage("Play");
            }
            else
            {
                target.updateVolume();
                target.updatePlayStatus();
            }
        }

        private void applyHelpFormIcon()
        {
            HelpForm helpForm = Program.uiHandler.helpForm;
            helpForm.pbExit.BackgroundImage = getImage("Exit");
            helpForm.pbPlayList.BackgroundImage = getImage("PlayList");
            helpForm.pbReplay.BackgroundImage = getImage("Replay");
            helpForm.pbRandom.BackgroundImage = getImage("Random");
            helpForm.pbPlayer.BackgroundImage = getImage("Player");
            helpForm.BackgroundImage = getImage("BgPlayList");
        }

        public void updateSkin()
        {
            setupSkin(Program.settingManager.currentSkin);
            Program.settingManager.loadConfig();
        }

        public void saveSkinConfig()
        {
            try
            {
                using (FileStream fs = new FileStream("skin.ew", FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(Program.settingManager.currentSkin);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.fail("外觀檔案儲存失敗 : " + ex.Message);
            }
        }

        public void setupSkin(string target, bool init = false)
        {
            string path = "skin\\" + target;
            if (!target.Equals(DEFAULT_SKIN) && File.Exists(path))
            {
                try
                {
                    using (ZipFile zip = ZipFile.Read(path))
                    {
                        foreach (ZipEntry zipEntry in zip)
                        {
                            using (MemoryStream msSkin = new MemoryStream())
                            {
                                zipEntry.Extract(msSkin);
                                string fileKey = zipEntry.FileName.Split('.')[0];
                                if (component.ContainsKey(fileKey))
                                {
                                    component[fileKey] = Image.FromStream(msSkin);
                                }
                                else if (zipEntry.FileName.Equals("config.ew"))
                                {
                                    using (FileStream fs = new FileStream("config.ew", FileMode.Create, FileAccess.Write))
                                    {
                                        msSkin.Position = 0;
                                        msSkin.CopyTo(fs);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.fail("外部外觀檔案讀取失敗 : " + ex.Message);
                }
            }
            else if (!init)
            {
                loadDefaultSkin();
            }
        }
    }
}
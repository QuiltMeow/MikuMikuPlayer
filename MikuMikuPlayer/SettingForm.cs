using Ionic.Zip;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            UIHandler.registerHoverEvent(pbExit);

            loadSetting(true);
        }

        private void locateSelectSetting()
        {
            if (Program.settingManager.selectFont == "Default")
            {
                cbFont.SelectedIndex = 0;
            }
            else
            {
                for (int i = 1; i < cbFont.Items.Count; ++i)
                {
                    if (cbFont.Items[i].ToString() == Program.settingManager.selectFont)
                    {
                        cbFont.SelectedIndex = i;
                        break;
                    }
                }
            }

            for (int i = 0; i < cbSkin.Items.Count; ++i)
            {
                if (cbSkin.Items[i].ToString() == Program.settingManager.currentSkin)
                {
                    cbSkin.SelectedIndex = i;
                    break;
                }
            }

            cbPlayerType.SelectedIndex = Program.settingManager.playerType == PlayerType.WINDOWS_MEDIA_PLAYER ? 0 : 1;
        }

        public void loadSetting(bool loadFontList = false)
        {
            if (loadFontList)
            {
                cbFont.Items.Clear();
                foreach (FontFamily font in Program.settingManager.fontFamily)
                {
                    cbFont.Items.Add(font.Name);
                }
            }

            cbSkin.Items.Clear();
            foreach (string skin in Program.skinManager.skinList)
            {
                cbSkin.Items.Add(skin);
            }
            locateSelectSetting();
        }

        private void btnResetSetting_Click(object sender, EventArgs e)
        {
            Program.settingManager.createConfig();

            Program.settingManager.currentSkin = SkinManager.DEFAULT_SKIN;
            Program.skinManager.saveSkinConfig();

            if (Program.settingManager.playerType == PlayerType.WINDOWS_MEDIA_PLAYER)
            {
                setupSetting();
                locateSelectSetting();
            }
            else
            {
                Program.selfRestart();
            }
        }

        private void btnResetUI_Click(object sender, EventArgs e)
        {
            foreach (DictionaryEntry entry in Program.settingManager.defaultLocation)
            {
                (entry.Key as Control).Location = (Point)entry.Value;
            }
        }

        private void chkLockUI_CheckedChanged(object sender, EventArgs e)
        {
            labelLockStatus.Text = chkLockUI.Checked ? "已鎖定" : "編輯模式";
            Program.settingManager.editable = !chkLockUI.Checked;
        }

        private void btnSkinLocation_Click(object sender, EventArgs e)
        {
            string path = "skin";
            Process process = new Process();
            process.StartInfo.FileName = path;
            process.Start();
        }

        private void btnSaveSkin_Click(object sender, EventArgs e)
        {
            string skin = Program.settingManager.currentSkin;
            if (!skin.Contains(".zip"))
            {
                skin += ".zip";
            }

            try
            {
                using (ZipFile zip = new ZipFile("skin\\" + skin))
                {
                    byte[] file = Program.settingManager.loadConfigMemory();
                    foreach (ZipEntry zipEntry in zip)
                    {
                        if (zipEntry.FileName.Equals("config.ew"))
                        {
                            zip.RemoveEntry(zipEntry.FileName);
                            break;
                        }
                    }
                    zip.AddEntry("config.ew", file);
                    zip.Save();
                }
                Program.uiHandler.reloadSettingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存外觀設定至壓縮檔時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            PlayerType origin = Program.settingManager.playerType;
            PlayerType now = cbPlayerType.SelectedIndex == 0 ? PlayerType.WINDOWS_MEDIA_PLAYER : PlayerType.DIRECT_SHOW_PLAYER;

            Program.settingManager.playerType = now;
            Program.settingManager.selectFont = cbFont.SelectedIndex == 0 ? "Default" : cbFont.SelectedItem.ToString();
            Program.settingManager.saveConfig();

            Program.settingManager.currentSkin = cbSkin.SelectedItem.ToString();
            Program.skinManager.saveSkinConfig();

            if (origin == now)
            {
                setupSetting();
            }
            else
            {
                Program.selfRestart();
            }
        }

        private void setupSetting()
        {
            Program.skinManager.updateSkin();
            Program.uiHandler.applyUI();
        }

        private void cbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelPreview.Font = new Font(Program.settingManager.fontFamily[cbFont.SelectedIndex], 9);
        }

        private void SettingForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UIHandler.ReleaseCapture();
                UIHandler.SendMessage(Handle, UIHandler.WM_NCLBUTTONDOWN, UIHandler.HT_CAPTION, 0);
            }
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            Program.uiHandler.reloadSettingList();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Visible = false;
            chkLockUI.Checked = true;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            setupSetting();
            locateSelectSetting();
        }

        private void llCodec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llCodec.LinkVisited = true;
            Process.Start("https://codecguide.com/download_kl.htm");
        }
    }
}
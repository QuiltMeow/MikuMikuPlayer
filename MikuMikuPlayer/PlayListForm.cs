using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    // ListBox 只有一堆 Workaround
    public partial class PlayListForm : Form
    {
        public PlayListForm()
        {
            InitializeComponent();
            registerMouseHoverEvent();

            lbPlayList.DragEnter += new DragEventHandler(UIHandler.fileDragEnterEvent);
            lbPlayList.DragDrop += new DragEventHandler(UIHandler.fileDragDropEvent);
            lbPlayList.KeyDown += new KeyEventHandler(playListKeyDownEvent);
            lbPlayList.MouseDoubleClick += new MouseEventHandler(playListMouseDoubleClickEvent);
        }

        private void playListKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int index = lbPlayList.SelectedIndex;
                if (index >= 0)
                {
                    Program.uiHandler.player.removeMedia(index);
                }
            }
        }

        private void playListMouseDoubleClickEvent(object sender, MouseEventArgs e)
        {
            int index = lbPlayList.SelectedIndex;
            if (index >= 0)
            {
                Program.uiHandler.player.playInList(index);
            }
        }

        public void updatePlayList()
        {
            lbPlayList.Items.Clear();
            IList<string> playList = Program.uiHandler.player.getPlayList();
            foreach (string file in playList)
            {
                string[] split = file.Replace("\\", "/").Split('/');
                lbPlayList.Items.Add(split[split.Length - 1]);
            }
        }

        private void pbLoadList_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "播放清單檔案|*.mikupl",
                Title = "請餵食播放清單檔案"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;

                Program.uiHandler.player.clearPlayList();
                UIHandler.loadPlayList(filePath);
            }
        }

        private void pbSaveList_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "播放清單檔案|*.mikupl",
                Title = "請選擇儲存位置"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fs))
                        {
                            IList<string> playList = Program.uiHandler.player.getPlayList();
                            foreach (string file in playList)
                            {
                                bw.Write(file);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("播放清單儲存失敗 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pbHelp_Click(object sender, EventArgs e)
        {
            Program.uiHandler.helpForm.applyPlayListHelp();
            Program.uiHandler.helpForm.Visible = true;
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void PlayListForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UIHandler.ReleaseCapture();
                UIHandler.SendMessage(Handle, UIHandler.WM_NCLBUTTONDOWN, UIHandler.HT_CAPTION, 0);
            }
        }
    }
}
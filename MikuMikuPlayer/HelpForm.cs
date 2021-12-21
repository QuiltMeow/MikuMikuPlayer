using System;
using System.Text;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public partial class HelpForm : Form
    {
        private readonly StringBuilder sbMain, sbPlayList;

        public HelpForm()
        {
            InitializeComponent();
            UIHandler.registerHoverEvent(pbExit);

            sbMain = new StringBuilder();
            sbPlayList = new StringBuilder();
            initHelpContent();
        }

        private void initHelpContent()
        {
            sbMain.AppendLine("在播放器上可使用滾輪").Append("來調整音量");

            sbPlayList.AppendLine("拖曳音樂或影像檔案")
                .AppendLine("即可新增至播放清單")
                .AppendLine("若要刪除，請左鍵選擇後")
                .AppendLine("按下鍵盤上的 Delete 即可")
                .AppendLine("Save List 可儲存播放清單")
                .AppendLine("儲存格式為 *.mikupl")
                .AppendLine("可使用 Load List 載入")
                .Append("或直接拖曳 *.mikupl 檔案");
        }

        private void setMainHelpVisible(bool visible)
        {
            pbPlayList.Visible = pbReplay.Visible = pbRandom.Visible = pbPlayer.Visible
                = labelPlayList.Visible = labelReplay.Visible = labelRandom.Visible = labelPlayer.Visible
                = visible;
        }

        public void applyMainHelp()
        {
            setMainHelpVisible(true);
            labelHelpContent.Text = sbMain.ToString();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void HelpForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UIHandler.ReleaseCapture();
                UIHandler.SendMessage(Handle, UIHandler.WM_NCLBUTTONDOWN, UIHandler.HT_CAPTION, 0);
            }
        }

        public void applyPlayListHelp()
        {
            setMainHelpVisible(false);
            labelHelpContent.Text = sbPlayList.ToString();
        }
    }
}
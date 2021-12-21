using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public partial class WMPlayerForm : PlayerForm, IMessageFilter
    {
        private const int WM_KEYDOWN = 0x0100;

        public WMPlayerForm()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message message)
        {
            if (message.Msg == WM_KEYDOWN)
            {
                Keys keyCode = (Keys)message.WParam & Keys.KeyCode;
                if (keyCode == Keys.Escape && wmp.fullScreen)
                {
                    wmp.fullScreen = false;
                    return true;
                }
            }
            return false;
        }
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public partial class SpectrumForm : Form
    {
        private readonly Analyzer analyzer;

        public SpectrumForm()
        {
            InitializeComponent();
            UIHandler.registerHoverEvent(pbClose);
            analyzer = new Analyzer(barLeft, barRight, spectrum, cbDeviceList);
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            analyzer.enable = true;
            analyzer.displayEnable = true;

            Size = new Size(504, 155);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void SpectrumForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UIHandler.ReleaseCapture();
                UIHandler.SendMessage(Handle, UIHandler.WM_NCLBUTTONDOWN, UIHandler.HT_CAPTION, 0);
            }
        }
    }
}
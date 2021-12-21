using System.Drawing;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public class EditHandler
    {
        private Point mouseOffset;

        public void mouseDownEvent(object sender, MouseEventArgs e)
        {
            if (Program.settingManager.editable)
            {
                mouseOffset = new Point(e.X, e.Y);
            }
        }

        public void mouseMoveEditEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Program.settingManager.editable)
            {
                Control target = sender as Control;
                target.Left += e.X - mouseOffset.X;
                target.Top += e.Y - mouseOffset.Y;
            }
        }
    }
}
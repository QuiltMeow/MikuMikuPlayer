using System;
using System.Drawing;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public class TransparentListBox : ListBox
    {
        public TransparentListBox()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            Invalidate();
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Focused && SelectedItem != null)
            {
                Rectangle itemRectangle = GetItemRectangle(SelectedIndex);
                e.Graphics.FillRectangle(Brushes.LightBlue, itemRectangle);
            }
            for (int i = 0; i < Items.Count; ++i)
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(GetItemText(Items[i]), Font, new SolidBrush(ForeColor), GetItemRectangle(i), stringFormat);
            }
            base.OnPaint(e);
        }
    }
}
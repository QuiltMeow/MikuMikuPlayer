using System;
using System.Windows.Forms;

namespace MikuMikuPlayer
{
    public class TransperentHandler
    {
        private const int TRANSPERENT_INTERVAL = 1500;
        private const double TRANSPERENT_PERCENT = 0.8;

        public bool inControl
        {
            get;
            private set;
        }

        private readonly Timer timerOpacity;
        private readonly Form form;

        public bool enable
        {
            get;
            set;
        }

        public TransperentHandler(Form form)
        {
            this.form = form;
            registerControlMouseEnterEvent();

            timerOpacity = new Timer()
            {
                Interval = TRANSPERENT_INTERVAL
            };
            timerOpacity.Tick += new EventHandler(opacityTickEvent);
            enable = true;
        }

        public void transperent(double opacity)
        {
            if (opacity < 0 || opacity > 1)
            {
                return;
            }
            form.Opacity = opacity;
        }

        private void registerControlMouseEnterEvent()
        {
            form.MouseEnter += new EventHandler(mouseEnterEvent);
            form.MouseLeave += new EventHandler(formMouseLeaveEvent);

            foreach (Control control in form.Controls)
            {
                control.MouseEnter += new EventHandler(mouseEnterEvent);
                control.MouseLeave += new EventHandler(controlMouseLeaveEvent);
            }
        }

        public void registerControlMouseEnterEvent(Control control)
        {
            control.MouseEnter += new EventHandler(mouseEnterEvent);
            control.MouseLeave += new EventHandler(controlMouseLeaveEvent);
        }

        private void opacityTickEvent(object sender, EventArgs e)
        {
            if (!enable)
            {
                transperentDisable();
                return;
            }

            if (inControl)
            {
                return;
            }
            transperent(TRANSPERENT_PERCENT);
            timerOpacity.Stop();
        }

        private void mouseEnterEvent(object sender, EventArgs e)
        {
            if (!enable)
            {
                transperentDisable();
                return;
            }

            if (!(sender is Form))
            {
                inControl = true;
            }
            transperent(1);
            timerOpacity.Stop();
        }

        private void controlMouseLeaveEvent(object sender, EventArgs e)
        {
            if (!enable)
            {
                transperentDisable();
                return;
            }
            inControl = false;
            timerOpacity.Start();
        }

        private void formMouseLeaveEvent(object sender, EventArgs e)
        {
            if (!enable)
            {
                transperentDisable();
                return;
            }
            timerOpacity.Start();
        }

        private void transperentDisable()
        {
            inControl = false;
            transperent(1);
            timerOpacity.Stop();
        }
    }
}
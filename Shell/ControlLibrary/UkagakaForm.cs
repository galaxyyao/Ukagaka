using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Shell
{
    public class UkagakaForm : Form
    {
        public UkagakaForm()
            : base()
        {
            ShowInTaskbar = false;
            TopMost = true;
            WindowState = FormWindowState.Maximized;
        }

        protected void ChangeWindowState()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //MyNotifyIcon.BalloonTipTitle = "Minimize Sucessful";
                //MyNotifyIcon.BalloonTipText = "Minimized the app ";
                //MyNotifyIcon.ShowBalloonTip(400);
                this.WindowState = FormWindowState.Maximized;
                Show();
            }
            else if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
                Hide();
            }
        }
    }
}

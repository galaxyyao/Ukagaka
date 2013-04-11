using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Shell
{
    public class UkagakaMenu : Label
    {
        public UkagakaMenu()
        {
            BackColor = Color.Orange;
            ForeColor = Color.White;
            Font = new Font("Arial", 12);
            Width = 150;
            Cursor = Cursors.Hand;
            MouseEnter += new EventHandler(UkagakaMenu_MouseEnter);
            MouseLeave += new EventHandler(UkagakaMenu_MouseLeave);
        }

        void UkagakaMenu_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.Orange;
        }

        void UkagakaMenu_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.Yellow;
        }
    }
}

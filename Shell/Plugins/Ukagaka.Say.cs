using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Shell
{
    public partial class Ukagaka
    {
        public void SakuraSay(string text)
        {
            dialogPanelSakura.Controls.Clear();
            dialogPanelSakura.Show();

            UkagakaLabel lblSay = new UkagakaLabel();
            lblSay.Width = 250;
            lblSay.Text = text;

            UkagakaMenu returnMenu = new UkagakaMenu();
            returnMenu.Text = "返回主菜单";

            dialogPanelSakura.Controls.Add(lblSay);
            dialogPanelSakura.Controls.Add(returnMenu);
        }

        public void KeroSay(string text)
        {
            Label lbl3 = new Label();
            lbl3.Text = "ccc";
            lbl3.ForeColor = Color.Red;

            Label lbl4 = new Label();
            lbl4.Text = "ddd";
            lbl4.ForeColor = Color.Red;
            dialogPanelKero.Controls.Add(lbl4);
        }
    }
}

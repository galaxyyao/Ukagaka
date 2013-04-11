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
        public void SakuraSay()
        {
            dialogPanelSakura.Controls.Clear();

        }

        public void KeroSay()
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

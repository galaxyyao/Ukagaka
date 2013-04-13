using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AppSettings;

namespace Shell
{
    public class UkagakaListBox:ListBox
    {
        public UkagakaListBox()
        {
            Settings settings = Settings.Instance;
            Font = new Font("Arial", settings.Shell_DialogPanelFontSize);
            BackColor = ColorTranslator.FromHtml("#EEEEEE");
            ForeColor = ColorTranslator.FromHtml("#111111");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AppSettings;

namespace Shell
{
    public class UkagakaLabel : Label
    {
        public UkagakaLabel()
        {
            Settings settings = Settings.Instance;
            if (!string.IsNullOrEmpty(settings.Shell_LabelBackColor))
                BackColor = ColorTranslator.FromHtml(settings.Shell_LabelBackColor);
            if (!string.IsNullOrEmpty(settings.Shell_LabelForeColor))
                ForeColor = ColorTranslator.FromHtml(settings.Shell_LabelForeColor);
            Font = new Font("Arial", settings.Shell_DialogPanelFontSize);
        }
    }
}

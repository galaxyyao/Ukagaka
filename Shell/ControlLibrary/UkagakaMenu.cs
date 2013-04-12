using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AppSettings;

namespace Shell
{
    public class UkagakaMenu : Label
    {
        public UkagakaMenu()
        {
            Settings settings = Settings.Instance;
            if (!string.IsNullOrEmpty(settings.Shell_ButtonBackColor))
                BackColor = ColorTranslator.FromHtml(settings.Shell_ButtonBackColor);
            if (!string.IsNullOrEmpty(settings.Shell_ButtonForeColor))
                ForeColor = ColorTranslator.FromHtml(settings.Shell_ButtonForeColor);
            Font = new Font("Arial", settings.Shell_DialogPanelFontSize);
            Width = 150;
            Cursor = Cursors.Hand;
            MouseEnter += new EventHandler(UkagakaMenu_MouseEnter);
            MouseLeave += new EventHandler(UkagakaMenu_MouseLeave);
        }

        void UkagakaMenu_MouseLeave(object sender, EventArgs e)
        {
            Settings settings = Settings.Instance;
            if (!string.IsNullOrEmpty(settings.Shell_ButtonBackColor))
                BackColor = ColorTranslator.FromHtml(settings.Shell_ButtonBackColor);
            if (!string.IsNullOrEmpty(settings.Shell_ButtonForeColor))
                ForeColor = ColorTranslator.FromHtml(settings.Shell_ButtonForeColor);
        }

        void UkagakaMenu_MouseEnter(object sender, EventArgs e)
        {
            Settings settings = Settings.Instance;
            if (!string.IsNullOrEmpty(settings.Shell_ButtonMouseEnterBackColor))
                BackColor = ColorTranslator.FromHtml(settings.Shell_ButtonMouseEnterBackColor);
            if (!string.IsNullOrEmpty(settings.Shell_ButtonMouseEnterForeColor))
                ForeColor = ColorTranslator.FromHtml(settings.Shell_ButtonMouseEnterForeColor);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AppSettings;

using System.Windows.Forms.VisualStyles;

namespace Shell
{
    public class UkagakaComboBox : ComboBox
    {
        public UkagakaComboBox()
        {
            Settings settings = Settings.Instance;
            Font = new Font("Arial", settings.Shell_DialogPanelFontSize);
            BackColor = ColorTranslator.FromHtml("#EEEEEE");
            ForeColor = ColorTranslator.FromHtml("#111111");
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public ComboBoxItem()
        {
        }

        public ComboBoxItem(string text, object value)
        {
            Text = text;
            Value = value;
        }
    }
}

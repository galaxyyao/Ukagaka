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
        public void LoadMainMenu()
        {
            dialogPanelSakura.Controls.Clear();
            dialogPanelSakura.Show();


            if (AppSettings.Settings.Instance.Service_IsRedmineEnabled)
            {
                MainMenu_AddRedmineMenuItems();
            }

            UkagakaLabel blank2 = new UkagakaLabel();
            blank2.Text = string.Empty;
            dialogPanelSakura.Controls.Add(blank2);

            UkagakaMenu settingMenu = new UkagakaMenu();
            settingMenu.Text = "设置";
            settingMenu.Click += new EventHandler(settingMenu_Click);
            UkagakaMenu exitMenu = new UkagakaMenu();
            exitMenu.Text = "退出";
            exitMenu.Click += new EventHandler(ExitMenu_Click);

            dialogPanelSakura.Controls.Add(settingMenu);
            dialogPanelSakura.Controls.Add(exitMenu);
        }

        void settingMenu_Click(object sender, EventArgs e)
        {
            LoadMenu(MenuEnum.Settings);
        }
    }
}

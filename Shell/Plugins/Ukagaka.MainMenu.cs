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

            UkagakaLabel lblWelcome = new UkagakaLabel();
            lblWelcome.Text = "嗯？叫我？";
            lblWelcome.Width = 250;
            dialogPanelSakura.Controls.Add(lblWelcome);

            if (AppSettings.Settings.Instance.Service_IsRedmineEnabled)
            {
                MainMenu_AddRedmineMenuItems();
            }


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

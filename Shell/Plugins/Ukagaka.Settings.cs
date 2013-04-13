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
        private UkagakaMenu _settings_redmineMenu;

        public void LoadSettingMenu()
        {
            ClearMenu();

            _settings_redmineMenu = new UkagakaMenu();
            _settings_redmineMenu.Text = "Redmine设置";
            _settings_redmineMenu.Click += new EventHandler(_settings_redmineMenu_Click);

            dialogPanelSakura.Controls.Add(_settings_redmineMenu);

            AddReturnMenuItem();
        }

        void _settings_redmineMenu_Click(object sender, EventArgs e)
        {
            LoadSettingRedmineMenu();
        }

        private void LoadSettingRedmineMenu()
        {
            ClearMenu();

            UkagakaLabel lblGuide1 = new UkagakaLabel();
            lblGuide1.Text = "修改你的Api Key:";
            lblGuide1.Width = 280;

            _mainMenu_txtApiKey = new UkagakaTextBox();
            _mainMenu_txtApiKey.Text = AppSettings.Settings.Instance.Redmine_ApiKey;
            _mainMenu_txtApiKey.Width = AppSettings.Settings.Instance.Shell_SakuraDialogPanelWidth - 30;
            _mainMenu_confirmMenu = new UkagakaMenu();
            _mainMenu_confirmMenu.Text = "确定";
            _mainMenu_confirmMenu.Click += new EventHandler(_settings_redmine_confirmMenu_Click);

            dialogPanelSakura.Controls.Add(lblGuide1);
            dialogPanelSakura.Controls.Add(_mainMenu_txtApiKey);
            dialogPanelSakura.Controls.Add(_mainMenu_confirmMenu);

            UkagakaLabel blank1 = new UkagakaLabel();
            blank1.Text = string.Empty;
            dialogPanelSakura.Controls.Add(blank1);

            AddReturnMenuItem();
        }

        void _settings_redmine_confirmMenu_Click(object sender, EventArgs e)
        {
            AppSettings.Settings.Instance.Redmine_SetApiKey(_mainMenu_txtApiKey.Text);
            LoadIssueCountInfo();
            LoadMenu(MenuEnum.MainMenu);
        }
    }
}

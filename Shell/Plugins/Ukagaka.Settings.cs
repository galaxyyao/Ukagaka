using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace Shell
{
    public partial class Ukagaka
    {
        private UkagakaMenu _settings_redmineMenu;
        private UkagakaCheckBox _settings_chboxIsStartWhenWindowsStartup;
        private UkagakaCheckBox _settings_chboxIsFloaterShown;

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
            

            _settings_chboxIsStartWhenWindowsStartup = new UkagakaCheckBox();
            _settings_chboxIsStartWhenWindowsStartup.Text = "是否开机启动";
            _settings_chboxIsStartWhenWindowsStartup.Checked = AppSettings.Settings.Instance.Redmine_IsStartWhenWindowsStartup;
            _settings_chboxIsStartWhenWindowsStartup.Width = 150;
            dialogPanelSakura.Controls.Add(_settings_chboxIsStartWhenWindowsStartup);

            _settings_chboxIsFloaterShown = new UkagakaCheckBox();
            _settings_chboxIsFloaterShown.Text = "是否显示浮动窗口";
            _settings_chboxIsFloaterShown.Checked = AppSettings.Settings.Instance.Redmine_IsFloaterShown;
            _settings_chboxIsFloaterShown.Width = 150;
            dialogPanelSakura.Controls.Add(_settings_chboxIsFloaterShown);

            UkagakaLabel blank1 = new UkagakaLabel();
            blank1.Text = string.Empty;
            dialogPanelSakura.Controls.Add(blank1);
            dialogPanelSakura.Controls.Add(_mainMenu_confirmMenu);

            UkagakaLabel blank2 = new UkagakaLabel();
            blank2.Text = string.Empty;
            dialogPanelSakura.Controls.Add(blank2);

            AddReturnMenuItem();
        }

        void _settings_redmine_confirmMenu_Click(object sender, EventArgs e)
        {
            AppSettings.Settings.Instance.Redmine_SetApiKey(_mainMenu_txtApiKey.Text);
            UpdateIssueInfo();

            string registryKeyValue = "Ukagaka";
            if (_settings_chboxIsStartWhenWindowsStartup.Checked != AppSettings.Settings.Instance.Redmine_IsStartWhenWindowsStartup)
            {
                if (_settings_chboxIsStartWhenWindowsStartup.Checked)
                {
                    try
                    {
                        RegistryKey run = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                        run.SetValue(registryKeyValue, Application.ExecutablePath, RegistryValueKind.String);
                        run.Close();
                    }
                    catch { }
                }
                else
                {
                    RegistryKey run = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    if (run.GetValue(registryKeyValue) != null)
                        run.DeleteValue(registryKeyValue);
                    run.Close();
                }
                AppSettings.Settings.Instance.Redmine_SetIsStartWhenWindowsStartup(_settings_chboxIsStartWhenWindowsStartup.Checked);
            }

            if (_settings_chboxIsFloaterShown.Checked != AppSettings.Settings.Instance.Redmine_IsFloaterShown)
            {
                if (_settings_chboxIsFloaterShown.Checked)
                {
                    _floater.Show();
                }
                else
                {
                    _floater.Hide();
                }
                AppSettings.Settings.Instance.Redmine_SetIsFloaterShown(_settings_chboxIsFloaterShown.Checked);
            }

            LoadMenu(MenuEnum.MainMenu);
        }
    }
}

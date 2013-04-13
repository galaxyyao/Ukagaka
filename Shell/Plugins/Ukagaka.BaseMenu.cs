using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shell
{
    public partial class Ukagaka
    {
        private Dictionary<MenuEnum, Action> _loadMenuActionlookups = new Dictionary<MenuEnum, Action>();
        private MenuEnum _lastMenu;
        private MenuEnum _currentMenu;

        public enum MenuEnum
        {
            MainMenu, Redmine, Settings, Settings_Redmine
        }

        public void InitializeMenuTable()
        {
            _loadMenuActionlookups.Add(MenuEnum.MainMenu, LoadMainMenu);
            _loadMenuActionlookups.Add(MenuEnum.Settings, LoadSettingMenu);
            _loadMenuActionlookups.Add(MenuEnum.Settings_Redmine, LoadSettingRedmineMenu);
        }

        public void LoadMenu(MenuEnum menu)
        {
            _lastMenu = _currentMenu;
            Action loadMenuAction;
            if (_loadMenuActionlookups.TryGetValue(menu, out loadMenuAction))
            {
                loadMenuAction();
                _currentMenu = menu;
            }
            else
            {
                throw new NotImplementedException("The method for {0} has not been implemented.");
            }
        }

        private void ClearMenu()
        {
            dialogPanelSakura.Controls.Clear();
            dialogPanelSakura.Show();
        }

        private void AddReturnMenuItem()
        {
            UkagakaMenu returnMenu = new UkagakaMenu();
            returnMenu.Text = "返回";
            returnMenu.Click += new EventHandler(returnMenu_Click);
            UkagakaMenu returnToMainMenu = new UkagakaMenu();
            returnToMainMenu.Text = "返回主菜单";
            returnToMainMenu.Click += new EventHandler(returnToMainMenu_Click);
            dialogPanelSakura.Controls.Add(returnMenu);
            dialogPanelSakura.Controls.Add(returnToMainMenu);
        }

        void returnMenu_Click(object sender, EventArgs e)
        {
            LoadMenu(_lastMenu);
        }

        void returnToMainMenu_Click(object sender, EventArgs e)
        {
            LoadMenu(MenuEnum.MainMenu);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shell
{
    public partial class Ukagaka
    {

        private Dictionary<MenuEnum, Action<MenuEnum>> _loadMenuActionlookups = new Dictionary<MenuEnum, Action<MenuEnum>>();

        public enum MenuEnum
        {
            MainMenu, Redmine, Settings
        }

        public void InitializeMenuTable()
        {
            //m_outboxActionloopups.Add(Interactions.BaseInteraction.PlayerAction.Pass, ProcessRespondPass);
        }

        public void LoadMenu(MenuEnum menu)
        {
            Action<MenuEnum> loadMenuAction;
            if (_loadMenuActionlookups.TryGetValue(menu, out loadMenuAction))
            {
                loadMenuAction(menu);
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
            throw new NotImplementedException();
        }

        void returnToMainMenu_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

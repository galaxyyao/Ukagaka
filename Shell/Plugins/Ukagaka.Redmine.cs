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
        private enum RedmineFilterEnum
        {
            Urgent, RelativeUrgent, OverDue, AssignedByMe, AllMine
        }

        private RedmineFilterEnum _redmine_currentFilter;

        public void LoadRedmineMainMenu()
        {
            ClearMenu();

            UkagakaMenu visitMyRedminePageMenu = new UkagakaMenu();
            visitMyRedminePageMenu.Text = "访问我的任务页";
            UkagakaLabel blank1 = new UkagakaLabel();
            blank1.Text = string.Empty;
            UkagakaMenu viewUrgentTaskMenu = new UkagakaMenu();
            viewUrgentTaskMenu.Text = "查看紧急的任务";
            UkagakaMenu viewRelativeUrgentTaskMenu = new UkagakaMenu();
            viewRelativeUrgentTaskMenu.Text = "查看较紧急的任务";
            UkagakaMenu viewOverDueTaskMenu = new UkagakaMenu();
            viewOverDueTaskMenu.Text = "查看已超期的任务";
            UkagakaMenu viewAssignedByMeTaskMenu = new UkagakaMenu();
            viewAssignedByMeTaskMenu.Text = "查看我分派的任务";
            UkagakaMenu viewAllTaskMenu = new UkagakaMenu();
            viewAllTaskMenu.Text = "查看我所有的任务";

            visitMyRedminePageMenu.Click += new EventHandler(visitMyRedminePageMenu_Click);
            viewUrgentTaskMenu.Click += new EventHandler(viewUrgentTaskMenu_Click);
            viewRelativeUrgentTaskMenu.Click += new EventHandler(viewRelativeUrgentTaskMenu_Click);
            viewOverDueTaskMenu.Click += new EventHandler(viewOverDueTaskMenu_Click);
            viewAssignedByMeTaskMenu.Click += new EventHandler(viewAssignedByMeTaskMenu_Click);
            viewAllTaskMenu.Click += new EventHandler(viewAllTaskMenu_Click);

            dialogPanelSakura.Controls.Add(visitMyRedminePageMenu);
            dialogPanelSakura.Controls.Add(blank1);
            dialogPanelSakura.Controls.Add(viewUrgentTaskMenu);
            dialogPanelSakura.Controls.Add(viewRelativeUrgentTaskMenu);
            dialogPanelSakura.Controls.Add(viewOverDueTaskMenu);
            dialogPanelSakura.Controls.Add(viewAssignedByMeTaskMenu);
            dialogPanelSakura.Controls.Add(viewAllTaskMenu);

            UkagakaLabel blank2 = new UkagakaLabel();
            blank2.Text = string.Empty;
            dialogPanelSakura.Controls.Add(blank2);

            AddReturnMenuItem();
        }

        void viewAllTaskMenu_Click(object sender, EventArgs e)
        {
            _redmine_currentFilter = RedmineFilterEnum.AllMine;
            LoadMenu(MenuEnum.Redmine_Detail);
        }

        void viewAssignedByMeTaskMenu_Click(object sender, EventArgs e)
        {
            _redmine_currentFilter = RedmineFilterEnum.AssignedByMe;
            LoadMenu(MenuEnum.Redmine_Detail);
        }

        void viewOverDueTaskMenu_Click(object sender, EventArgs e)
        {
            _redmine_currentFilter = RedmineFilterEnum.OverDue;
            LoadMenu(MenuEnum.Redmine_Detail);
        }

        void viewRelativeUrgentTaskMenu_Click(object sender, EventArgs e)
        {
            _redmine_currentFilter = RedmineFilterEnum.RelativeUrgent;
            LoadMenu(MenuEnum.Redmine_Detail);
        }

        void viewUrgentTaskMenu_Click(object sender, EventArgs e)
        {
            _redmine_currentFilter = RedmineFilterEnum.Urgent;
            LoadMenu(MenuEnum.Redmine_Detail);
        }

        void visitMyRedminePageMenu_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://p.honestwalker.com/issues?assigned_to_id=me");
        }

        public void LoadRedmineDetailMenu()
        {
            ClearMenu();

            AddReturnMenuItem();
        }
    }
}

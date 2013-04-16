using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AppSettings;
using Ghost;
using Redmine.Net.Api.Types;
using Common;

namespace Shell
{
    public partial class Ukagaka
    {
        private enum RedmineFilterEnum
        {
            Urgent, RelativeUrgent, OverDue, AllMine
        }

        private RedmineFilterEnum _redmine_currentFilter;

        private UkagakaListBox _redmine_taskResultList;

        private UkagakaComboBox _redmine_TaskFilter1;
        private UkagakaComboBox _redmine_TaskFilter2;

        private List<Issue> _redmine_filteredIssue;

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
            UkagakaMenu viewAllTaskMenu = new UkagakaMenu();
            viewAllTaskMenu.Text = "查看我所有的任务";

            visitMyRedminePageMenu.Click += new EventHandler(visitMyRedminePageMenu_Click);
            viewUrgentTaskMenu.Click += new EventHandler(viewUrgentTaskMenu_Click);
            viewRelativeUrgentTaskMenu.Click += new EventHandler(viewRelativeUrgentTaskMenu_Click);
            viewOverDueTaskMenu.Click += new EventHandler(viewOverDueTaskMenu_Click);
            viewAllTaskMenu.Click += new EventHandler(viewAllTaskMenu_Click);

            dialogPanelSakura.Controls.Add(visitMyRedminePageMenu);
            dialogPanelSakura.Controls.Add(blank1);
            dialogPanelSakura.Controls.Add(viewUrgentTaskMenu);
            dialogPanelSakura.Controls.Add(viewRelativeUrgentTaskMenu);
            dialogPanelSakura.Controls.Add(viewOverDueTaskMenu);
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
            Settings settings = Settings.Instance;

            _redmine_TaskFilter1 = new UkagakaComboBox();
            _redmine_TaskFilter1.Width = 200;
            ComboBoxItem filter1Item1 = new ComboBoxItem("待完成（大类）", -1);
            ComboBoxItem filter1Item2 = new ComboBoxItem("待关闭（大类）", -2);
            ComboBoxItem filter1Item3 = new ComboBoxItem("新任务", 1);
            ComboBoxItem filter1Item4 = new ComboBoxItem("处理中", 2);
            ComboBoxItem filter1Item5 = new ComboBoxItem("已解决", 3);
            ComboBoxItem filter1Item6 = new ComboBoxItem("用户反馈", 4);
            ComboBoxItem filter1Item7 = new ComboBoxItem("不处理的任务", 6);
            ComboBoxItem filter1Item8 = new ComboBoxItem("不会修复的Bug", 7);
            _redmine_TaskFilter1.Items.Add(filter1Item1);
            _redmine_TaskFilter1.Items.Add(filter1Item2);
            _redmine_TaskFilter1.Items.Add(filter1Item3);
            _redmine_TaskFilter1.Items.Add(filter1Item4);
            _redmine_TaskFilter1.Items.Add(filter1Item5);
            _redmine_TaskFilter1.Items.Add(filter1Item6);
            _redmine_TaskFilter1.Items.Add(filter1Item7);
            _redmine_TaskFilter1.Items.Add(filter1Item8);
            dialogPanelSakura.Controls.Add(_redmine_TaskFilter1);

            _redmine_TaskFilter2 = new UkagakaComboBox();
            _redmine_TaskFilter2.Width = 200;
            ComboBoxItem filter2Item1 = new ComboBoxItem("按更新时间", 1);
            ComboBoxItem filter2Item2 = new ComboBoxItem("紧急", 2);
            ComboBoxItem filter2Item3 = new ComboBoxItem("较紧急", 3);
            ComboBoxItem filter2Item4 = new ComboBoxItem("已超期", 4);
            ComboBoxItem filter2Item5 = new ComboBoxItem("高优先度", 5);
            ComboBoxItem filter2Item6 = new ComboBoxItem("低优先度", 6);
            _redmine_TaskFilter2.Items.Add(filter2Item1);
            _redmine_TaskFilter2.Items.Add(filter2Item2);
            _redmine_TaskFilter2.Items.Add(filter2Item3);
            _redmine_TaskFilter2.Items.Add(filter2Item4);
            _redmine_TaskFilter2.Items.Add(filter2Item5);
            _redmine_TaskFilter2.Items.Add(filter2Item6);
            dialogPanelSakura.Controls.Add(_redmine_TaskFilter2);

            _redmine_taskResultList = new UkagakaListBox();
            _redmine_taskResultList.Width = settings.Shell_SakuraDialogPanelWidth - 30;
            _redmine_taskResultList.Height = settings.Shell_SakuraDialogPanelHeight - 140;
            dialogPanelSakura.Controls.Add(_redmine_taskResultList);

            AddReturnMenuItem();

            switch (_redmine_currentFilter)
            {
                case RedmineFilterEnum.AllMine:
                    _redmine_TaskFilter1.SelectedIndex = 0;
                    _redmine_TaskFilter2.SelectedIndex = 0;
                    break;
                case RedmineFilterEnum.OverDue:
                    _redmine_TaskFilter1.SelectedIndex = 0;
                    _redmine_TaskFilter2.SelectedIndex = 4;
                    break;
                case RedmineFilterEnum.Urgent:
                    _redmine_TaskFilter1.SelectedIndex = 0;
                    _redmine_TaskFilter2.SelectedIndex = 2;
                    break;
                case RedmineFilterEnum.RelativeUrgent:
                    _redmine_TaskFilter1.SelectedIndex = 0;
                    _redmine_TaskFilter2.SelectedIndex = 3;
                    break;
                default:
                    _redmine_TaskFilter1.SelectedIndex = 0;
                    _redmine_TaskFilter2.SelectedIndex = 0;
                    break;
            }

            _redmine_TaskFilter1.SelectedValueChanged += new EventHandler(redmineTaskFilter_SelectedValueChanged);
            _redmine_TaskFilter2.SelectedValueChanged += new EventHandler(redmineTaskFilter_SelectedValueChanged);
            RefreshRedmineDetailMenu();
        }

        void redmineTaskFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshRedmineDetailMenu();
        }

        private void RefreshRedmineDetailMenu()
        {
            _redmine_taskResultList.Items.Clear();
            _redmine_filteredIssue = Ghost.Ghost.Instance.RedmineService.CurrentResult.MyIssues;

            switch (Convert.ToInt32(_redmine_TaskFilter1.SelectedIndex))
            {
                case 0:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where (issue.Status.Name == "New" || issue.Status.Name == "Progress" || issue.Status.Name == "Feedback")
                                              select issue).ToList();
                    break;
                case 1:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where (issue.Status.Name == "Resolved" || issue.Status.Name == "Rejected" || issue.Status.Name == "Wont Fix")
                                              select issue).ToList();
                    break;
                case 2:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where (issue.Status.Name == "New")
                                              select issue).ToList();
                    break;
                case 3:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where (issue.Status.Name == "Progress")
                                              select issue).ToList();
                    break;
                case 4:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where (issue.Status.Name == "Resolved")
                                              select issue).ToList();
                    break;
                case 5:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where (issue.Status.Name == "Feedback")
                                              select issue).ToList();
                    break;
                case 6:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where (issue.Status.Name == "Rejected")
                                              select issue).ToList();
                    break;
                case 7:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where (issue.Status.Name == "Wont Fix")
                                              select issue).ToList();
                    break;
                default:
                    break;
            }

            switch (Convert.ToInt32(_redmine_TaskFilter2.SelectedIndex))
            {
                case 0:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              select issue).OrderBy(issue => issue.DueDate).ToList();
                    break;
                case 1:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where issue.DueDate!=null && 
                                              (ExtDate.GetBusinessDays(DateTime.Today, (DateTime)issue.DueDate) <= 1
                                              && ExtDate.GetBusinessDays(DateTime.Today, (DateTime)issue.DueDate) >= 0)
                                              select issue).ToList();
                    break;
                case 2:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where issue.DueDate != null && 
                                              (ExtDate.GetBusinessDays(DateTime.Today, (DateTime)issue.DueDate) <= 3
                                              && ExtDate.GetBusinessDays(DateTime.Today, (DateTime)issue.DueDate) > 1)
                                              select issue).ToList();
                    break;
                case 3:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where issue.DueDate != null && 
                                              (ExtDate.GetBusinessDays(DateTime.Today, (DateTime)issue.DueDate) < 0)
                                              select issue).ToList();
                    break;
                case 4:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where (issue.Priority.Name == "High" || issue.Priority.Name == "Urgent" || issue.Priority.Name == "Immediate")
                                              select issue).ToList();
                    break;
                case 5:
                    _redmine_filteredIssue = (from issue in _redmine_filteredIssue
                                              where (issue.Priority.Name == "Low")
                                              select issue).ToList();
                    break;
                default:
                    break;
            }

            foreach (var issue in _redmine_filteredIssue)
            {
                _redmine_taskResultList.Items.Add(issue.Subject);
            }
            _redmine_taskResultList.MouseDoubleClick += new MouseEventHandler(_redmine_taskResultList_MouseDoubleClick);
        }

        void _redmine_taskResultList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = _redmine_taskResultList.IndexFromPoint(e.Location);
            var issue = _redmine_filteredIssue[_redmine_taskResultList.IndexFromPoint(e.Location)];
            System.Diagnostics.Process.Start(string.Format("http://p.honestwalker.com/issues/{0}", issue.Id));
        }
    }
}

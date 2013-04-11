using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Redmine;
using System.Threading;
using System.Diagnostics;

namespace Shell
{
    public partial class Ukagaka
    {
        private CheckResult _checkResult;
        public UkagakaLabel _lblOpenIssue;

        private void MainMenu_AddRedmineMenuItems()
        {
            _lblOpenIssue = new UkagakaLabel();
            _lblOpenIssue.Text = "-";
            _lblOpenIssue.Width = 250;
            _lblOpenIssue.Cursor = Cursors.Hand;
            _lblOpenIssue.Click += new EventHandler(_lblOpenIssue_Click);
            _lblOpenIssue.MouseEnter += new EventHandler(_lblOpenIssue_MouseEnter);
            _lblOpenIssue.MouseLeave += new EventHandler(_lblOpenIssue_MouseLeave);
            LoadOpenIssueNumber();

            UkagakaMenu redmineMenu = new UkagakaMenu();
            redmineMenu.Text = "当前任务";

            dialogPanelSakura.Controls.Add(_lblOpenIssue);
            dialogPanelSakura.Controls.Add(redmineMenu);
        }

        void _lblOpenIssue_MouseLeave(object sender, EventArgs e)
        {
            _lblOpenIssue.ForeColor = Color.White;
        }

        void _lblOpenIssue_MouseEnter(object sender, EventArgs e)
        {
            _lblOpenIssue.ForeColor = Color.Red;
        }

        void _lblOpenIssue_Click(object sender, EventArgs e)
        {
            //Process.Start("http://p.honestwalker.com/issues?assigned_to_id=me");
            Process.Start("http://p.honestwalker.com/issues?set_filter=1&f[]=assigned_to_id&op[assigned_to_id]==&v[assigned_to_id][]=me&f[]=status_id&op[status_id]==&v[status_id][]=1&v[status_id][]=2&v[status_id][]=4");
        }

        private void LoadOpenIssueNumber()
        {
            Thread issueThread = new Thread(new ThreadStart(
                () =>
                {
                    MyIssuesChecker checker = new MyIssuesChecker();
                    _checkResult = checker.Check();
                    UpdateOpenIssueCount(_checkResult.OpenedCount, _checkResult.IsCloseToDueDate);
                }
            ));
            issueThread.Start();
        }

        private void UpdateOpenIssueCount(int openIssueCount, bool isCloseToDueDate)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<int, bool>(UpdateOpenIssueCount), openIssueCount, isCloseToDueDate);
            }
            else
            {
                _lblOpenIssue.Text = string.Format("待完成的任务：{0}", openIssueCount.ToString());
                _lblOpenIssue.BackColor = isCloseToDueDate ? Color.Red : Color.Green;
            }
        }
    }
}

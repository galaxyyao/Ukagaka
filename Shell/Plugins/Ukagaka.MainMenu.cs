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


        public void LoadMainMenu()
        {
            dialogPanelSakura.Show();

            UkagakaLabel lblWelcome = new UkagakaLabel();
            lblWelcome.Text = "有什么我可以帮到你的吗？";
            lblWelcome.Width = 250;

            _lblOpenIssue = new UkagakaLabel();
            _lblOpenIssue.Text = "-";
            _lblOpenIssue.Width = 250;
            _lblOpenIssue.Cursor = Cursors.Hand;
            _lblOpenIssue.Click += new EventHandler(_lblOpenIssue_Click);
            _lblOpenIssue.MouseEnter += new EventHandler(_lblOpenIssue_MouseEnter);
            _lblOpenIssue.MouseLeave += new EventHandler(_lblOpenIssue_MouseLeave);
            LoadOpenIssueNumber();

            UkagakaMenu redmineMenu = new UkagakaMenu();
            redmineMenu.Text = "Redmine任务详情";

            UkagakaMenu exitMenu = new UkagakaMenu();
            exitMenu.Text = "告别";

            dialogPanelSakura.Controls.Add(lblWelcome);
            dialogPanelSakura.Controls.Add(_lblOpenIssue);
            dialogPanelSakura.Controls.Add(redmineMenu);
            dialogPanelSakura.Controls.Add(exitMenu);
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
            Process.Start("http://p.honestwalker.com/issues?assigned_to_id=me");
        }

        private void LoadOpenIssueNumber()
        {
            Thread issueThread = new Thread(new ThreadStart(
                () =>
                {
                    MyIssuesChecker checker = new MyIssuesChecker();
                    _checkResult = checker.Check();
                    UpdateOpenIssueCount(_checkResult.OpenedCount);
                }
            ));
            issueThread.Start();
        }

        private void UpdateOpenIssueCount(int openIssueCount)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<int>(UpdateOpenIssueCount), openIssueCount);
            }
            else
            {
                _lblOpenIssue.Text = string.Format("待完成的任务：{0}", openIssueCount.ToString());
            }
        }
    }
}

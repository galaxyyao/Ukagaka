using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Redmine;
using System.Threading;
using System.Diagnostics;
using AppSettings;

namespace Shell
{
    public partial class Ukagaka
    {
        private CheckResult _checkResult;
        public UkagakaLabel _lblOpenIssue;
        public UkagakaLabel _lblToCloseIssue;

        private UkagakaTextBox _mainMenu_txtApiKey;
        private UkagakaMenu _mainMenu_confirmMenu;

        private void MainMenu_AddRedmineMenuItems()
        {
            _lblOpenIssue = new UkagakaLabel();
            _lblOpenIssue.Text = "待完成的任务：-";
            _lblOpenIssue.Width = 300;
            _lblOpenIssue.Cursor = Cursors.Hand;
            _lblOpenIssue.Click += new EventHandler(_lblOpenIssue_Click);
            _lblOpenIssue.MouseEnter += new EventHandler(_lblOpenIssue_MouseEnter);
            _lblOpenIssue.MouseLeave += new EventHandler(_lblOpenIssue_MouseLeave);

            _lblToCloseIssue = new UkagakaLabel();
            _lblToCloseIssue.Text = "待完成的任务：-";
            _lblToCloseIssue.Width = 300;
            _lblToCloseIssue.Cursor = Cursors.Hand;
            _lblToCloseIssue.Click += new EventHandler(_lblToCloseIssue_Click);
            _lblToCloseIssue.MouseEnter += new EventHandler(_lblToCloseIssue_MouseEnter);
            _lblToCloseIssue.MouseLeave += new EventHandler(_lblToCloseIssue_MouseLeave);

            Settings.Instance.Redmine_ReadSettings();
            if (string.IsNullOrEmpty(Settings.Instance.Redmine_ApiKey))
            {
                PopupApiKeyDialog();
            }
            else
            {
                LoadIssueCountInfo();
            }

            UkagakaLabel blank1 = new UkagakaLabel();
            blank1.Text = string.Empty;
            UkagakaMenu redmineMenu = new UkagakaMenu();
            redmineMenu.Text = "当前任务";

            dialogPanelSakura.Controls.Add(_lblOpenIssue);
            dialogPanelSakura.Controls.Add(_lblToCloseIssue);
            dialogPanelSakura.Controls.Add(blank1);
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

        void _lblToCloseIssue_MouseLeave(object sender, EventArgs e)
        {
            _lblToCloseIssue.ForeColor = Color.White;
        }

        void _lblToCloseIssue_MouseEnter(object sender, EventArgs e)
        {
            _lblToCloseIssue.ForeColor = Color.Red;
        }

        void _lblOpenIssue_Click(object sender, EventArgs e)
        {
            //Process.Start("http://p.honestwalker.com/issues?assigned_to_id=me");
            Process.Start("http://p.honestwalker.com/issues?set_filter=1&f[]=assigned_to_id&op[assigned_to_id]==&v[assigned_to_id][]=me&f[]=status_id&op[status_id]==&v[status_id][]=1&v[status_id][]=2&v[status_id][]=4");
        }

        void _lblToCloseIssue_Click(object sender, EventArgs e)
        {
            Process.Start("http://p.honestwalker.com/issues?set_filter=1&f[]=assigned_to_id&op[assigned_to_id]==&v[assigned_to_id][]=me&f[]=status_id&op[status_id]==&v[status_id][]=3&v[status_id][]=6&v[status_id][]=7");
        }

        private void PopupApiKeyDialog()
        {
            popupPanel1.RowStyles.Clear();
            popupPanel1.ColumnCount = 1;
            popupPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            popupPanel1.RowCount = 2;
            popupPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            popupPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            popupPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            popupPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            popupPanel1.Location = new System.Drawing.Point(ClientSize.Width / 3, ClientSize.Height / 3);
            popupPanel1.Size = new Size(300, 200);
            popupPanel1.Padding = new Padding(10, 10, 10, 10);
            popupPanel1.BackColor = System.Drawing.ColorTranslator.FromHtml(Settings.Instance.Shell_DialogPanelBackColor);

            UkagakaLabel lblGuide1 = new UkagakaLabel();
            lblGuide1.Text = "请输入你的Api Key:";
            lblGuide1.Width = 280;
            lblGuide1.Height = 20;
            UkagakaLabel lblGuide2 = new UkagakaLabel();
            lblGuide2.Text = "（你可以在 http://p.honestwalker.com/my/account 页面右侧的API access key中，点击Show，显示Api Key）";
            lblGuide2.AutoSize = false;
            lblGuide2.Width = 280;
            lblGuide2.Height = 100;
            _mainMenu_txtApiKey = new UkagakaTextBox();
            _mainMenu_txtApiKey.Text = "(在此黏贴复制的Api Key）";
            _mainMenu_txtApiKey.Width = 280;
            _mainMenu_txtApiKey.Click += new EventHandler(txtApiKey_Click);
            _mainMenu_confirmMenu = new UkagakaMenu();
            _mainMenu_confirmMenu.Text = "确定";
            _mainMenu_confirmMenu.Click += new EventHandler(_mainMenu_confirmMenu_Click);

            popupPanel1.Controls.Add(lblGuide1, 0, 0);
            popupPanel1.Controls.Add(lblGuide2, 0, 1);
            popupPanel1.Controls.Add(_mainMenu_txtApiKey, 0, 2);
            popupPanel1.Controls.Add(_mainMenu_confirmMenu, 0, 3);
            popupPanel1.Show();
        }

        void _mainMenu_confirmMenu_Click(object sender, EventArgs e)
        {
            AppSettings.Settings.Instance.Redmine_SetApiKey(_mainMenu_txtApiKey.Text);
            popupPanel1.Controls.Clear();
            popupPanel1.Hide();
            LoadIssueCountInfo();
        }

        void txtApiKey_Click(object sender, EventArgs e)
        {
            _mainMenu_txtApiKey.Text = string.Empty;
        }

        private void LoadIssueCountInfo()
        {
            Thread issueThread = new Thread(new ThreadStart(
                () =>
                {
                    MyIssuesChecker checker = new MyIssuesChecker();
                    _checkResult = checker.Check();
                    UpdateIssueCount(_checkResult);
                }
            ));
            issueThread.Start();
        }

        public void UpdateIssueCount(CheckResult result)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<CheckResult>(UpdateIssueCount), result);
            }
            else
            {
                _lblOpenIssue.Text = string.Format("待完成的任务：{0}", result.OpenIssueCount);
                if (result.NearestDue == -1 || result.NearestDue > 3)
                    _lblOpenIssue.BackColor = Color.Green;
                else if (result.NearestDue >= 1)
                    _lblOpenIssue.BackColor = Color.Yellow;
                else if (result.NearestDue >= 0)
                    _lblOpenIssue.BackColor = Color.Orange;
                else
                    _lblOpenIssue.BackColor = Color.Red;

                _lblToCloseIssue.Text = string.Format("待关闭的任务：{0}", result.ToCloseIssueCount);
                _lblToCloseIssue.BackColor = Color.Green;
            }
        }
    }
}

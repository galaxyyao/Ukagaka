using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Diagnostics;

namespace Shell
{
    public partial class Floater : Form
    {
        public Floater()
        {
            InitializeComponent();
        }

        private void Floater_Load(object sender, EventArgs e)
        {
            var rec = Screen.PrimaryScreen.Bounds;
            this.Top = rec.Top;
            if (AppSettings.Settings.Instance.Redmine_FloaterLeft >= 0)
            {
                this.Left = AppSettings.Settings.Instance.Redmine_FloaterLeft;
            }
            else
            {
                this.Left = (rec.Width - this.Width) / 2;
            }
            this.TopMost = true;
            StartScheduledUpdate();
            lblOpen.Click += new EventHandler(lblOpen_Click);
            lblToClose.Click += new EventHandler(lblToClose_Click);
        }

        void lblToClose_Click(object sender, EventArgs e)
        {
            Process.Start("http://p.honestwalker.com/issues?set_filter=1&f[]=assigned_to_id&op[assigned_to_id]==&v[assigned_to_id][]=me&f[]=status_id&op[status_id]==&v[status_id][]=3&v[status_id][]=6&v[status_id][]=7");
        }

        void lblOpen_Click(object sender, EventArgs e)
        {
            Process.Start("http://p.honestwalker.com/issues?set_filter=1&f[]=assigned_to_id&op[assigned_to_id]==&v[assigned_to_id][]=me&f[]=status_id&op[status_id]==&v[status_id][]=1&v[status_id][]=2&v[status_id][]=4");
        }

        private void Floater_Resize(object sender, EventArgs e)
        {
            this.lblOpen.Width = this.lblToClose.Width = this.ClientSize.Width / 2;
        }

        private System.Timers.Timer _timer;
        private int _updateInterval = 1000 * 5;

        private void StartScheduledUpdate()
        {
            _timer = new System.Timers.Timer(_updateInterval);//Update UI every half minute
            _timer.Elapsed += _timer_Elapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!string.IsNullOrEmpty(AppSettings.Settings.Instance.Redmine_ApiKey))
            {
                UpdateIssueInfo();
            }  
        }

        public void UpdateIssueInfo()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(
                    () => UpdateIssueInfo()));
                return;
            }

            Ghost.Redmine.CheckResult result = Ghost.Ghost.Instance.RedmineService.CurrentResult;

            lblOpen.Text = result.OpenIssueCount.ToString();
            lblToClose.Text = result.OpenIssueCount.ToString();
            lblOpen.BackColor = (result.NearestDue < 2) ? Color.Red : Color.Orange;
            _updateInterval = 1000 * 30;
        }
    }
}

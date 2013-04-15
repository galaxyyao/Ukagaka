using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using AppSettings;
using System.Threading;
using Common;

namespace Ghost
{
    public partial class Redmine
    {
        RedmineManager _manager;
        public CheckResult CurrentResult
        {
            get;
            private set;
        }

        public bool IsSync
        {
            get;
            private set;
        }

        private NameValueCollection paraAssignedToMe = new NameValueCollection { 
            { "assigned_to_id", "me" }, 
            { "status_id", "open" },
            { "limit", "100"}
            };

        public Redmine()
        {
            Settings settings = Settings.Instance;
            _manager = new RedmineManager(settings.Redmine_Host, settings.Redmine_ApiKey);
            CurrentResult = new CheckResult();
            Thread redmineThread = new Thread(new ThreadStart(
                () => UpdateIssue()
                    ));
            redmineThread.Start();

            IsSync = false;
        }

        public void UpdateIssue()
        {
            while (!ExtPing.GetPingHostResult("p.honestwalker.com"))
            {
                Thread.Sleep(1000);
            }
            var issues = _manager.GetObjectList<Issue>(paraAssignedToMe);
            CurrentResult.MyIssues = issues.ToList();
            IsSync = true;
            StartScheduledUpdate();
        }

        private System.Timers.Timer _timer;

        private void StartScheduledUpdate()
        {
            _timer = new System.Timers.Timer(Settings.Instance.Redmine_CheckIssueIntervalMilliSeconds);
            _timer.Elapsed += _timer_Elapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateIssue();
        }
    }
}

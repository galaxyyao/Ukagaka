using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using AppSettings;
using Common;

namespace Redmine
{
    public class MyIssuesChecker
    {
        RedmineManager _manager;

        private NameValueCollection paraAssignedToMe = new NameValueCollection { 
            { "assigned_to_id", "me" }, 
            { "status_id", "open" },
            {"limit", "200"}
            };

        public MyIssuesChecker()
        {
            Settings settings = Settings.Instance;
            _manager = new RedmineManager(settings.Redmine_Host, settings.Redmine_ApiKey);
        }


        public CheckResult Check()
        {
            var issues = _manager.GetObjectList<Issue>(paraAssignedToMe);

            CheckResult result = new CheckResult();

            int openedCount = 0;
            int resolvedCount = 0;
            int nearestDue = 100;

            foreach (var issue in issues)
            {
                string statusName = issue.Status.Name;
                if (statusName == "Resolved" || statusName == "Rejected" || statusName == "Wont Fix")
                {
                    resolvedCount++;
                }
                else if (statusName == "New" || statusName == "In Progress" || statusName == "Feedback")
                {
                    openedCount++;
                    if (issue.DueDate == null)
                        continue;
                    if ((DateTime)(issue.DueDate) < DateTime.Today)
                        result.NearestDue = Convert.ToInt32(((DateTime)(issue.DueDate) - DateTime.Today).TotalDays);
                    else if (ExtDate.GetBusinessDays(DateTime.Today, (DateTime)(issue.DueDate)) < nearestDue)
                        result.NearestDue = ExtDate.GetBusinessDays(DateTime.Today, (DateTime)(issue.DueDate));
                }
            }
            result.ToCloseIssueCount = resolvedCount;
            result.OpenIssueCount = openedCount;

            return result;
        }
    }
}

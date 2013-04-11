using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using AppSettings;

namespace Redmine
{
    public class MyIssuesChecker
    {
        RedmineManager _manager;

        private NameValueCollection paraAssignedToMe = new NameValueCollection { 
            { "assigned_to_id", "me" }, 
            { "status_id", "open" } 
            };

        public MyIssuesChecker()
        {
            Settings settings = Settings.Instance;
            settings.Redmine_ReadSettings();
            _manager = new RedmineManager(settings.Redmine_Host, settings.Redmine_ApiKey);
        }


        public CheckResult Check()
        {
            var issues = _manager.GetObjectList<Issue>(paraAssignedToMe);

            CheckResult result = new CheckResult();

            int openedCount = 0;
            int resolvedCount = 0;

            foreach (var issue in issues)
            {
                string statusName = issue.Status.Name;
                if (statusName == "Resolved" || statusName == "Rejected" || statusName == "Wont Fix")
                {
                    resolvedCount++;
                }
                else if (statusName == "New" || statusName == "In Progress" || statusName == "Feedback")
                {
                    if (!result.IsCloseToDueDate && issue.DueDate != null)
                    {
                        if (((DateTime)(issue.DueDate) - DateTime.Today).TotalDays <= 1)
                        {
                            result.IsCloseToDueDate = true;
                        }
                    }
                    openedCount++;
                }
            }
            result.ResolvedCount = resolvedCount;
            result.OpenedCount = openedCount;

            return result;
        }
    }
}

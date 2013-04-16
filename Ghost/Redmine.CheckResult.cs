using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Common;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;

namespace Ghost
{
    public partial class Redmine
    {
        public class CheckResult
        {
            /// <summary>
            /// Returns count of 'Resovled' issues.
            /// </summary>
            public int OpenIssueCount
            {
                get
                {
                    if (MyIssues != null)
                    {
                        return (from issue in MyIssues
                                where (issue.Status.Name == "New" || issue.Status.Name == "In Progress" || issue.Status.Name == "Feedback")
                                select issue).Count();
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            /// <summary>
            /// Returns count of all working issues, that is, status is 'New' or 'In Progress' or 'Feedback'
            /// </summary>
            public int ToCloseIssueCount
            {
                get
                {
                    if (MyIssues != null)
                    {
                        return (from issue in MyIssues
                                where (issue.Status.Name == "Resolved" || issue.Status.Name == "Rejected" || issue.Status.Name == "Wont Fix")
                                select issue).Count();
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            /// <summary>
            /// Specify if there is any opened issue is close to the due date.
            /// </summary>
            public int NearestDue
            {
                get
                {
                    if (MyIssues != null)
                    {
                        Issue nearestIssue = (from issue in MyIssues
                                              where (issue.Status.Name == "New" || issue.Status.Name == "In Progress" || issue.Status.Name == "Feedback")
                                                   select issue).OrderBy(issue => issue.DueDate).FirstOrDefault();
                        if (nearestIssue == null)
                            return 100;
                        if (nearestIssue.DueDate == null)
                            return 100;
                        else
                            return ExtDate.GetBusinessDays(DateTime.Today, (DateTime)nearestIssue.DueDate);
                    }
                    else
                    {
                        return 100;// A temp big value
                    }
                }
            }

            public int TodayUpdatedOpenCount
            {
                get
                {
                    if (MyIssues != null)
                    {
                        var todayUpdatedIssues = (from issue in MyIssues
                                              where (issue.UpdatedOn.Value.Date==DateTime.Today.Date)
                                              && (issue.Status.Name == "New" || issue.Status.Name == "In Progress" || issue.Status.Name == "Feedback")
                                              select issue);
                        if (todayUpdatedIssues == null)
                            return 0;
                        return todayUpdatedIssues.Count();
                    }
                    else
                    {
                        return 0;// A temp big value
                    }
                }
            }

            public int TodayUpdatedToCloseCount
            {
                get
                {
                    if (MyIssues != null)
                    {
                        var todayUpdatedIssues = (from issue in MyIssues
                                                  where (issue.UpdatedOn == DateTime.Today)
                                                  && (issue.Status.Name == "Resolved" || issue.Status.Name == "Rejected" || issue.Status.Name == "Wont Fix")
                                                  select issue);
                        if (todayUpdatedIssues == null)
                            return 0;
                        return todayUpdatedIssues.Count();
                    }
                    else
                    {
                        return 0;// A temp big value
                    }
                }
            }

            public List<Issue> MyIssues
            {
                get;
                internal set;
            }
        }
    }
}

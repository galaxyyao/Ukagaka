using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redmine
{
    public class CheckResult
    {
        /// <summary>
        /// Returns count of 'Resovled' issues.
        /// </summary>
        public int ResolvedCount
        {
            get;
            set;
        }

        /// <summary>
        /// Returns count of all working issues, that is, status is 'New' or 'In Progress' or 'Feedback'
        /// </summary>
        public int OpenedCount
        {
            get;
            set;
        }

        /// <summary>
        /// Specify if there is any opened issue is close to the due date.
        /// </summary>
        public bool IsCloseToDueDate
        {
            get;
            set;
        }
    }
}

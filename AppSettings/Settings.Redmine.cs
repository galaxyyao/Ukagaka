using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSettings
{
    public partial class Settings
    {
        public string Host
        {
            get;
            internal set;
        }

        public string ApiKey
        {
            get;
            internal set;
        }

        public int CheckIssueInterval
        {
            get;
            internal set;
        }

        public void InitializeRedmineSettings()
        {
            Host = "p.honestwalker.com";
            ApiKey = "4b6f7b8daca67249e19b074d290bd9835e160bfb";
            CheckIssueInterval = 1000 * 60 * 10;
        }

        public void SaveSettings()
        {

        }
    }
}

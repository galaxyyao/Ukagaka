using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using Common;

namespace AppSettings
{
    public partial class Settings
    {
        private const string _redmineProfilePath = @"Configs/Plugins/Redmine.xml";
        private XDocument _redmineProfile;

        public string Redmine_Host
        {
            get;
            internal set;
        }

        public string Redmine_ApiKey
        {
            get;
            internal set;
        }

        public int Redmine_CheckIssueIntervalMinutes
        {
            get;
            internal set;
        }

        public void Redmine_ReadSettings()
        {
            _redmineProfile = XDocument.Load(_redmineProfilePath);


            Redmine_Host = XML.GetFirstDescendantsValue<string>(_redmineProfile, "Host");
            Redmine_ApiKey = XML.GetFirstDescendantsValue<string>(_redmineProfile, "ApiKey");
            Redmine_CheckIssueIntervalMinutes = 1000 * 60 * XML.GetFirstDescendantsValue<int>(_redmineProfile, "CheckIssueIntervalMinutes"); ;
        }
    }
}

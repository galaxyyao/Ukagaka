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

        public int Redmine_CheckIssueIntervalMilliSeconds
        {
            get;
            internal set;
        }

        public bool Redmine_IsStartWhenWindowsStartup
        {
            get;
            internal set;
        }

        public void Redmine_ReadSettings()
        {
            _redmineProfile = XDocument.Load(_redmineProfilePath);


            Redmine_Host = ExtXML.GetFirstDescendantsValue<string>(_redmineProfile, "Host");
            Redmine_ApiKey = ExtXML.GetFirstDescendantsValue<string>(_redmineProfile, "ApiKey");
            Redmine_CheckIssueIntervalMilliSeconds = 1000 * 60 * ExtXML.GetFirstDescendantsValue<int>(_redmineProfile, "CheckIssueIntervalMinutes");
            Redmine_IsStartWhenWindowsStartup = ExtXML.GetFirstDescendantsValue<Boolean>(_redmineProfile, "IsStartWhenWindowsStartup");
        }

        public void Redmine_SetApiKey(string apiKey)
        {
            Redmine_ApiKey = apiKey;
            _redmineProfile.Root.Element("ApiKey").Value = apiKey;
            _redmineProfile.Save(_redmineProfilePath);
        }

        public void Redmine_SetIsStartWhenWindowsStartup(bool isStartWhenWindowsStartup)
        {
            Redmine_IsStartWhenWindowsStartup = isStartWhenWindowsStartup;
            _redmineProfile.Root.Element("IsStartWhenWindowsStartup").Value = isStartWhenWindowsStartup.ToString();
            _redmineProfile.Save(_redmineProfilePath);
        }
    }
}

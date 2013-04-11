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
        private static Settings m_instance;
        private const string _profilePath = @"Configs/Profile.xml";
        private XDocument _shellProfile;

        public static Settings Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new Settings();
                }
                return m_instance;
            }
        }

        public string Shell_IconPath
        {
            get;
            private set;
        }

        private Settings()
        {
            _shellProfile = XDocument.Load(_profilePath);
            ReadSettings();
        }

        private void ReadSettings()
        {
            Shell_IconPath = XML.GetFirstDescendantsValue<string>(_shellProfile, "IconPath");
        }
    }
}

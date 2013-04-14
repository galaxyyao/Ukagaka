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
        private const string _serviceConfigsPath = @"Configs/Services.xml";
        private XDocument _serviceConfigs;

        public bool Service_IsRedmineEnabled
        {
            get;
            private set;
        }

        private void LoadServices()
        {
            _serviceConfigs = XDocument.Load(_serviceConfigsPath);
            List<XElement> serviceConfigs = _serviceConfigs.Root.Elements("Service").ToList();

            XElement redmineServiceConfig = (from el in serviceConfigs
                                   where (string)el.Element("Name")=="Redmine"
                                   select el).FirstOrDefault();
            Service_IsRedmineEnabled = ExtXML.GetFirstDescendantsValue<bool>(redmineServiceConfig, "IsEnabled");
        }
    }
}

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

        private Settings()
        {
            LoadServices();
            Shell_ReadSettings();
        }  
    }
}

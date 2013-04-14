using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppSettings;

namespace Ghost
{
    public class Ghost
    {
        private static Ghost m_instance;

        public static Ghost Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new Ghost();
                }
                return m_instance;
            }
        }

        private Ghost()
        {
            LoadServices();
        }

        public Redmine RedmineService
        {
            get;
            private set;
        }

        public void LoadServices()
        {
            if (Settings.Instance.Service_IsRedmineEnabled)
            {
                RedmineService = new Redmine();
            }
        }
    }
}

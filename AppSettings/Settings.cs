using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        }
    }
}

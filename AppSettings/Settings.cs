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

        public bool IsRedmineEnabled
        {
            get;
            private set;
        }

        public int Shell_SakuraLocationX
        {
            get;
            set;
        }

        public int Shell_SakuraLocationY
        {
            get;
            set;
        }

        public int Shell_SakuraDialogPanelLocationX
        {
            get;
            set;
        }

        public int Shell_SakuraDialogPanelLocationY
        {
            get;
            set;
        }

        public int Shell_KeroLocationX
        {
            get;
            set;
        }

        public int Shell_KeroLocationY
        {
            get;
            set;
        }

        public int Shell_KeroDialogPanelLocationX
        {
            get;
            set;
        }

        public int Shell_KeroDialogPanelLocationY
        {
            get;
            set;
        }

        public string Shell_DialogPanelBackColor
        {
            get;
            set;
        }

        private Settings()
        {
            _shellProfile = XDocument.Load(_profilePath);
            Shell_ReadSettings();
        }

        private void Shell_ReadSettings()
        {
            _controlNameDictionary.Add(ControlEnum.Sakura, "Sakura");
            _controlNameDictionary.Add(ControlEnum.SakuraDialogPanel, "SakuraDialogPanel");
            _controlNameDictionary.Add(ControlEnum.Kero, "Kero");
            _controlNameDictionary.Add(ControlEnum.KeroDialogPanel, "KeroDialogPanel");

            Shell_IconPath = XML.GetFirstDescendantsValue<string>(_shellProfile, "IconPath");
            IsRedmineEnabled = XML.GetFirstDescendantsValue<bool>(_shellProfile, "IsRedmineEnabled");

            Shell_SakuraLocationX = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Sakura]), "LastLocationX");
            Shell_SakuraLocationY = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Sakura]), "LastLocationY");

            Shell_SakuraDialogPanelLocationX = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.SakuraDialogPanel]), "LastLocationX");
            Shell_SakuraDialogPanelLocationY = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.SakuraDialogPanel]), "LastLocationY");

            Shell_KeroLocationX = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Kero]), "LastLocationX");
            Shell_KeroLocationY = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Kero]), "LastLocationY");

            Shell_KeroDialogPanelLocationX = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.KeroDialogPanel]), "LastLocationX");
            Shell_KeroDialogPanelLocationY = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.KeroDialogPanel]), "LastLocationY");

            Shell_DialogPanelBackColor = XML.GetFirstDescendantsValue<string>(
                _shellProfile.Root.Element("DialogPanel"), "BackColor");
        }

        public enum ControlEnum
        {
            Sakura, SakuraDialogPanel, Kero, KeroDialogPanel
        }
        private Dictionary<ControlEnum, string> _controlNameDictionary = new Dictionary<ControlEnum, string>();

        public void Shell_WriteLocationSettings(ControlEnum control, int x, int y)
        {
            XElement ele = _shellProfile.Root.Element(_controlNameDictionary[control]);
            XElement eleX = ele.Element("LastLocationX");
            eleX.Value = x.ToString();
            XElement eleY = ele.Element("LastLocationY");
            eleY.Value = y.ToString();
        }

        public void Shell_SaveSettings()
        {
            _shellProfile.Save(_profilePath, SaveOptions.None);
        }
    }
}

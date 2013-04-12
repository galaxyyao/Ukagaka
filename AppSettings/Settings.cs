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

        #region Location Properties
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
        #endregion

        #region Size Properties
        public int Shell_SakuraWidth
        {
            get;
            set;
        }

        public int Shell_SakuraHeight
        {
            get;
            set;
        }

        public int Shell_SakuraDialogPanelWidth
        {
            get;
            set;
        }

        public int Shell_SakuraDialogPanelHeight
        {
            get;
            set;
        }

        public int Shell_KeroWidth
        {
            get;
            set;
        }

        public int Shell_KeroHeight
        {
            get;
            set;
        }

        public int Shell_KeroDialogPanelWidth
        {
            get;
            set;
        }

        public int Shell_KeroDialogPanelHeight
        {
            get;
            set;
        }
        #endregion


        #region Panel Appearance Properties
        public string Shell_DialogPanelBackColor
        {
            get;
            set;
        }

        public int Shell_DialogPanelFontSize
        {
            get;
            set;
        }

        public string Shell_ButtonBackColor
        {
            get;
            set;
        }

        public string Shell_ButtonForeColor
        {
            get;
            set;
        }

        public string Shell_ButtonMouseEnterBackColor
        {
            get;
            set;
        }

        public string Shell_ButtonMouseEnterForeColor
        {
            get;
            set;
        }

        public string Shell_LabelBackColor
        {
            get;
            set;
        }

        public string Shell_LabelForeColor
        {
            get;
            set;
        }

        #endregion

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

            #region Location
            string elementName1 = "LastLocationX";
            string elementName2 = "LastLocationY";

            Shell_SakuraLocationX = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Sakura]), elementName1);
            Shell_SakuraLocationY = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Sakura]), elementName2);

            Shell_SakuraDialogPanelLocationX = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.SakuraDialogPanel]), elementName1);
            Shell_SakuraDialogPanelLocationY = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.SakuraDialogPanel]), elementName2);

            Shell_KeroLocationX = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Kero]), elementName1);
            Shell_KeroLocationY = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Kero]), elementName2);

            Shell_KeroDialogPanelLocationX = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.KeroDialogPanel]), elementName1);
            Shell_KeroDialogPanelLocationY = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.KeroDialogPanel]), elementName2);
            #endregion

            #region Size
            elementName1 = "Width";
            elementName2 = "Height";

            Shell_SakuraWidth = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Sakura]), elementName1);
            Shell_SakuraHeight = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Sakura]), elementName2);

            Shell_SakuraDialogPanelWidth = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.SakuraDialogPanel]), elementName1);
            Shell_SakuraDialogPanelHeight = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.SakuraDialogPanel]), elementName2);

            Shell_KeroWidth = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Kero]), elementName1);
            Shell_KeroHeight = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.Kero]), elementName2);

            Shell_KeroDialogPanelWidth = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.KeroDialogPanel]), elementName1);
            Shell_KeroDialogPanelHeight = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element(_controlNameDictionary[ControlEnum.KeroDialogPanel]), elementName2);
            #endregion

            #region Panel appearance
            Shell_DialogPanelBackColor = XML.GetFirstDescendantsValue<string>(
                _shellProfile.Root.Element("Appearance").Element("DialogPanel"), "BackColor");
            Shell_DialogPanelFontSize = XML.GetFirstDescendantsValue<int>(
                _shellProfile.Root.Element("Appearance").Element("DialogPanel"), "FontSize");
            Shell_ButtonBackColor = XML.GetFirstDescendantsValue<string>(
                _shellProfile.Root.Element("Appearance").Element("Button"), "BackColor");
            Shell_ButtonForeColor = XML.GetFirstDescendantsValue<string>(
                _shellProfile.Root.Element("Appearance").Element("Button"), "ForeColor");
            Shell_ButtonMouseEnterBackColor = XML.GetFirstDescendantsValue<string>(
                _shellProfile.Root.Element("Appearance").Element("Button"), "MouseEnterBackColor");
            Shell_ButtonMouseEnterForeColor = XML.GetFirstDescendantsValue<string>(
                _shellProfile.Root.Element("Appearance").Element("Button"), "MouseEnterForeColor");
            Shell_LabelBackColor = XML.GetFirstDescendantsValue<string>(
                _shellProfile.Root.Element("Appearance").Element("Label"), "BackColor");
            Shell_LabelForeColor = XML.GetFirstDescendantsValue<string>(
                _shellProfile.Root.Element("Appearance").Element("Label"), "ForeColor");
            #endregion
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

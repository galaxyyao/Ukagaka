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
        private const string _shellConfigsPath = @"Configs/Shell.xml";
        private XDocument _shellConfigs;

        public string Shell_IconPath
        {
            get;
            private set;
        }

        public string Shell_WindowsStateChangeShortcut
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

        private void Shell_ReadSettings()
        {
            _shellConfigs = XDocument.Load(_shellConfigsPath);

            _controlNameDictionary.Add(ControlEnum.Sakura, "Sakura");
            _controlNameDictionary.Add(ControlEnum.SakuraDialogPanel, "SakuraDialogPanel");
            _controlNameDictionary.Add(ControlEnum.Kero, "Kero");
            _controlNameDictionary.Add(ControlEnum.KeroDialogPanel, "KeroDialogPanel");

            Shell_IconPath = ExtXML.GetFirstDescendantsValue<string>(_shellConfigs, "IconPath");
            Shell_WindowsStateChangeShortcut = ExtXML.GetFirstDescendantsValue<string>(_shellConfigs, "WindowsStateChangeShortcut");

            #region Location
            string elementName1 = "LastLocationX";
            string elementName2 = "LastLocationY";

            Shell_SakuraLocationX = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.Sakura]), elementName1);
            Shell_SakuraLocationY = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.Sakura]), elementName2);

            Shell_SakuraDialogPanelLocationX = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.SakuraDialogPanel]), elementName1);
            Shell_SakuraDialogPanelLocationY = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.SakuraDialogPanel]), elementName2);

            Shell_KeroLocationX = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.Kero]), elementName1);
            Shell_KeroLocationY = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.Kero]), elementName2);

            Shell_KeroDialogPanelLocationX = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.KeroDialogPanel]), elementName1);
            Shell_KeroDialogPanelLocationY = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.KeroDialogPanel]), elementName2);
            #endregion

            #region Size
            elementName1 = "Width";
            elementName2 = "Height";

            Shell_SakuraWidth = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.Sakura]), elementName1);
            Shell_SakuraHeight = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.Sakura]), elementName2);

            Shell_SakuraDialogPanelWidth = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.SakuraDialogPanel]), elementName1);
            Shell_SakuraDialogPanelHeight = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.SakuraDialogPanel]), elementName2);

            Shell_KeroWidth = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.Kero]), elementName1);
            Shell_KeroHeight = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.Kero]), elementName2);

            Shell_KeroDialogPanelWidth = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.KeroDialogPanel]), elementName1);
            Shell_KeroDialogPanelHeight = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element(_controlNameDictionary[ControlEnum.KeroDialogPanel]), elementName2);
            #endregion

            #region Panel appearance
            Shell_DialogPanelBackColor = ExtXML.GetFirstDescendantsValue<string>(
                _shellConfigs.Root.Element("Appearance").Element("DialogPanel"), "BackColor");
            Shell_DialogPanelFontSize = ExtXML.GetFirstDescendantsValue<int>(
                _shellConfigs.Root.Element("Appearance").Element("DialogPanel"), "FontSize");
            Shell_ButtonBackColor = ExtXML.GetFirstDescendantsValue<string>(
                _shellConfigs.Root.Element("Appearance").Element("Button"), "BackColor");
            Shell_ButtonForeColor = ExtXML.GetFirstDescendantsValue<string>(
                _shellConfigs.Root.Element("Appearance").Element("Button"), "ForeColor");
            Shell_ButtonMouseEnterBackColor = ExtXML.GetFirstDescendantsValue<string>(
                _shellConfigs.Root.Element("Appearance").Element("Button"), "MouseEnterBackColor");
            Shell_ButtonMouseEnterForeColor = ExtXML.GetFirstDescendantsValue<string>(
                _shellConfigs.Root.Element("Appearance").Element("Button"), "MouseEnterForeColor");
            Shell_LabelBackColor = ExtXML.GetFirstDescendantsValue<string>(
                _shellConfigs.Root.Element("Appearance").Element("Label"), "BackColor");
            Shell_LabelForeColor = ExtXML.GetFirstDescendantsValue<string>(
                _shellConfigs.Root.Element("Appearance").Element("Label"), "ForeColor");
            #endregion
        }

        public enum ControlEnum
        {
            Sakura, SakuraDialogPanel, Kero, KeroDialogPanel
        }
        private Dictionary<ControlEnum, string> _controlNameDictionary = new Dictionary<ControlEnum, string>();

        public void Shell_WriteLocationSettings(ControlEnum control, int x, int y)
        {
            XElement ele = _shellConfigs.Root.Element(_controlNameDictionary[control]);
            XElement eleX = ele.Element("LastLocationX");
            eleX.Value = x.ToString();
            XElement eleY = ele.Element("LastLocationY");
            eleY.Value = y.ToString();
        }

        public void Shell_SaveSettings()
        {
            _shellConfigs.Save(_shellConfigsPath, SaveOptions.None);
        }
    }
}

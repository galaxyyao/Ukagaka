using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using AppSettings;
using Gma.UserActivityMonitor;

namespace Shell
{
    public partial class Ukagaka : UkagakaForm
    {
        private NotifyIcon _icon;
        private ContextMenu _contextMenu;

        private List<UkagakaForm> loadedForms = new List<UkagakaForm>();
        private Floater _floater;

        public Ukagaka()
        {
            InitializeComponent();
            InitializeNotifyIcon();
            InitializeContextMenu();
        }

        private void Shell_Load(object sender, EventArgs e)
        {
            SetBackgroundTransparent();
            InitializeControls();
            InitializeMenuTable();
            LoadMenu(MenuEnum.MainMenu);
            HookManager.KeyDown+=new KeyEventHandler(HookManager_KeyDown);

            //Floater

            _floater = new Floater();
            if (AppSettings.Settings.Instance.Redmine_IsFloaterShown)
                _floater.Show();
            else
                _floater.Hide();
            picSakura.Hide();
            picKero.Hide();
        }

        private void Shell_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppSettings.Settings.Instance.Shell_SaveSettings();
            _icon.Visible = false;
        }

        #region key hook

        private bool _shell_ctrlKeyDown = false;

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (_shell_ctrlKeyDown)
            {
                if (e.KeyCode.ToString() == AppSettings.Settings.Instance.Shell_WindowsStateChangeShortcut)
                {
                    ChangeWindowState();
                }
                _shell_ctrlKeyDown = false;
            }
            if (e.KeyCode.ToString() == "LControlKey" || e.KeyCode.ToString() == "RControlKey")
            {
                _shell_ctrlKeyDown = true;
            }
        }

        #endregion

        #region initialize shell 
        private void InitializeNotifyIcon()
        {
            _icon = new System.Windows.Forms.NotifyIcon();
            string iconPath = AppSettings.Settings.Instance.Shell_IconPath;
            _icon.Icon = new System.Drawing.Icon(iconPath);
            _icon.MouseDoubleClick +=
                new System.Windows.Forms.MouseEventHandler
                    (Icon_MouseDoubleClick);

            _icon.Visible = true;
        }

        private void InitializeContextMenu()
        {
            _contextMenu = new ContextMenu();
            _contextMenu.MenuItems.Add(0, new MenuItem("居中显示", new System.EventHandler(SetControlLocationToCenter_Click)));
            _contextMenu.MenuItems.Add(1, new MenuItem("退出", new System.EventHandler(ExitMenu_Click)));
            _icon.ContextMenu = _contextMenu;
        }

        private void SetBackgroundTransparent()
        {
            //let background be transparent
            SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.TransparencyKey = Color.Black;
            this.BackColor = Color.Black;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
            dragControl1.DesignMode(true);
        }

        private void InitializeControls()
        {
            Settings settings = Settings.Instance;
            //set default location
            picSakura.Location = new Point(settings.Shell_SakuraLocationX, settings.Shell_SakuraLocationY);
            picKero.Location = new Point(settings.Shell_KeroLocationX, settings.Shell_KeroLocationY);
            dialogPanelSakura.Location = new Point(settings.Shell_SakuraDialogPanelLocationX, settings.Shell_SakuraDialogPanelLocationY);
            dialogPanelKero.Location = new Point(settings.Shell_KeroDialogPanelLocationX, settings.Shell_KeroDialogPanelLocationY);

            //set size
            this.picSakura.Size = new Size(settings.Shell_SakuraWidth, settings.Shell_SakuraHeight);
            this.picKero.Size = new Size(settings.Shell_KeroWidth, settings.Shell_KeroHeight);
            this.dialogPanelSakura.Size = new Size(settings.Shell_SakuraDialogPanelWidth, settings.Shell_SakuraDialogPanelHeight);
            this.dialogPanelKero.Size = new Size(settings.Shell_KeroDialogPanelWidth, settings.Shell_KeroDialogPanelHeight);

            //set pic source
            this.picSakura.Image = Image.FromFile("Resources/Images/surface0000.png");
            this.picKero.Image = Image.FromFile("Resources/Images/surface1101.png");

            //set Dialog Panel
            dialogPanelSakura.BackColor = System.Drawing.ColorTranslator.FromHtml(settings.Shell_DialogPanelBackColor);
            dialogPanelKero.BackColor = System.Drawing.ColorTranslator.FromHtml(settings.Shell_DialogPanelBackColor);
            dialogPanelSakura.FlowDirection = FlowDirection.TopDown;
            dialogPanelKero.FlowDirection = FlowDirection.TopDown;
            dialogPanelSakura.Padding = new Padding(10, 10, 10, 10);
            dialogPanelKero.Padding = new Padding(10, 10, 10, 10);
            dialogPanelKero.Hide();
        }

        #endregion

        #region shell event handling

        private void Icon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ChangeWindowState();
        }

        //private void picSakura_Click(object sender, EventArgs e)
        //{
        //    dialogPanelSakura.Visible = (dialogPanelSakura.Visible == true) ? false : true;
        //}

        //private void picKero_Click(object sender, EventArgs e)
        //{
        //    dialogPanelKero.Visible = (dialogPanelKero.Visible == true) ? false : true;
        //}

        private void SetControlLocationToCenter_Click(object sender, EventArgs e)
        {
            SetControlLocationToCenter();
        }

        private void SetControlLocationToCenter()
        {
            picSakura.Location = new Point(ClientSize.Width / 2, ClientSize.Height / 2);
            picKero.Location = new Point(ClientSize.Width / 2 - 100, ClientSize.Height / 2 + 200);
            dialogPanelSakura.Location = new Point(ClientSize.Width / 2 - 250, ClientSize.Height / 2 - 50);
            dialogPanelKero.Location = new Point(ClientSize.Width / 2 - 300, ClientSize.Height / 2 + 200);
        }

        public void ExitMenu_Click(object sender, EventArgs e)
        {
            SakuraSay("下次再见~");
            Settings.Instance.Shell_WriteLocationSettings(Settings.ControlEnum.Sakura, picSakura.Location.X, picSakura.Location.Y);
            Settings.Instance.Shell_WriteLocationSettings(Settings.ControlEnum.SakuraDialogPanel, dialogPanelSakura.Location.X, dialogPanelSakura.Location.Y);
            Settings.Instance.Shell_WriteLocationSettings(Settings.ControlEnum.Kero, picKero.Location.X, picKero.Location.Y);
            Settings.Instance.Shell_WriteLocationSettings(Settings.ControlEnum.KeroDialogPanel, dialogPanelKero.Location.X, dialogPanelKero.Location.Y);
            Settings.Instance.Shell_SaveSettings();
            Close();
        }

        #endregion
    }
}

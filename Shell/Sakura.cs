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

namespace Shell
{
    public partial class Sakura : UkagakaForm
    {
        private NotifyIcon _icon;

        private List<UkagakaForm> loadedForms = new List<UkagakaForm>();

        public Sakura()
            : base()
        {
            InitializeComponent();
            InitializeNotifyIcon();

            //Thread menuThread = new Thread(
            //    () =>
            //    {
            //        Application.Run(new Redmine_Overall());
            //    }
            //);
            //menuThread.Start();
        }

        private void Shell_Load(object sender, EventArgs e)
        {
            //let background be transparent
            SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.TransparencyKey = Color.Black;
            this.BackColor = Color.Black;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            //set pic source
            this.picSakura.Image = global::Shell.Properties.Resources.surface0000;

            dragControl1.DesignMode(true);

        }

        private void InitializeNotifyIcon()
        {
            _icon = new System.Windows.Forms.NotifyIcon();
            _icon.Icon = new System.Drawing.Icon("kikka.ico");
            _icon.MouseDoubleClick +=
                new System.Windows.Forms.MouseEventHandler
                    (Icon_MouseDoubleClick);

            _icon.Visible = true;
        }

        void Icon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ChangeWindowState();
        }

        private void picSakura_DoubleClick(object sender, EventArgs e)
        {
            ChangeWindowState();
        }

        private void Shell_FormClosing(object sender, FormClosingEventArgs e)
        {
            _icon.Visible = false;
        }
    }
}

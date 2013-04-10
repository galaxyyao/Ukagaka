using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shell
{
    public partial class Kero : UkagakaForm
    {
        public Kero()
        {
            InitializeComponent();
        }

        private void picKero_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.picKero.Image = global::Shell.Properties.Resources.surface1101;
        }
    }
}

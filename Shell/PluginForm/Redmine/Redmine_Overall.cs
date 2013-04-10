using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Redmine;

namespace Shell
{
    public partial class Redmine_Overall : UkagakaForm
    {
        public Redmine_Overall()
        {
            InitializeComponent();

            MyIssuesChecker checker = new MyIssuesChecker();
            CheckResult result = checker.Check();
            lblOpenIssueCount.Text = result.OpenedCount.ToString();
        }
    }
}

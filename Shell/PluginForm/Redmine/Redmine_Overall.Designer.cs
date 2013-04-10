namespace Shell
{
    partial class Redmine_Overall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblOpenIssueCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOpenIssueCount
            // 
            this.lblOpenIssueCount.AutoSize = true;
            this.lblOpenIssueCount.Location = new System.Drawing.Point(63, 51);
            this.lblOpenIssueCount.Name = "lblOpenIssueCount";
            this.lblOpenIssueCount.Size = new System.Drawing.Size(13, 13);
            this.lblOpenIssueCount.TabIndex = 0;
            this.lblOpenIssueCount.Text = "0";
            // 
            // Redmine_Overall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblOpenIssueCount);
            this.Name = "Redmine_Overall";
            this.Text = "Redmine_Overall";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOpenIssueCount;
    }
}
namespace Shell
{
    partial class Floater
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
            this.components = new System.ComponentModel.Container();
            this.lblOpen = new System.Windows.Forms.Label();
            this.lblToClose = new System.Windows.Forms.Label();
            // 
            // lblOpen
            // 
            this.lblOpen.BackColor = System.Drawing.Color.Orange;
            this.lblOpen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOpen.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOpen.ForeColor = System.Drawing.Color.White;
            this.lblOpen.Location = new System.Drawing.Point(0, 0);
            this.lblOpen.Name = "lblOpen";
            this.lblOpen.Size = new System.Drawing.Size(50, 29);
            this.lblOpen.TabIndex = 0;
            this.lblOpen.Text = "-";
            this.lblOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblToClose
            // 
            this.lblToClose.BackColor = System.Drawing.Color.Lime;
            this.lblToClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblToClose.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblToClose.ForeColor = System.Drawing.Color.White;
            this.lblToClose.Location = new System.Drawing.Point(50, 0);
            this.lblToClose.Name = "lblToClose";
            this.lblToClose.Size = new System.Drawing.Size(50, 29);
            this.lblToClose.TabIndex = 1;
            this.lblToClose.Text = "-";
            this.lblToClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // Floater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(100, 29);
            this.ControlBox = false;
            this.Controls.Add(this.lblToClose);
            this.Controls.Add(this.lblOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Floater";
            this.Opacity = 0.6D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Floater_Load);
            this.Resize += new System.EventHandler(this.Floater_Resize);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblOpen;
        private System.Windows.Forms.Label lblToClose;
    }
}
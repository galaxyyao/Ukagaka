namespace Shell
{
    partial class Sakura
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
            this.picSakura = new System.Windows.Forms.PictureBox();
            this.dragControl1 = new ControlLibrary.DragControl();
            ((System.ComponentModel.ISupportInitialize)(this.picSakura)).BeginInit();
            this.SuspendLayout();
            // 
            // picSakura
            // 
            this.picSakura.Location = new System.Drawing.Point(173, 33);
            this.picSakura.Name = "picSakura";
            this.picSakura.Size = new System.Drawing.Size(300, 344);
            this.picSakura.TabIndex = 0;
            this.picSakura.TabStop = false;
            this.picSakura.DoubleClick += new System.EventHandler(this.picSakura_DoubleClick);

            // 
            // dragControl1
            // 
            this.dragControl1.Visible = false;
            this.dragControl1.DoubleClick += new System.EventHandler(this.picSakura_DoubleClick);
            // 
            // Sakura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.picSakura);
            this.Controls.Add(this.dragControl1);
            this.Name = "Sakura";
            this.Text = "Kikka";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Shell_FormClosing);
            this.Load += new System.EventHandler(this.Shell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSakura)).EndInit();
            this.ResumeLayout(false);     
        }

        #endregion

        private System.Windows.Forms.PictureBox picSakura;
        private ControlLibrary.DragControl dragControl1;
    }
}


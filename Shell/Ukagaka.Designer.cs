namespace Shell
{
    partial class Ukagaka
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
            this.dragControl1 = new Shell.DragControl();
            this.picKero = new System.Windows.Forms.PictureBox();
            this.dialogPanelSakura = new System.Windows.Forms.FlowLayoutPanel();
            this.dialogPanelKero = new System.Windows.Forms.FlowLayoutPanel();
            this.popupPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picSakura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKero)).BeginInit();
            this.SuspendLayout();
            // 
            // picSakura
            // 
            this.picSakura.Location = new System.Drawing.Point(0, 0);
            this.picSakura.Name = "picSakura";
            this.picSakura.Size = new System.Drawing.Size(100, 50);
            this.picSakura.TabIndex = 3;
            this.picSakura.TabStop = false;
            this.picSakura.Click += new System.EventHandler(this.picSakura_Click);
            // 
            // dragControl1
            // 
            this.dragControl1.Location = new System.Drawing.Point(0, 0);
            this.dragControl1.Name = "dragControl1";
            this.dragControl1.Size = new System.Drawing.Size(150, 150);
            this.dragControl1.TabIndex = 1;
            this.dragControl1.Visible = false;
            // 
            // picKero
            // 
            this.picKero.Location = new System.Drawing.Point(0, 0);
            this.picKero.Name = "picKero";
            this.picKero.Size = new System.Drawing.Size(100, 50);
            this.picKero.TabIndex = 2;
            this.picKero.TabStop = false;
            this.picKero.Click += new System.EventHandler(this.picKero_Click);
            // 
            // dialogPanelSakura
            // 
            this.dialogPanelSakura.Location = new System.Drawing.Point(0, 0);
            this.dialogPanelSakura.Name = "dialogPanelSakura";
            this.dialogPanelSakura.Size = new System.Drawing.Size(200, 100);
            this.dialogPanelSakura.TabIndex = 1;
            this.dialogPanelSakura.Click += new System.EventHandler(this.picSakura_Click);
            // 
            // dialogPanelKero
            // 
            this.dialogPanelKero.Location = new System.Drawing.Point(0, 0);
            this.dialogPanelKero.Name = "dialogPanelKero";
            this.dialogPanelKero.Size = new System.Drawing.Size(200, 100);
            this.dialogPanelKero.TabIndex = 0;
            this.dialogPanelKero.Click += new System.EventHandler(this.picKero_Click);
            // 
            // popupPanel1
            // 
            this.popupPanel1.Location = new System.Drawing.Point(200, 200);
            this.popupPanel1.Name = "popupPanel1";
            this.popupPanel1.Size = new System.Drawing.Size(200, 100);
            // 
            // Ukagaka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.popupPanel1);
            this.Controls.Add(this.dialogPanelKero);
            this.Controls.Add(this.dialogPanelSakura);
            this.Controls.Add(this.picKero);
            this.Controls.Add(this.picSakura);
            this.Controls.Add(this.dragControl1);
            this.Name = "Ukagaka";
            this.Text = "Kikka";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Shell_FormClosing);
            this.Load += new System.EventHandler(this.Shell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSakura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKero)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DragControl dragControl1;
        private System.Windows.Forms.PictureBox picSakura;
        private System.Windows.Forms.PictureBox picKero;
        private System.Windows.Forms.FlowLayoutPanel dialogPanelSakura;
        private System.Windows.Forms.FlowLayoutPanel dialogPanelKero;
        private System.Windows.Forms.TableLayoutPanel popupPanel1;
    }
}


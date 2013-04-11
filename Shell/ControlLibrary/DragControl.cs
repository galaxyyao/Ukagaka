using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Shell
{
    public partial class DragControl : UserControl
    {
        private Control mainForm = null;
        private Rectangle controlImage;
        private bool controlDragStarted = false;
        private Control controlUnderDrag = null;
        private Size mouseOffset;

        public DragControl()
        {
            InitializeComponent();
            mainForm = TopLevelControl;
            this.Hide();
        }

        private void SetEvent(Control ctrl, bool add)
        {
            if (add)
            {
                ctrl.MouseDown += new MouseEventHandler(ctrl_MouseDown);
            }
            else
            {
                ctrl.MouseDown -= new MouseEventHandler(ctrl_MouseDown);
            }
        }

        void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //find out which control is being dragged
                controlUnderDrag = mainForm.GetChildAtPoint(((Control)sender).Location + new Size(e.Location.X, e.Location.Y));
                if (controlUnderDrag != null)
                {
                    mainForm.Capture = true; //capture mouse
                    mainForm.Cursor = Cursors.Hand;

                    controlImage = new Rectangle(controlUnderDrag.Location, controlUnderDrag.Size);
                    mouseOffset = new Size(e.Location.X, e.Location.Y);

                    Rectangle tempRectangle = new Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4);
                    GraphicsPath myGraphicsPath = new GraphicsPath();
                    myGraphicsPath.AddRectangle(tempRectangle);
                    System.Drawing.Region rgn = new Region(myGraphicsPath);
                    mainForm.Invalidate(rgn);

                    controlDragStarted = true;
                }
            }
        }
        public void DesignMode(bool Enable)
        {
            mainForm = TopLevelControl;
            Control ctrl = mainForm.GetNextControl(null, true); //Get First Control
            do
            {
                if (ctrl.Text != "Design Mode" && ctrl.Text != "Control Mode")
                    SetEvent(ctrl, Enable);
                ctrl = mainForm.GetNextControl(ctrl, true);
            } while (ctrl != null);

            if (Enable)
            {
                mainForm.Paint += new PaintEventHandler(mainForm_Paint);
                mainForm.MouseMove += new MouseEventHandler(mainForm_MouseMove);
                mainForm.MouseUp += new MouseEventHandler(mainForm_MouseUp);
            }
            else
            {
                mainForm.Paint -= new PaintEventHandler(mainForm_Paint);
                mainForm.MouseMove -= new MouseEventHandler(mainForm_MouseMove);
                mainForm.MouseUp -= new MouseEventHandler(mainForm_MouseUp);
            }
        }

        void mainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && controlDragStarted)
            {
                controlDragStarted = false;
                mainForm.Capture = false;
                mainForm.Cursor = Cursors.Default;

                GraphicsPath myGraphicsPath = new GraphicsPath();
                Rectangle tempRectangle = new Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4);
                myGraphicsPath.AddRectangle(tempRectangle);
                System.Drawing.Region rgn = new Region(myGraphicsPath);

                controlUnderDrag.Location = controlImage.Location;
                controlImage.Height = 0; controlImage.Width = 0;
                mainForm.Invalidate(rgn);

                controlUnderDrag.Invalidate();
            }
        }

        void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (controlDragStarted)
            {
                GraphicsPath myGraphicsPath = new GraphicsPath();
                Rectangle tempRectangle = new Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4);
                myGraphicsPath.AddRectangle(tempRectangle);
                System.Drawing.Region rgn = new Region(myGraphicsPath);

                controlImage = new Rectangle(e.Location.X - mouseOffset.Width, e.Location.Y - mouseOffset.Height, controlImage.Width,
                    controlImage.Height);

                mainForm.Invalidate(rgn);

                myGraphicsPath.Dispose();
                myGraphicsPath = new GraphicsPath();
                rgn.Dispose();
                tempRectangle = new Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4);
                rgn = new Region(tempRectangle);
                mainForm.Invalidate(rgn);
            }
        }

        void mainForm_Paint(object sender, PaintEventArgs e)
        {
            if (controlImage != null && controlDragStarted)
            {
                //e.Graphics.DrawRectangle(Pens.Magenta, controlImage);
                controlUnderDrag.Location = controlImage.Location;
            }
        }
    }
}

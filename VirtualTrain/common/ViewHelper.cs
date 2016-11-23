using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace VirtualTrain
{
    class ViewHelper
    {
        public static float X;
        public static float Y;

        public static void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }

        public static void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * newy;
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        }

        public static Size size;

        public static void MdiChildrenAutoSize(Form form)
        {
            ViewHelper.X = form.Width;
            ViewHelper.Y = form.Height;
            ViewHelper.setTag(form);
            form.Size = ViewHelper.size;
            float newx = (form.Width) / ViewHelper.X;
            float newy = form.Height / ViewHelper.Y;
            ViewHelper.setControls(newx, newy, form);
        }

        public static void MaximizedAutoSize(Form form)
        {
            ViewHelper.X = form.Width;
            ViewHelper.Y = form.Height;
            ViewHelper.setTag(form);
            form.WindowState = FormWindowState.Maximized;
            float newx = (form.Width) / ViewHelper.X;
            float newy = form.Height / ViewHelper.Y;
            ViewHelper.setControls(newx, newy, form);
        }
    }
}

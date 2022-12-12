using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Картина_Безье
{
    public partial class BezierArt : Form
    {
        const int iNum = 100;
        public BezierArt()
        {
            Text = "Картина Безье";
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void BezierArt_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Green);
            PointF[] aptf = new PointF[4];
            int cx = ClientSize.Width;
            int cy = ClientSize.Height;
            Graphics grfx = e.Graphics;

            

            for(int i = 0; i < iNum; i++)
            {
                double dAngle = i * Math.PI / iNum;

                aptf[0].X = cx / 2 + cx / 2 * (float)Math.Cos(dAngle);
                aptf[0].Y = 5 * cy / 8 + cy / 16 * (float)Math.Sin(dAngle);

                aptf[1] = new PointF(cx / 2, -cy);
                aptf[2] = new PointF(cx / 2, 2 * cy);

                dAngle += Math.PI;

                aptf[3].X = cx / 2 + cx / 4 * (float)Math.Cos(dAngle);
                aptf[3].Y = cy / 2 + cy / 16 * (float)Math.Sin(dAngle);

                Random r = new Random();
                int color = r.Next(-1, 8);

                if (color % 7 == 6) { pen = new Pen(System.Drawing.Color.Red); }
                if (color % 7 == 5) { pen = new Pen(System.Drawing.Color.Orange); }
                if (color % 7 == 4) { pen = new Pen(System.Drawing.Color.Yellow); }
                if (color % 7 == 3) { pen = new Pen(System.Drawing.Color.Green); }
                if (color % 7 == 2) { pen = new Pen(System.Drawing.Color.LightBlue); }
                if (color % 7 == 1) { pen = new Pen(System.Drawing.Color.Blue); }
                if (color % 7 == 0) { pen = new Pen(System.Drawing.Color.Magenta); }

                grfx.DrawBeziers(pen, aptf);
            }
        }
    }
}

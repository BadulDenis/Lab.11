using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab._11
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer() { Interval = 300 };
        bool beat = false;
        public Form1()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
            timer.Start();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            SolidBrush peg = new SolidBrush(Color.Red);
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            RectangleF r;
            gp.AddBezier(150, 150,
                150, 120,
                100, 120,
                100, 150);
            gp.AddBezier(100, 150,
                100, 180,
                150, 185,
                150, 210);
            gp.AddBezier(150, 210,
                150, 185,
                200, 180,
                200, 150);
            gp.AddBezier(200, 150,
                200, 120,
                150, 120,
                150, 150);
            r = gp.GetBounds();
            if (beat) gp.Transform(new Matrix(0.99f, 0, 0, 0.99f, 0, 0));
            g.TranslateTransform(-r.Width / 2, -r.Height / 2);
            g.FillPath(peg, gp);
            beat = !beat;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

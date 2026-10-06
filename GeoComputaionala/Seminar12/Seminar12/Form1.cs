using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Seminar12
{
    public partial class Form1 : Form
    {
        public List<PointF> puncte = new List<PointF>();
        public PointF centrulCircumscris;
        public bool esteCalculat = false;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Diagrama Voronoi (3 Puncte)";
            this.MouseClick += Form1_MouseClick;
            this.Paint += Form1_Paint;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (puncte.Count < 3)
                {
                    puncte.Add(e.Location);
                    if (puncte.Count == 3)
                    {
                        CalculeazaCentru();
                    }
                    this.Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                puncte.Clear();
                esteCalculat = false;
                this.Invalidate();
            }
        }

        private void CalculeazaCentru()
        {
            float x1 = puncte[0].X, y1 = puncte[0].Y;
            float x2 = puncte[1].X, y2 = puncte[1].Y;
            float x3 = puncte[2].X, y3 = puncte[2].Y;

            float d = 2 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));

            if (Math.Abs(d) < 0.001f)
            {
                MessageBox.Show("Punctele sunt coliniare!");
                puncte.Clear();
                return;
            }

            float ux = ((x1 * x1 + y1 * y1) * (y2 - y3) + (x2 * x2 + y2 * y2) * (y3 - y1) + (x3 * x3 + y3 * y3) * (y1 - y2)) / d;
            float uy = ((x1 * x1 + y1 * y1) * (x3 - x2) + (x2 * x2 + y2 * y2) * (x1 - x3) + (x3 * x3 + y3 * y3) * (x2 - x1)) / d;

            centrulCircumscris = new PointF(ux, uy);
            esteCalculat = true;
        }

        private void DeseneazaMediatoarea(Graphics g, PointF centru, PointF p1, PointF p2)
        {
            PointF mijloc = new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);

            float dx = mijloc.X - centru.X;
            float dy = mijloc.Y - centru.Y;

            PointF capat1 = new PointF(centru.X + dx * 1000, centru.Y + dy * 1000);
            PointF capat2 = new PointF(centru.X - dx * 1000, centru.Y - dy * 1000);

            g.DrawLine(Pens.Black, capat1, capat2);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            

            if (esteCalculat)
            {
                Pen penLaturi = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                g.DrawLine(penLaturi, puncte[0], puncte[1]);
                g.DrawLine(penLaturi, puncte[1], puncte[2]);
                g.DrawLine(penLaturi, puncte[2], puncte[0]);

                DeseneazaMediatoarea(g, centrulCircumscris, puncte[0], puncte[1]);
                DeseneazaMediatoarea(g, centrulCircumscris, puncte[1], puncte[2]);
                DeseneazaMediatoarea(g, centrulCircumscris, puncte[2], puncte[0]);

                g.FillEllipse(Brushes.Red, centrulCircumscris.X - 4, centrulCircumscris.Y - 4, 8, 8);
            }

            foreach (var p in puncte)
            {
                g.FillEllipse(Brushes.Black, p.X - 5, p.Y - 5, 10, 10);
            }
        }
        private void Form1_Load(object sender, EventArgs e) { }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Seminar4
{
    public partial class Form1 : Form
    {
        public PointF[] puncte;
        public List<Tuple<PointF, PointF>> muchiiInvelitoare;
        public int numarPuncte = 20;

        public Form1()
        {
            InitializeComponent();


            puncte = new PointF[numarPuncte];
            muchiiInvelitoare = new List<Tuple<PointF, PointF>>();

            Random rnd = new Random();
            for (int i = 0; i < numarPuncte; i++)
            {
                float x = rnd.Next(50, this.ClientSize.Width - 50);
                float y = rnd.Next(50, this.ClientSize.Height - 50);
                puncte[i] = new PointF(x, y);
            }

            AlgoritmSlab();

            this.Paint += Form1_Paint;
        }

        private double ProdusIncrucisat(PointF p, PointF q, PointF r)
        {
            return (q.X - p.X) * (r.Y - p.Y) - (q.Y - p.Y) * (r.X - p.X);
        }

        private void AlgoritmSlab()
        {
            for (int i = 0; i < numarPuncte; i++)
            {
                for (int j = 0; j < numarPuncte; j++)
                {
                    if (i == j) continue; 

                    bool valid = true;

                    for (int k = 0; k < numarPuncte; k++)
                    {
                        if (k == i || k == j) continue;

                        if (ProdusIncrucisat(puncte[i], puncte[j], puncte[k]) > 0)
                        {
                            valid = false;
                            break; 
                        }
                    }

                    if (valid)
                    {
                        muchiiInvelitoare.Add(new Tuple<PointF, PointF>(puncte[i], puncte[j]));
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Brush pensulaPuncte = Brushes.Red;
            int raza = 4;
            foreach (PointF p in puncte)
            {
                g.FillEllipse(pensulaPuncte, p.X - raza, p.Y - raza, raza * 2, raza * 2);
            }

            Pen stilouLinii = new Pen(Color.Blue, 2);
            foreach (var muchie in muchiiInvelitoare)
            {
                g.DrawLine(stilouLinii, muchie.Item1, muchie.Item2);
            }
        }
        public void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Seminar5
{
    public partial class Form1 : Form
    {
        public PointF[] puncte;
        public List<PointF> invelitoareConvexa;
        public int numarPuncte = 20;

        public Form1()
        {
            InitializeComponent();
           

            puncte = new PointF[numarPuncte];
            invelitoareConvexa = new List<PointF>();

            Random rnd = new Random();
            for (int i = 0; i < numarPuncte; i++)
            {
                float x = rnd.Next(50, this.ClientSize.Width - 50);
                float y = rnd.Next(50, this.ClientSize.Height - 50);
                puncte[i] = new PointF(x, y);
            }

            AlgoritmJarvis();

            this.Paint += Form1_Paint;
        }

        private int Orientare(PointF p, PointF q, PointF r)
        {
            float val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (val == 0) return 0;
            return (val > 0) ? 1 : 2;
        }

        private void AlgoritmJarvis()
        {
            if (numarPuncte < 3) return;

            int celMaiDinStanga = 0;
            for (int i = 1; i < numarPuncte; i++)
            {
                if (puncte[i].X < puncte[celMaiDinStanga].X)
                {
                    celMaiDinStanga = i;
                }
            }

            int p = celMaiDinStanga;
            int q;

            do
            {
                invelitoareConvexa.Add(puncte[p]);

                q = (p + 1) % numarPuncte;

                for (int i = 0; i < numarPuncte; i++)
                {
                    if (Orientare(puncte[p], puncte[i], puncte[q]) == 2)
                    {
                        q = i;
                    }
                }

                p = q;

            } while (p != celMaiDinStanga);
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
            for (int i = 0; i < invelitoareConvexa.Count; i++)
            {
                PointF p1 = invelitoareConvexa[i];
                PointF p2 = invelitoareConvexa[(i + 1) % invelitoareConvexa.Count];

                g.DrawLine(stilouLinii, p1, p2);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
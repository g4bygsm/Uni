using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Seminar7
{
    public partial class Form1 : Form
    {
        public List<PointF> p;
        public List<Tuple<int, int>> diagonale;
        public int n = 10;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Triangularea prin Diagonale (Poligon Simplu)";

            p = new List<PointF>();
            diagonale = new List<Tuple<int, int>>();
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                float x = rnd.Next(50, this.ClientSize.Width - 50);
                float y = rnd.Next(50, this.ClientSize.Height - 50);
                p.Add(new PointF(x, y));
            }

            OrdoneazaPoligon();
            AsiguraSensTrigonometric();
            GasesteDiagonale();

            this.Paint += Form1_Paint;
        }

        private void OrdoneazaPoligon()
        {
            float cx = p.Average(pct => pct.X);
            float cy = p.Average(pct => pct.Y);
            p = p.OrderBy(pct => Math.Atan2(pct.Y - cy, pct.X - cx)).ToList();
        }

        private void AsiguraSensTrigonometric()
        {
            double suma = 0;
            for (int i = 0; i < n; i++)
            {
                PointF curent = p[i];
                PointF urmator = p[(i + 1) % n];
                suma += (urmator.X - curent.X) * (urmator.Y + curent.Y);
            }
            if (suma > 0)
            {
                p.Reverse();
            }
        }

        private double Sarrus(PointF p1, PointF p2, PointF p3)
        {
            return (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
        }

        private bool IntoarcereSpreStanga(int p1, int p2, int p3)
        {
            return Sarrus(p[p1], p[p2], p[p3]) < 0;
        }

        private bool IntoarcereSpreDreapta(int p1, int p2, int p3)
        {
            return Sarrus(p[p1], p[p2], p[p3]) > 0;
        }

        private bool EsteVarfConvex(int pi)
        {
            int ant = (pi > 0) ? pi - 1 : n - 1;
            int urm = (pi < n - 1) ? pi + 1 : 0;
            return IntoarcereSpreDreapta(ant, pi, urm);
        }

        private bool InInterior(int pi, int pj)
        {
            int ant = (pi > 0) ? pi - 1 : n - 1;
            int urm = (pi < n - 1) ? pi + 1 : 0;

            if (EsteVarfConvex(pi))
            {
                return IntoarcereSpreStanga(pi, pj, urm) && IntoarcereSpreStanga(pi, ant, pj);
            }
            else
            {
                return !(IntoarcereSpreDreapta(pi, pj, urm) && IntoarcereSpreDreapta(pi, ant, pj));
            }
        }

        private bool SeIntersecteaza(PointF s1, PointF s2, PointF p1, PointF p2)
        {
            if (Sarrus(p2, p1, s1) * Sarrus(p2, p1, s2) < 0 && Sarrus(s2, s1, p1) * Sarrus(s2, s1, p2) < 0)
                return true;
            return false;
        }

        private void GasesteDiagonale()
        {
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 2; j < n; j++)
                {
                    if (i == 0 && j == n - 1) continue;

                    bool intersectie = false;

                    for (int k = 0; k < n; k++)
                    {
                        int k_urm = (k + 1) % n;
                        if (i != k && i != k_urm && j != k && j != k_urm)
                        {
                            if (SeIntersecteaza(p[i], p[j], p[k], p[k_urm]))
                            {
                                intersectie = true;
                                break;
                            }
                        }
                    }

                    if (!intersectie)
                    {
                        foreach (var diag in diagonale)
                        {
                            if (i != diag.Item1 && i != diag.Item2 && j != diag.Item1 && j != diag.Item2)
                            {
                                if (SeIntersecteaza(p[i], p[j], p[diag.Item1], p[diag.Item2]))
                                {
                                    intersectie = true;
                                    break;
                                }
                            }
                        }

                        if (!intersectie && InInterior(i, j))
                        {
                            diagonale.Add(new Tuple<int, int>(i, j));

                            if (diagonale.Count == n - 3) return;
                        }
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen penLaturi = new Pen(Color.Navy, 2);
            Pen penDiagonale = new Pen(Color.Red, 1) { DashPattern = new float[] { 4, 4 } };
            Brush brushText = new SolidBrush(Color.Black);
            Brush brushPunct = Brushes.Red;
            Font fontText = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

            int raza = 4;

            for (int i = 0; i < n; i++)
            {
                PointF curent = p[i];
                PointF urmator = p[(i + 1) % n];

                g.DrawLine(penLaturi, curent, urmator);
                g.FillEllipse(brushPunct, curent.X - raza, curent.Y - raza, raza * 2, raza * 2);
                g.DrawString(i.ToString(), fontText, brushText, curent.X + 5, curent.Y + 5);
            }

            foreach (var diag in diagonale)
            {
                g.DrawLine(penDiagonale, p[diag.Item1], p[diag.Item2]);
            }
        }
    }
}
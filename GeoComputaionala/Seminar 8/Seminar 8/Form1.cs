using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Seminar_8
{
    public partial class Form1 : Form
    {
        public List<PointF> varfuri = new List<PointF>();
        public bool desenInchis = false;

        public List<Tuple<int, int, int>> triunghiuri = new List<Tuple<int, int, int>>();
        public int[] culori;
        public double ariaPoligonului = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Seminar 8: Otectomie, 3-Colorare, Arie";
            this.MouseClick += Form1_MouseClick;
            this.Paint += Form1_Paint;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (desenInchis) return;

            if (e.Button == MouseButtons.Left)
            {
                varfuri.Add(e.Location);
                this.Invalidate();
            }
            else if (e.Button == MouseButtons.Right && varfuri.Count >= 3)
            {
                desenInchis = true;
                ProceseazaPoligonul();
                this.Invalidate();
            }
        }

        private void ProceseazaPoligonul()
        {
            ariaPoligonului = CalculeazaAriaShoelace();

            if (ariaPoligonului < 0)
            {
                varfuri.Reverse();
                ariaPoligonului = Math.Abs(ariaPoligonului);
            }

            int n = varfuri.Count;
            culori = new int[n];
            for (int i = 0; i < n; i++) culori[i] = -1;

            List<int> indecsiRamasi = Enumerable.Range(0, n).ToList();
            Stack<Tuple<int, int, int>> istoricUrechi = new Stack<Tuple<int, int, int>>();

            while (indecsiRamasi.Count > 3)
            {
                for (int i = 0; i < indecsiRamasi.Count; i++)
                {
                    int prev = indecsiRamasi[(i == 0) ? indecsiRamasi.Count - 1 : i - 1];
                    int curr = indecsiRamasi[i];
                    int next = indecsiRamasi[(i + 1) % indecsiRamasi.Count];

                    if (EsteUreche(prev, curr, next, indecsiRamasi))
                    {
                        triunghiuri.Add(new Tuple<int, int, int>(prev, curr, next));
                        istoricUrechi.Push(new Tuple<int, int, int>(prev, curr, next));
                        indecsiRamasi.RemoveAt(i);
                        break;
                    }
                }
            }

            triunghiuri.Add(new Tuple<int, int, int>(indecsiRamasi[0], indecsiRamasi[1], indecsiRamasi[2]));

            culori[indecsiRamasi[0]] = 0;
            culori[indecsiRamasi[1]] = 1;
            culori[indecsiRamasi[2]] = 2;

            while (istoricUrechi.Count > 0)
            {
                var ureche = istoricUrechi.Pop();
                int prev = ureche.Item1;
                int curr = ureche.Item2;
                int next = ureche.Item3;

                culori[curr] = 3 - (culori[prev] + culori[next]);
            }
        }

        private double CalculeazaAriaShoelace()
        {
            double arie = 0;
            int n = varfuri.Count;
            for (int i = 0; i < n; i++)
            {
                PointF p1 = varfuri[i];
                PointF p2 = varfuri[(i + 1) % n];
                arie += (p1.X * p2.Y - p1.Y * p2.X);
            }
            return arie / 2.0;
        }

        private bool EsteUreche(int p1, int p2, int p3, List<int> ramasi)
        {
            PointF a = varfuri[p1];
            PointF b = varfuri[p2];
            PointF c = varfuri[p3];

            if (ProdusIncrucisat(a, b, c) <= 0) return false;

            foreach (int i in ramasi)
            {
                if (i == p1 || i == p2 || i == p3) continue;
                if (PunctInTriunghi(varfuri[i], a, b, c)) return false;
            }
            return true;
        }

        private float ProdusIncrucisat(PointF a, PointF b, PointF c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }

        private bool PunctInTriunghi(PointF pt, PointF v1, PointF v2, PointF v3)
        {
            bool b1 = ProdusIncrucisat(pt, v1, v2) < 0.0f;
            bool b2 = ProdusIncrucisat(pt, v2, v3) < 0.0f;
            bool b3 = ProdusIncrucisat(pt, v3, v1) < 0.0f;
            return ((b1 == b2) && (b2 == b3));
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen penContur = new Pen(Color.Black, 2);
            for (int i = 0; i < varfuri.Count; i++)
            {
                PointF p1 = varfuri[i];
                PointF p2 = varfuri[(desenInchis) ? (i + 1) % varfuri.Count : i < varfuri.Count - 1 ? i + 1 : i];
                if (i < varfuri.Count - 1 || desenInchis) g.DrawLine(penContur, p1, p2);
            }

            if (desenInchis)
            {
                Pen penTriangulare = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                foreach (var tr in triunghiuri)
                {
                    g.DrawLine(penTriangulare, varfuri[tr.Item1], varfuri[tr.Item3]);
                }

                Brush[] paleta = { Brushes.Red, Brushes.Green, Brushes.Blue };
                for (int i = 0; i < varfuri.Count; i++)
                {
                    Brush culoareCurenta = (culori[i] == -1) ? Brushes.Black : paleta[culori[i]];
                    g.FillEllipse(culoareCurenta, varfuri[i].X - 6, varfuri[i].Y - 6, 12, 12);
                }

                g.DrawString($"Aria Poligonului: {Math.Round(ariaPoligonului, 2)}",
                    new Font("Arial", 12, FontStyle.Bold), Brushes.DarkRed, 10, 10);
            }
            else
            {
                foreach (var p in varfuri) g.FillEllipse(Brushes.Black, p.X - 4, p.Y - 4, 8, 8);
            }
        }
    }
}
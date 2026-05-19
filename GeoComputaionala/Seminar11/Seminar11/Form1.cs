using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Seminar11
{
    public partial class Form1 : Form
    {
        public List<PointF> varfuri = new List<PointF>();
        public bool desenInchis = false;

        public List<Tuple<int, int>> diagonaleInitiale = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> diagonaleEsentiale = new List<Tuple<int, int>>();
        public List<List<int>> poligoaneConvexe = new List<List<int>>();

        public Form1()
        {
            InitializeComponent();
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
                PartitioneazaConvex();
                this.Invalidate();
            }
        }

        private void PartitioneazaConvex()
        {
            int n = varfuri.Count;

            if (CalculeazaAria() < 0)
            {
                varfuri.Reverse();
            }

            diagonaleInitiale.Clear();
            diagonaleEsentiale.Clear();
            poligoaneConvexe.Clear();

            List<Tuple<int, int, int>> triunghiuri = TrianguleazaOtectomie();
            foreach (var t in triunghiuri)
            {
                AdaugaDiagonalaDacaEValida(t.Item1, t.Item2);
                AdaugaDiagonalaDacaEValida(t.Item2, t.Item3);
                AdaugaDiagonalaDacaEValida(t.Item3, t.Item1);
            }

            foreach (var t in triunghiuri)
            {
                poligoaneConvexe.Add(new List<int> { t.Item1, t.Item2, t.Item3 });
            }

            for (int i = diagonaleInitiale.Count - 1; i >= 0; i--)
            {
                var diag = diagonaleInitiale[i];
                int u = diag.Item1;
                int v = diag.Item2;

                int idxP1 = poligoaneConvexe.FindIndex(p => p.Contains(u) && p.Contains(v));
                int idxP2 = poligoaneConvexe.FindLastIndex(p => p.Contains(u) && p.Contains(v));

                if (idxP1 != -1 && idxP2 != -1 && idxP1 != idxP2)
                {
                    List<int> p1 = poligoaneConvexe[idxP1];
                    List<int> p2 = poligoaneConvexe[idxP2];

                    List<int> poligonUnit = UnestePoligoane(p1, p2, u, v);

                    if (EsteVarfConvex(poligonUnit, u) && EsteVarfConvex(poligonUnit, v))
                    {
                        poligoaneConvexe.RemoveAt(Math.Max(idxP1, idxP2));
                        poligoaneConvexe.RemoveAt(Math.Min(idxP1, idxP2));
                        poligoaneConvexe.Add(poligonUnit);
                    }
                    else
                    {
                        diagonaleEsentiale.Add(diag);
                    }
                }
                else
                {
                    diagonaleEsentiale.Add(diag);
                }
            }
        }

        private List<Tuple<int, int, int>> TrianguleazaOtectomie()
        {
            List<Tuple<int, int, int>> rezultat = new List<Tuple<int, int, int>>();
            List<int> ramasi = Enumerable.Range(0, varfuri.Count).ToList();

            while (ramasi.Count > 3)
            {
                bool taiat = false;
                for (int i = 0; i < ramasi.Count; i++)
                {
                    int prev = ramasi[(i - 1 + ramasi.Count) % ramasi.Count];
                    int curr = ramasi[i];
                    int next = ramasi[(i + 1) % ramasi.Count];

                    if (EsteUreche(prev, curr, next, ramasi))
                    {
                        rezultat.Add(new Tuple<int, int, int>(prev, curr, next));
                        ramasi.RemoveAt(i);
                        taiat = true;
                        break;
                    }
                }
                if (!taiat) break;
            }
            if (ramasi.Count == 3)
                rezultat.Add(new Tuple<int, int, int>(ramasi[0], ramasi[1], ramasi[2]));

            return rezultat;
        }

        private List<int> UnestePoligoane(List<int> p1, List<int> p2, int u, int v)
        {
            int idxU1 = p1.IndexOf(u);
            if (p1[(idxU1 + 1) % p1.Count] != v)
            {
                var temp = p1; p1 = p2; p2 = temp;
            }

            int idxV1 = p1.IndexOf(v);
            int idxU2 = p2.IndexOf(u);

            List<int> poligonNou = new List<int>();

            int curent = idxV1;
            while (true)
            {
                poligonNou.Add(p1[curent]);
                if (p1[curent] == u) break;
                curent = (curent + 1) % p1.Count;
            }

            curent = (idxU2 + 1) % p2.Count;
            while (p2[curent] != v)
            {
                poligonNou.Add(p2[curent]);
                curent = (curent + 1) % p2.Count;
            }

            return poligonNou;
        }

        private void AdaugaDiagonalaDacaEValida(int u, int v)
        {
            if (u > v) { int t = u; u = v; v = t; }
            if (Math.Abs(u - v) == 1 || Math.Abs(u - v) == varfuri.Count - 1) return;

            var d = new Tuple<int, int>(u, v);
            if (!diagonaleInitiale.Contains(d)) diagonaleInitiale.Add(d);
        }

        private bool EsteVarfConvex(List<int> poly, int v)
        {
            int idx = poly.IndexOf(v);
            int prev = poly[(idx - 1 + poly.Count) % poly.Count];
            int next = poly[(idx + 1) % poly.Count];

            return ProdusIncrucisat(varfuri[prev], varfuri[v], varfuri[next]) >= 0;
        }

        private bool EsteUreche(int p1, int p2, int p3, List<int> ramasi)
        {
            PointF a = varfuri[p1], b = varfuri[p2], c = varfuri[p3];
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

        private double CalculeazaAria()
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (desenInchis)
            {
                Pen penInutil = new Pen(Color.LightGray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };
                foreach (var diag in diagonaleInitiale)
                {
                    if (!diagonaleEsentiale.Contains(diag))
                        g.DrawLine(penInutil, varfuri[diag.Item1], varfuri[diag.Item2]);
                }

                Pen penEsential = new Pen(Color.Red, 2);
                foreach (var diag in diagonaleEsentiale)
                {
                    g.DrawLine(penEsential, varfuri[diag.Item1], varfuri[diag.Item2]);
                }
            }

            Pen penContur = new Pen(Color.Black, 3);
            for (int i = 0; i < varfuri.Count; i++)
            {
                PointF p1 = varfuri[i];
                PointF p2 = varfuri[(desenInchis) ? (i + 1) % varfuri.Count : i < varfuri.Count - 1 ? i + 1 : i];
                if (i < varfuri.Count - 1 || desenInchis) g.DrawLine(penContur, p1, p2);
            }

            Font fontText = new Font("Arial", 10, FontStyle.Bold);
            for (int i = 0; i < varfuri.Count; i++)
            {
                g.FillEllipse(Brushes.Black, varfuri[i].X - 5, varfuri[i].Y - 5, 10, 10);
                g.DrawString(i.ToString(), fontText, Brushes.Black, varfuri[i].X + 8, varfuri[i].Y - 8);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        { }
    }
}
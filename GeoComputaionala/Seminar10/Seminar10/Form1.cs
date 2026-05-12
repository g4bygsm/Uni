using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Seminar10 
{
    public partial class Form1 : Form
    {
        public List<PointF> varfuri = new List<PointF>();
        public bool desenInchis = false;

        public List<int> varfuriSeparare = new List<int>();
        public List<int> varfuriUnire = new List<int>();

        public List<Tuple<int, int>> diagonaleMonotone = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> diagonaleTriangulare = new List<Tuple<int, int>>();

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
                PartitioneazaMonoton();
                this.Invalidate();
            }
        }

        private void PartitioneazaMonoton()
        {
            int n = varfuri.Count;

            if (CalculeazaAria() < 0)
            {
                varfuri.Reverse();
            }

            varfuriSeparare.Clear();
            varfuriUnire.Clear();
            diagonaleMonotone.Clear();
            diagonaleTriangulare.Clear();

            for (int i = 0; i < n; i++)
            {
                int prev = (i - 1 + n) % n;
                int next = (i + 1) % n;

                if (EsteReflex(prev, i, next))
                {
                    if (varfuri[prev].Y > varfuri[i].Y && varfuri[next].Y > varfuri[i].Y)
                        varfuriSeparare.Add(i);
                    else if (varfuri[prev].Y < varfuri[i].Y && varfuri[next].Y < varfuri[i].Y)
                        varfuriUnire.Add(i);
                }
            }

            foreach (int i in varfuriSeparare)
            {
                int celMaiBunJ = -1;
                float maxY = -float.MaxValue;

                for (int j = 0; j < n; j++)
                {
                    if (varfuri[j].Y < varfuri[i].Y && EsteDiagonalaValida(i, j))
                    {
                        if (varfuri[j].Y > maxY) { maxY = varfuri[j].Y; celMaiBunJ = j; }
                    }
                }
                if (celMaiBunJ != -1) diagonaleMonotone.Add(new Tuple<int, int>(i, celMaiBunJ));
            }

            foreach (int i in varfuriUnire)
            {
                int celMaiBunJ = -1;
                float minY = float.MaxValue;

                for (int j = 0; j < n; j++)
                {
                    if (varfuri[j].Y > varfuri[i].Y && EsteDiagonalaValida(i, j))
                    {
                        if (varfuri[j].Y < minY) { minY = varfuri[j].Y; celMaiBunJ = j; }
                    }
                }
                if (celMaiBunJ != -1) diagonaleMonotone.Add(new Tuple<int, int>(i, celMaiBunJ));
            }

            List<List<int>> poligoaneMonotone = ObtinePoligoaneMonotone();

            foreach (var poly in poligoaneMonotone)
            {
                TrianguleazaPoligonMonoton(poly);
            }
        }

        private List<List<int>> ObtinePoligoaneMonotone()
        {
            List<List<int>> poligoane = new List<List<int>>();
            poligoane.Add(new List<int>(Enumerable.Range(0, varfuri.Count)));
            foreach (var diag in diagonaleMonotone)
            {
                int u = diag.Item1;
                int v = diag.Item2;

                for (int i = 0; i < poligoane.Count; i++)
                {
                    var p = poligoane[i];
                    int idxU = p.IndexOf(u);
                    int idxV = p.IndexOf(v);

                    if (idxU != -1 && idxV != -1)
                    {
                        if (idxU > idxV) { int temp = idxU; idxU = idxV; idxV = temp; }

                        List<int> poly1 = new List<int>();
                        poly1.AddRange(p.GetRange(0, idxU + 1));
                        poly1.AddRange(p.GetRange(idxV, p.Count - idxV));

                        List<int> poly2 = new List<int>();
                        poly2.AddRange(p.GetRange(idxU, idxV - idxU + 1));

                        poligoane.RemoveAt(i);
                        poligoane.Add(poly1);
                        poligoane.Add(poly2);
                        break;
                    }
                }
            }
            return poligoane;
        }

        private void TrianguleazaPoligonMonoton(List<int> poly)
        {
            if (poly.Count <= 3) return; 

            List<int> sortedPoly = poly.OrderBy(idx => varfuri[idx].Y).ToList();

            int topIdx = poly.IndexOf(sortedPoly[0]);
            int bottomIdx = poly.IndexOf(sortedPoly[sortedPoly.Count - 1]);

            HashSet<int> chainA = new HashSet<int>();
            int curr = topIdx;
            while (curr != bottomIdx)
            {
                chainA.Add(poly[curr]);
                curr = (curr + 1) % poly.Count;
            }
            chainA.Add(poly[bottomIdx]);

            Stack<int> stiva = new Stack<int>();
            stiva.Push(sortedPoly[0]);
            stiva.Push(sortedPoly[1]);

            for (int j = 2; j < sortedPoly.Count - 1; j++)
            {
                int pj = sortedPoly[j];
                int top = stiva.Peek();

                bool pjInA = chainA.Contains(pj);
                bool topInA = chainA.Contains(top);

                if (pjInA != topInA)
                {
                    int bottomOfStack = -1;
                    while (stiva.Count > 0)
                    {
                        int v = stiva.Pop();
                        bottomOfStack = v;
                        if (stiva.Count > 0)
                        {
                            diagonaleTriangulare.Add(new Tuple<int, int>(pj, v));
                        }
                    }
                    stiva.Push(sortedPoly[j - 1]);
                    stiva.Push(pj);
                }
                else
                {
                    int u = stiva.Pop();
                    while (stiva.Count > 0)
                    {
                        int v = stiva.Peek();
                        if (EsteDiagonalaInInteriorPoly(poly, pj, v))
                        {
                            stiva.Pop();
                            diagonaleTriangulare.Add(new Tuple<int, int>(pj, v));
                            u = v;
                        }
                        else
                        {
                            break;
                        }
                    }
                    stiva.Push(u);
                    stiva.Push(pj);
                }
            }

            int pn = sortedPoly[sortedPoly.Count - 1];
            stiva.Pop(); 

            while (stiva.Count > 1)
            {
                int v = stiva.Pop();
                diagonaleTriangulare.Add(new Tuple<int, int>(pn, v));
            }
        }


        private bool EsteDiagonalaInInteriorPoly(List<int> poly, int u, int v)
        {
            PointF pu = varfuri[u];
            PointF pv = varfuri[v];

            for (int i = 0; i < poly.Count; i++)
            {
                int next = (i + 1) % poly.Count;
                int k1 = poly[i];
                int k2 = poly[next];

                if (k1 == u || k1 == v || k2 == u || k2 == v) continue;
                if (SegmenteSeIntersecteaza(pu, pv, varfuri[k1], varfuri[k2])) return false;
            }

            PointF mijloc = new PointF((pu.X + pv.X) / 2, (pu.Y + pv.Y) / 2);
            return PunctInSubPoligon(poly, mijloc);
        }

        private bool PunctInSubPoligon(List<int> poly, PointF p)
        {
            bool inauntru = false;
            for (int i = 0, j = poly.Count - 1; i < poly.Count; j = i++)
            {
                PointF pi = varfuri[poly[i]];
                PointF pj = varfuri[poly[j]];
                if (((pi.Y > p.Y) != (pj.Y > p.Y)) &&
                    (p.X < (pj.X - pi.X) * (p.Y - pi.Y) / (pj.Y - pi.Y) + pi.X))
                {
                    inauntru = !inauntru;
                }
            }
            return inauntru;
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

        private float ProdusIncrucisat(PointF a, PointF b, PointF c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }

        private bool EsteReflex(int prev, int curr, int next)
        {
            return ProdusIncrucisat(varfuri[prev], varfuri[curr], varfuri[next]) < -0.001f;
        }

        private bool EsteDiagonalaValida(int i, int j)
        {
            if (i == j || Math.Abs(i - j) == 1 || Math.Abs(i - j) == varfuri.Count - 1) return false;

            PointF pi = varfuri[i];
            PointF pj = varfuri[j];

            for (int k = 0; k < varfuri.Count; k++)
            {
                int kNext = (k + 1) % varfuri.Count;
                if (k == i || k == j || kNext == i || kNext == j) continue;
                if (SegmenteSeIntersecteaza(pi, pj, varfuri[k], varfuri[kNext])) return false;
            }

            foreach (var diag in diagonaleMonotone)
            {
                if (diag.Item1 == i || diag.Item1 == j || diag.Item2 == i || diag.Item2 == j) continue;
                if (SegmenteSeIntersecteaza(pi, pj, varfuri[diag.Item1], varfuri[diag.Item2])) return false;
            }

            for (int k = 0; k < varfuri.Count; k++)
            {
                if (k == i || k == j) continue;
                if (Math.Abs(ProdusIncrucisat(pi, pj, varfuri[k])) < 0.1f)
                {
                    float minX = Math.Min(pi.X, pj.X) - 0.1f, maxX = Math.Max(pi.X, pj.X) + 0.1f;
                    float minY = Math.Min(pi.Y, pj.Y) - 0.1f, maxY = Math.Max(pi.Y, pj.Y) + 0.1f;
                    if (varfuri[k].X >= minX && varfuri[k].X <= maxX && varfuri[k].Y >= minY && varfuri[k].Y <= maxY)
                        return false;
                }
            }

            PointF mijloc = new PointF((pi.X + pj.X) / 2, (pi.Y + pj.Y) / 2);
            return PunctInSubPoligon(Enumerable.Range(0, varfuri.Count).ToList(), mijloc);
        }

        private bool SegmenteSeIntersecteaza(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            float d1 = ProdusIncrucisat(p3, p4, p1);
            float d2 = ProdusIncrucisat(p3, p4, p2);
            float d3 = ProdusIncrucisat(p1, p2, p3);
            float d4 = ProdusIncrucisat(p1, p2, p4);

            return (((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0)) &&
                    ((d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0)));
        }


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
                Pen penDiagonaleMonotone = new Pen(Color.Purple, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                foreach (var diag in diagonaleMonotone)
                {
                    g.DrawLine(penDiagonaleMonotone, varfuri[diag.Item1], varfuri[diag.Item2]);
                }

      
                Pen penTriangulare = new Pen(Color.ForestGreen, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };
                foreach (var diag in diagonaleTriangulare)
                {
                    g.DrawLine(penTriangulare, varfuri[diag.Item1], varfuri[diag.Item2]);
                }

                Font fontText = new Font("Arial", 10, FontStyle.Bold);
                for (int i = 0; i < varfuri.Count; i++)
                {
                    Brush culoareCurenta = Brushes.Black;
                    string label = i.ToString();

                    if (varfuriSeparare.Contains(i))
                    {
                        culoareCurenta = Brushes.Red;
                        label = "S (" + i + ")";
                    }
                    else if (varfuriUnire.Contains(i))
                    {
                        culoareCurenta = Brushes.Blue;
                        label = "U (" + i + ")";
                    }

                    g.FillEllipse(culoareCurenta, varfuri[i].X - 5, varfuri[i].Y - 5, 10, 10);
                    g.DrawString(label, fontText, culoareCurenta, varfuri[i].X + 8, varfuri[i].Y - 8);
                }
            }
            else
            {
                foreach (var p in varfuri) g.FillEllipse(Brushes.Black, p.X - 4, p.Y - 4, 8, 8);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
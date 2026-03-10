using System;
using System.Drawing;
using System.Windows.Forms;

namespace Seminaru2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Triunghi de Arie Minimă - Random";
            this.Size = new Size(800, 600);
            Button btnGenereaza = new Button();
            btnGenereaza.Text = "Generează Puncte";
            btnGenereaza.Location = new Point(10, 10);
            btnGenereaza.Width = 150;
            btnGenereaza.Click += BtnGenereaza_Click;
            this.Controls.Add(btnGenereaza);
        }

        private void BtnGenereaza_Click(object sender, EventArgs e)
        {
            Point[] puncte = new Point[40];
            Random rnd = new Random();

            for (int i = 0; i < 40; i++)
            {
                puncte[i] = new Point(rnd.Next(50, 700), rnd.Next(50, 500));
            }
            double minArie = double.MaxValue;
            Point[] triunghi = new Point[3];

            for (int i = 0; i < puncte.Length; i++)
            {
                for (int j = i + 1; j < puncte.Length; j++)
                {
                    for (int k = j + 1; k < puncte.Length; k++)
                    {
                        Point p1 = puncte[i], p2 = puncte[j], p3 = puncte[k];
                        double arie = 0.5 * Math.Abs(p1.X * (p2.Y - p3.Y) +
                                                     p2.X * (p3.Y - p1.Y) +
                                                     p3.X * (p1.Y - p2.Y));
                        if (arie > 300 && arie < minArie)
                        {
                            minArie = arie;
                            triunghi[0] = p1;
                            triunghi[1] = p2;
                            triunghi[2] = p3;
                        }
                    }
                }
            }

            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            foreach (Point p in puncte)
            {
                g.FillEllipse(Brushes.Black, p.X - 3, p.Y - 3, 6, 6);
            }
            g.DrawPolygon(new Pen(Color.Red, 3), triunghi);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

//using System;
//using System.Drawing;
//using System.Windows.Forms;

//namespace Seminaru2
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//            this.Text = "Cerc de Rază Minimă (Metoda Naivă O(n^4))";
//            this.Size = new Size(800, 600);

//            Button btnGenereaza = new Button();
//            btnGenereaza.Text = "Generează Puncte";
//            btnGenereaza.Location = new Point(10, 10);
//            btnGenereaza.Width = 150;
//            btnGenereaza.Click += BtnGenereaza_Click;

//            this.Controls.Add(btnGenereaza);
//        }

//        private void BtnGenereaza_Click(object sender, EventArgs e)
//        {

//            PointF[] puncte = new PointF[30];
//            Random rnd = new Random();

//            for (int i = 0; i < puncte.Length; i++)
//            {
//                puncte[i] = new PointF(rnd.Next(150, 650), rnd.Next(150, 450));
//            }

//            PointF centruOptim = new PointF(0, 0);
//            float razaOptima = float.MaxValue;
//            for (int i = 0; i < puncte.Length; i++)
//            {
//                for (int j = i + 1; j < puncte.Length; j++)
//                {
//                    PointF centru = new PointF((puncte[i].X + puncte[j].X) / 2f, (puncte[i].Y + puncte[j].Y) / 2f);
//                    float raza = Distanta(puncte[i], puncte[j]) / 2f;
//                    if (raza < razaOptima && ContineToatePunctele(centru, raza, puncte))
//                    {
//                        razaOptima = raza;
//                        centruOptim = centru;
//                    }
//                }
//            }
//            for (int i = 0; i < puncte.Length; i++)
//            {
//                for (int j = i + 1; j < puncte.Length; j++)
//                {
//                    for (int k = j + 1; k < puncte.Length; k++)
//                    {
//                        PointF centru;
//                        float raza;

//                        if (CercDin3Puncte(puncte[i], puncte[j], puncte[k], out centru, out raza))
//                        {
//                            if (raza < razaOptima && ContineToatePunctele(centru, raza, puncte))
//                            {
//                                razaOptima = raza;
//                                centruOptim = centru;
//                            }
//                        }
//                    }
//                }
//            }
//            Graphics g = this.CreateGraphics();
//            g.Clear(this.BackColor);
//            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


//            if (razaOptima != float.MaxValue)
//            {
//                float diametru = razaOptima * 2;
//                g.DrawEllipse(new Pen(Color.Red, 2), centruOptim.X - razaOptima, centruOptim.Y - razaOptima, diametru, diametru);
//                g.FillEllipse(Brushes.Red, centruOptim.X - 3, centruOptim.Y - 3, 6, 6);
//            }
//            foreach (PointF p in puncte)
//            {
//                g.FillEllipse(Brushes.Black, p.X - 3, p.Y - 3, 6, 6);
//            }
//        }


//        private float Distanta(PointF p1, PointF p2)
//        {
//            return (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
//        }

//        private bool ContineToatePunctele(PointF centru, float raza, PointF[] puncte)
//        {
//            float toleranta = 0.01f; 
//            foreach (PointF p in puncte)
//            {
//                if (Distanta(centru, p) > raza + toleranta)
//                    return false;
//            }
//            return true;
//        }

//        private bool CercDin3Puncte(PointF A, PointF B, PointF C, out PointF centru, out float raza)
//        {
//            centru = new PointF(0, 0);
//            raza = 0;
//            float D = 2 * (A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y));
//            if (Math.Abs(D) < 0.001f) return false;

//            float Ax2y2 = A.X * A.X + A.Y * A.Y;
//            float Bx2y2 = B.X * B.X + B.Y * B.Y;
//            float Cx2y2 = C.X * C.X + C.Y * C.Y;

//            float cx = (Ax2y2 * (B.Y - C.Y) + Bx2y2 * (C.Y - A.Y) + Cx2y2 * (A.Y - B.Y)) / D;
//            float cy = (Ax2y2 * (C.X - B.X) + Bx2y2 * (A.X - C.X) + Cx2y2 * (B.X - A.X)) / D;

//            centru = new PointF(cx, cy);
//            raza = Distanta(centru, A);
//            return true;
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}
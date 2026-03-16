using System;
using System.Drawing;
using System.Windows.Forms;

namespace Seminar3
{
    public partial class Form1 : Form
    {
        public PointF[] puncte;
        public int numarPuncte = 20;

        public Form1()
        {
            InitializeComponent();


            puncte = new PointF[numarPuncte];
            Random rnd = new Random();
            for (int i = 0; i < numarPuncte; i++)
            {
                
                float x = rnd.Next(50, this.ClientSize.Width - 50);
                float y = rnd.Next(50, this.ClientSize.Height - 50);
                puncte[i] = new PointF(x, y);
            }

            Unicrossing();
            this.Paint += Form1_Paint;
        }

        private double ProdusIncrucisat(PointF a, PointF b, PointF p)
        {
            return (b.X - a.X) * (p.Y - a.Y) - (b.Y - a.Y) * (p.X - a.X);
        }
        private bool Intersection(PointF A, PointF B, PointF C, PointF D)
        {
            double dir1 = ProdusIncrucisat(A, B, C);
            double dir2 = ProdusIncrucisat(A, B, D);
            double dir3 = ProdusIncrucisat(C, D, A);
            double dir4 = ProdusIncrucisat(C, D, B);
            if ((dir1 * dir2 < 0) && (dir3 * dir4 < 0))
            {
                return true;
            }
            return false;
        }
        private void Unicrossing()
        {
            bool modify = true;

            while (modify)
            {
                modify = false;

                for (int i = 0; i < puncte.Length - 1; i += 2)
                {
                    for (int j = i + 2; j < puncte.Length - 1; j += 2)
                    {
                        if (Intersection(puncte[i], puncte[i + 1], puncte[j], puncte[j + 1]))
                        {
                           
                            PointF temp = puncte[i + 1];
                            puncte[i + 1] = puncte[j];
                            puncte[j] = temp;

                            modify = true; 
                        }
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
                if (p != PointF.Empty)
                    g.FillEllipse(pensulaPuncte, p.X - raza, p.Y - raza, raza * 2, raza * 2);
            }

            
            Pen stilouLinii = new Pen(Color.Blue, 2);
            for (int i = 0; i < puncte.Length - 1; i += 2)
            {
                if (puncte[i] != PointF.Empty && puncte[i + 1] != PointF.Empty)
                    g.DrawLine(stilouLinii, puncte[i], puncte[i + 1]);
            }
        }
       private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
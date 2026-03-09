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
//            this.Text = "Triunghi de Arie Minimă - Random";
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
//            Point[] puncte = new Point[40];
//            Random rnd = new Random();

//            for (int i = 0; i < 40; i++)
//            {
//                puncte[i] = new Point(rnd.Next(50, 700), rnd.Next(50, 500));
//            }
//            double minArie = double.MaxValue;
//            Point[] triunghi = new Point[3];

//            for (int i = 0; i < puncte.Length; i++)
//            {
//                for (int j = i + 1; j < puncte.Length; j++)
//                {
//                    for (int k = j + 1; k < puncte.Length; k++)
//                    {
//                        Point p1 = puncte[i], p2 = puncte[j], p3 = puncte[k];
//                        double arie = 0.5 * Math.Abs(p1.X * (p2.Y - p3.Y) +
//                                                     p2.X * (p3.Y - p1.Y) +
//                                                     p3.X * (p1.Y - p2.Y));
//                        if (arie > 300 && arie < minArie)
//                        {
//                            minArie = arie;
//                            triunghi[0] = p1;
//                            triunghi[1] = p2;
//                            triunghi[2] = p3;
//                        }
//                    }
//                }
//            }

//            Graphics g = this.CreateGraphics();
//            g.Clear(this.BackColor);
//            foreach (Point p in puncte)
//            {
//                g.FillEllipse(Brushes.Black, p.X - 3, p.Y - 3, 6, 6);
//            }
//            g.DrawPolygon(new Pen(Color.Red, 3), triunghi);
//        }
//        private void Form1_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}

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
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

//namespace Seminar6
//{
//    public partial class Form1 : Form
//    {
//        public List<PointF> puncte;
//        public int n = 10;

//        public Form1()
//        {
//            InitializeComponent();

//            puncte = new List<PointF>();
//            Random rnd = new Random();

//            for (int i = 0; i < n; i++)
//            {
//                float x = rnd.Next(50, this.ClientSize.Width - 50);
//                float y = rnd.Next(50, this.ClientSize.Height - 50);
//                puncte.Add(new PointF(x, y));
//            }

//            OrdoneazaPentruPoligonSimplu();

//            this.Paint += Form1_Paint;
//        }

//        private void OrdoneazaPentruPoligonSimplu()
//        {
//            float centruX = puncte.Average(p => p.X);
//            float centruY = puncte.Average(p => p.Y);

//            puncte = puncte.OrderBy(p => Math.Atan2(p.Y - centruY, p.X - centruX)).ToList();
//        }

//        private void Form1_Paint(object sender, PaintEventArgs e)
//        {
//            Graphics g = e.Graphics;
//            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

//            Pen stilouLinii = new Pen(Color.Blue, 2);
//            Brush pensulaText = new SolidBrush(Color.Black);
//            Brush pensulaPunct = Brushes.Red;
//            Font fontText = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

//            int raza = 4;

//            for (int i = 0; i < n; i++)
//            {
//                PointF curent = puncte[i];
//                PointF urmator = puncte[(i + 1) % n];

//                g.DrawLine(stilouLinii, curent, urmator);
//                g.FillEllipse(pensulaPunct, curent.X - raza, curent.Y - raza, raza * 2, raza * 2);
//                g.DrawString(i.ToString(), fontText, pensulaText, curent.X + 5, curent.Y + 5);
//            }
//        }
//        private void Form1_Load(object sender, EventArgs e)
//        { }
//    }
//}

//
namespace Seminar6
{
    public partial class Form1 : Form
    {
        public List<PointF> puncte;
        public int n = 10;

        public Form1()
        {
            InitializeComponent();

            puncte = new List<PointF>();
            Random rnd = new Random();

            List<double> unghiuri = new List<double>();
            for (int i = 0; i < n; i++)
            {
                unghiuri.Add(rnd.NextDouble() * 2 * Math.PI);
            }
            unghiuri.Sort();

            float centruX = this.ClientSize.Width / 2f;
            float centruY = this.ClientSize.Height / 2f;
            float raza = Math.Min(centruX, centruY) - 50;

            if (raza <= 0) raza = 150;

            foreach (double u in unghiuri)
            {
                float x = centruX + raza * (float)Math.Cos(u);
                float y = centruY + raza * (float)Math.Sin(u);
                puncte.Add(new PointF(x, y));
            }

            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen stilouLinii = new Pen(Color.Blue, 2);
            Pen stilouTriangulare = new Pen(Color.Green, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            Brush pensulaText = new SolidBrush(Color.Black);
            Brush pensulaPunct = Brushes.Red;
            Font fontText = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

            int razaPunct = 4;

            for (int i = 0; i < n; i++)
            {
                PointF curent = puncte[i];
                PointF urmator = puncte[(i + 1) % n];

                g.DrawLine(stilouLinii, curent, urmator);
                g.FillEllipse(pensulaPunct, curent.X - razaPunct, curent.Y - razaPunct, razaPunct * 2, razaPunct * 2);
                g.DrawString(i.ToString(), fontText, pensulaText, curent.X + 5, curent.Y + 5);
            }

            for (int i = 2; i < n - 1; i++)
            {
                g.DrawLine(stilouTriangulare, puncte[0], puncte[i]);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
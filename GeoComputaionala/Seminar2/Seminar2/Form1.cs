using System.Security.Cryptography.Pkcs;

namespace Seminar2
{
    public partial class Form1 : Form
    {
        private List<PointF> puncte;
        private PointF P1, P2, P3, P4;
        public Form1()
        {
           

            InitializeComponent();

            
            puncte = new List<PointF>
            {
                new PointF(150, 200),
                new PointF(300, 100),
                new PointF(450, 300),
                new PointF(200, 400),
                new PointF(500, 250),
                new PointF(250, 320),
                new PointF(175, 340),
                new PointF(280, 180),
                new PointF(540, 460)
            };
            Extreme();
           
        }

        private void Extreme()
        {
            float minX = puncte[0].X;
            float maxX = puncte[0].X;
            float minY = puncte[0].Y;
            float maxY = puncte[0].Y;

            foreach (PointF p in puncte)
            {
                if (p.X < minX) minX = p.X;
                if (p.X > maxX) maxX = p.X;
                if (p.Y < minY) minY = p.Y;
                if (p.Y > maxY) maxY = p.Y;
            }

            P1 = new PointF(minX, minY);
            P2 = new PointF(maxX, minY);
            P3 = new PointF(maxX, maxY);
            P4 = new PointF(minX, maxY);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Green, 2);
            
            g.DrawLine(p, P1, P2);
            g.DrawLine(p, P2, P3);
            g.DrawLine(p, P3, P4);
            g.DrawLine(p, P4, P1);
            foreach (PointF points in puncte)
            {
                g.FillEllipse(Brushes.Blue, points.X - 4, points.Y - 4, 8, 8);
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using static Seminar3.Form1;

namespace Seminar3
{
    //public partial class Form1 : Form
    //{
    //    public PointF[] puncte;
    //    public int numarPuncte = 20;

    //    public Form1()
    //    {
    //        InitializeComponent();


    //        puncte = new PointF[numarPuncte];
    //        Random rnd = new Random();
    //        for (int i = 0; i < numarPuncte; i++)
    //        {
                
    //            float x = rnd.Next(50, this.ClientSize.Width - 50);
    //            float y = rnd.Next(50, this.ClientSize.Height - 50);
    //            puncte[i] = new PointF(x, y);
    //        }

    //        Unicrossing();
    //        this.Paint += Form1_Paint;
    //    }

    //    private double ProdusIncrucisat(PointF a, PointF b, PointF p)
    //    {
    //        return (b.X - a.X) * (p.Y - a.Y) - (b.Y - a.Y) * (p.X - a.X);
    //    }
    //    private bool Intersection(PointF A, PointF B, PointF C, PointF D)
    //    {
    //        double dir1 = ProdusIncrucisat(A, B, C);
    //        double dir2 = ProdusIncrucisat(A, B, D);
    //        double dir3 = ProdusIncrucisat(C, D, A);
    //        double dir4 = ProdusIncrucisat(C, D, B);
    //        if ((dir1 * dir2 < 0) && (dir3 * dir4 < 0))
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //    private void Unicrossing()
    //    {
    //        bool modify = true;

    //        while (modify)
    //        {
    //            modify = false;

    //            for (int i = 0; i < puncte.Length - 1; i += 2)
    //            {
    //                for (int j = i + 2; j < puncte.Length - 1; j += 2)
    //                {
    //                    if (Intersection(puncte[i], puncte[i + 1], puncte[j], puncte[j + 1]))
    //                    {
                           
    //                        PointF temp = puncte[i + 1];
    //                        puncte[i + 1] = puncte[j];
    //                        puncte[j] = temp;

    //                        modify = true; 
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    private void Form1_Paint(object sender, PaintEventArgs e)
    //    {
    //        Graphics g = e.Graphics;
    //        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

    //        Brush pensulaPuncte = Brushes.Red;
    //        int raza = 4;

    //        foreach (PointF p in puncte)
    //        {
    //            if (p != PointF.Empty)
    //                g.FillEllipse(pensulaPuncte, p.X - raza, p.Y - raza, raza * 2, raza * 2);
    //        }

            
    //        Pen stilouLinii = new Pen(Color.Blue, 2);
    //        for (int i = 0; i < puncte.Length - 1; i += 2)
    //        {
    //            if (puncte[i] != PointF.Empty && puncte[i + 1] != PointF.Empty)
    //                g.DrawLine(stilouLinii, puncte[i], puncte[i + 1]);
    //        }
    //    }
    //   private void Form1_Load(object sender, EventArgs e)
    //    {

    //    }
    //}

    public partial class Form1 : Form
    {

        

        public List<Segment> segmente;
        public List<PointF> puncteIntersectie;
        public int numarSegmente = 15;
        public class Event
        {
            public Segment Seg;
            public bool IsStart;
        }
        public class Segment
        {
            public PointF Start;
            public PointF End;

            public Segment(PointF p1, PointF p2)
            {
                if (p1.X <= p2.X) { Start = p1; End = p2; }
                else { Start = p2; End = p1; }
            }
        }
        public Form1()
        {
            InitializeComponent();
            segmente = new List<Segment>();
            puncteIntersectie = new List<PointF>();
            Random rnd = new Random();
            for (int i = 0; i < numarSegmente; i++)
            {
                float x1 = rnd.Next(50, this.ClientSize.Width - 50);
                float y1 = rnd.Next(50, this.ClientSize.Height - 50);
                float x2 = rnd.Next(50, this.ClientSize.Width - 50);
                float y2 = rnd.Next(50, this.ClientSize.Height - 50);

                segmente.Add(new Segment(new PointF(x1, y1), new PointF(x2, y2)));
            }
            SweepLine();
            this.Paint += Form1_Paint;
        }

        public void SweepLine()
        {
            SortedList<double, Event> agendaLaserului = new SortedList<double, Event>();
            foreach (var seg in segmente)
            {
                double xStart = seg.Start.X;
                while (agendaLaserului.ContainsKey(xStart)) {
                    xStart += 0.0001;
                        }
                agendaLaserului.Add(xStart, new Event { Seg = seg, IsStart = true });
                double xEnd = seg.End.X;
                while (agendaLaserului.ContainsKey(xEnd)) xEnd += 0.0001;
                agendaLaserului.Add(xEnd, new Event { Seg = seg, IsStart = false });
            }
            List<Segment> beteSubLaser = new List<Segment>();

            foreach (var ev in agendaLaserului.Values)
            {
                if (ev.IsStart)
                {
                    foreach (var batExistent in beteSubLaser)
                    {
                        if (SeIntersecteaza(ev.Seg.Start, ev.Seg.End, batExistent.Start, batExistent.End))
                        {
                            puncteIntersectie.Add(CalculeazaPunctIntersectie(ev.Seg, batExistent));
                        }
                    }
                    beteSubLaser.Add(ev.Seg);
                }
                else
                {
                    beteSubLaser.Remove(ev.Seg);
                }

            }
        }
        private double ProdusIncrucisat(PointF a, PointF b, PointF p)
        {
            return (b.X - a.X) * (p.Y - a.Y) - (b.Y - a.Y) * (p.X - a.X);
        }
        private bool SeIntersecteaza(PointF A, PointF B, PointF C, PointF D)
        {
            double dir1 = ProdusIncrucisat(A, B, C);
            double dir2 = ProdusIncrucisat(A, B, D);
            double dir3 = ProdusIncrucisat(C, D, A);
            double dir4 = ProdusIncrucisat(C, D, B);

            if ((dir1 * dir2 < 0) && (dir3 * dir4 < 0))
                return true;

            return false;
        }
        private PointF CalculeazaPunctIntersectie(Segment s1, Segment s2)
        {
            float x1 = s1.Start.X, y1 = s1.Start.Y;
            float x2 = s1.End.X, y2 = s1.End.Y;
            float x3 = s2.Start.X, y3 = s2.Start.Y;
            float x4 = s2.End.X, y4 = s2.End.Y;

            float den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (den == 0) return PointF.Empty;

            float numX = (x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4);
            float numY = (x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4);

            return new PointF(numX / den, numY / den);
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen stilouLinii = new Pen(Color.Blue, 2);
            foreach (var seg in segmente)
            {
                g.DrawLine(stilouLinii, seg.Start, seg.End);
            }

            Brush pensulaIntersectii = Brushes.Red;
            int raza = 5;
            foreach (PointF p in puncteIntersectie)
            {
                if (p != PointF.Empty)
                    g.FillEllipse(pensulaIntersectii, p.X - raza, p.Y - raza, raza * 2, raza * 2);
            }
        }

    }
    


}
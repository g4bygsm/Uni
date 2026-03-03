
// Se dau 5 numere random [2,14]
// Sa se afiseze unul dintre urmatoarele cazuri:
//a) E 2 valori identice (3,8,3,7,12)
//b) E 2 cate 2 valori identice (8,7,3,7,8)
//c) E 3 valori identice(2,2,7,8,2)
//d) E 3 valori identice si 2 identice (9,7,9,7,7)
//e) E 4 valori identice
//f) E 5 valori identice
//g) E 0 valori identice


namespace Proj2
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        public int cr = 0;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2200; i++)
            {

                cr--;
                Card a = new Card();
                Card b = new Card();
                Card c = new Card();
                Card d = new Card();
                Card x = new Card();
                int id = 0;
                if (a.value == b.value) id++;
                if (a.value == c.value) id++;
                if (a.value == d.value) id++;
                if (a.value == x.value) id++;
                if (b.value == c.value) id++;
                if (b.value == d.value) id++;
                if (b.value == x.value) id++;
                if (c.value == d.value) id++;
                if (c.value == x.value) id++;
                if (d.value == x.value) id++;

                switch (id)
                {
                    case 0:
                        label1.Text = "Nem";
                        break;
                    case 1:
                        label1.Text = "O parechi";
                        cr++;
                        break;
                    case 2:
                        label1.Text = "Deux cate deux parechi";
                        cr ++;
                        break;
                    case 3:
                        label1.Text = "trii";
                        cr ++;
                        break;
                    case 4:
                        label1.Text = "3 cu 2";
                        cr += 5;
                        break;

                    case 6:
                        label1.Text = "Spatru ma";
                        cr += 10;
                        break;
                    case 10:
                        label1.Text = "CINCIU BAAA";
                        cr += 100;
                        break;
                }
                label2.Text = a.Filename() + " " + b.value + " " + c.value + " " + d.value + " " + x.value;
                label3.Text = cr.ToString();
            }
            cr = 0;
        }
        class Card
        {
            public int value;
            public int color;
            public string Filename()
            {
                return color.ToString("00") + value.ToString("00") + ".png";
            }
            public static Random rnd = new Random();
            public Card()
            {
                value = rnd.Next(2, 15);
                color = rnd.Next(4);
            }
        }
    }
}

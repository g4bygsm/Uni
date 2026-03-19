
//// 1. Sa se creeze un tip de date definit de utilizator (clasa) numit DATE pt reprezentarea
//// datei calendaristice sub forma zi,luna,an(triplet). Pt acest tip de date sa se implementeze
//// operatorii relationali precum si o operatie pt determinarea diferentei in nr de zile dintre
//// 2 date. Se vor utiliza 2 modalitati de initializare a unui obiect de tip DATE ,
//// date cu zi,luna,an si date zi.luna.an

//using System.ComponentModel.Design.Serialization;
//using System.Text;

//namespace Date
//{
//    class Date
//    {
//        private int zi, luna, an;

//        public Date(int zi, int luna, int an)
//        {
//            this.zi = zi;
//            this.luna = luna;
//            this.an = an;
//        }
//        public Date(string s)
//        {
//            char[] separator = { ',', '/', ':' };
//            string[] x = s.Split(separator);

//            if (x.Length != 3)
//            {
//                Console.WriteLine("Data incorecta!");
//            }
//            else
//            {
//                this.zi = Convert.ToInt32(x[0]);
//                this.luna = Convert.ToInt32(x[1]);
//                this.an = Convert.ToInt32(x[2]);
//            }
//        }
//        public override string ToString()
//        {
//            //StringBuilder s = new StringBuilder();
//            //s.AppendFormat("{0}.{1}.{2}", zi, luna, an);
//            //return s.ToString();
//            return zi.ToString() + ":" + luna.ToString() + ":" + an.ToString();
//        }

//        public static int GetDays(Date d)
//        {
//            int i, zile = 0;

//            for (i = 1; i < d.an; i++)
//            {
//                zile += (DateTime.IsLeapYear(i)) ? 366 : 365;
//            }
//            for (i = 1; i < d.luna; i++)
//            {
//                zile += DateTime.DaysInMonth(d.an, i);
//            }
//            zile += d.zi;
//            return zile;
//        }

//        public static int operator -(Date d1, Date d2)
//        {
//            return Math.Abs(GetDays(d1) - GetDays(d2));
//        }

//        public static bool operator ==(Date d1, Date d2)
//        {
//            if ((d1.an == d2.an) && (d1.luna == d2.luna) && (d1.zi == d2.zi)) return true;
//            return false;
//        }
//        public static bool operator !=(Date d1, Date d2)
//        {
//            if (d1 == d2) return false;
//            return true;
//        }

//        public static bool operator <(Date d1, Date d2)
//        {
//            if (d1.an < d2.an) return true;
//            if ((d1.an == d2.an) && (d1.luna < d2.luna)) return true;
//            if ((d1.an == d2.an) && (d1.luna == d2.luna) && (d1.zi < d2.zi)) return true;
//            return false;
//        }
//        public static bool operator <=(Date d1, Date d2)
//        {
//            if (d1 < d2 || d1 == d2) return true;
//            return false;
//        }
//        public static bool operator >(Date d1, Date d2)
//        {
//            return !(d1 <= d2);
//        }
//        public static bool operator >=(Date d1, Date d2)
//        {
//            return !(d1 < d2);
//        }

//        static void Main()
//        {
//            Date d1 = new Date(19, 03, 2024);
//            Date d2 = new Date("19,05,2025");
//            Console.WriteLine($"Diferenta dintre data1 si data2 este de {d1-d2} zile");
//            if (d1 > d2)
//            {
//                Console.WriteLine("mai maroc");
//            }
//            if (d1 < d2)
//            {
//                Console.WriteLine("mai michitz");
//            }
//            if (d1 == d2)
//            {
//                Console.WriteLine("egal");
//            }
//        }
//    }
//}

// Sa se creeze un tip de date definit de utilizator numit Time pentru reprezentarea timpului
// sub forma ore: minute: secunde: sutimi: . Pentru acest tip de date sa se implementeze
// operatiile de adunare a doi timpi respectiv de scadere precum si operatorii relationali
// Se vor utiliza 4 modalitati de initializare a unui obiect de tip Time si anume: Time de
// ore/ minute sau cu 3 parametri, sau cu 4 sau cu string


using System.Text;

namespace Timpi
{
    class Time
    {
        private int ora, minut, secunda, sutime;
        public Time(int ora, int minut, int secunda = 0, int sutime = 0)
        {
            this.ora = ora;
            this.minut = minut;
            this.secunda = secunda;
            this.sutime = sutime;
        }

        // valori implicite pentru parametri, atunci se poate apela cu 2, cu 3 sau cu 4 parametri

        public Time(string s)
        {
            char[] separator = { ',', '/', ':' };
            string[] x = s.Split(separator);

            if (x.Length != 4)
            {
                Console.WriteLine("Timp incomplet!");
            }
            else
            {
                this.ora = Convert.ToInt32(x[0]);
                this.minut = Convert.ToInt32(x[1]);
                this.secunda = Convert.ToInt32(x[2]);
                this.sutime = Convert.ToInt32(x[3]);
            }
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}:{1}:{2}:{3}", ora, minut, secunda, sutime);
            return s.ToString();
        }
        public static Time operator +(Time t1, Time t2)
        {
            Time t = new Time(0, 0);
            int k;
            t.sutime = (t1.sutime + t2.sutime) % 100 ;
            k= (t1.sutime + t2.sutime) / 100 ;
            t.secunda = (t1.secunda + t2.secunda + k) % 60 ;
            k = (t1.secunda + t2.secunda + k) / 60 ;
            t.minut = (t1.minut + t2.minut + k) % 60 ;
            k = (t1.minut + t2.minut + k) / 60;
            t.ora = t1.ora + t2.ora + k;
            return t;
        }

        static void Main()
        {
            Time t1 = new Time("12,03,34,09");
            Time t2 = new Time(5, 12, 10, 57);
            Console.WriteLine(t1 + t2);
        }


    }
}
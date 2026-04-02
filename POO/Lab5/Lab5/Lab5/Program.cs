// Sa se creeze un tip de date definit de utilizator pentru lucrul cu numere complexe. Sa se implementeze
// pentru acest tip operatiile de ad,sc si inmultire a doua nr complexe, ridicarea la putere si afisarea 
//in forma trigonometrica a unui nr complex. Un obiect de tipul Complex va putea fi initializat in 3 moduri
// : Complex(), Complex(parte_reala), Complex(parte_reala, parte_imaginara);





//using System.Text;

//namespace Lab5
//{
//    public class Complex
//    {
//        private double re, im;

//        public Complex(double re = 0.0, double im = 0.0)
//        {
//            this.re = re;
//            this.im = im;
//        }
//        public override string ToString()
//        {
//            StringBuilder s = new StringBuilder();
//            if (im > 0)
//            {
//                s.AppendFormat($"{re:0.00} + {im:0.00}i");
//            }
//            else
//            {
//                if (im < 0)
//                {
//                    s.AppendFormat($"{re:0.00} - {Math.Abs(im):0.00}i");
//                }
//                else
//                {
//                    s.AppendFormat($"{re:0.00}");
//                }
//            }
//            return s.ToString();
//        }


//        public static Complex operator +(Complex c1, Complex c2)
//        {
//            return new Complex(c1.re + c2.re, c1.im + c2.im);
//        }
//        public static Complex operator -(Complex c1, Complex c2)
//        {
//            return new Complex(c1.re - c2.re, c1.im - c2.im);
//        }

//        public static Complex operator *(Complex c1, Complex c2)
//        {
//            return new Complex(c1.re * c2.re - c1.im * c2.im, c1.re * c2.im + c1.im * c2.re);
//        }

//        public static Complex operator ^(Complex c1, int k)
//        {
//            if (k < 0 || (k == 0 && c1.re == 0 && c1.im == 0))
//            {
//                return new Complex();
//            }
//            if (k == 0 && (c1.re != 0 || c1.im != 0))
//            {
//                return new Complex(1);
//            }

//            Complex c2 = new Complex(c1.re, c1.im);
//            for (int i = 1; i < k; i++)
//            {
//                c2 = c2 * c1;
//            }
//            return c2;

//        }

//        public string trigo()
//        {
//            double r = Math.Sqrt(Math.Pow(re, 2) + Math.Pow(im, 2));
//            double fi = Math.Atan(im / re);
//            return String.Format($"{r:0.00}") + " (cos " + String.Format($"{fi:0.00}") + " + i * sin " + String.Format($"{fi:0.00}") + " )";
//        }
//    }

//    class Test
//    {

//        public static void Main()
//        {
//            Complex c1 = new Complex(1.7, 2.3);
//            Complex c2 = new Complex(1.3, -2.7);

//            Console.WriteLine($"x = {c1}");
//            Console.WriteLine($"y = {c2}");

//            Console.WriteLine($"x + y = {c1 + c2}");
//            Console.WriteLine($"x - y = {c1 - c2}");
//            Console.WriteLine($"x * y = {c1 * c2}");
//            int k = 3;
//            Console.WriteLine($"x ^ {k} = {c1 ^ k}");
//            Console.WriteLine($"Forma Trigonometrica: x = { c1.trigo()}");
//            Console.WriteLine($"Forma Trigonometrica: y = { c2.trigo()}");




//        }
//    }
//}



// Sa se implementeze un tip de date pentru lucrul cu nr rationale (numarator/numitor). Sa se defineasca 
// pentru acest tip operatiile de ad, sc, inm, imp, ridicare la put, operatorii relationali, precum si o 
// operatie pentru aducerea fractiei la forma ireductibila,(simplificare). Un astfel de obiect va putea fi
// initializat in 3 moduri: Rational(), Rational(numarator), Rational(numarator, numitor).



using System;
using System.Text;

namespace Lab5
{
    public class Rational
    {
        private int numarator, numitor;

        public Rational(int numarator, int numitor)
        {
            if (numitor == 0)
            {
                this.numitor = 1;
            }
            else
            {
                this.numitor = Math.Abs(numitor);
            }

            this.numarator = (numitor < 0) ? -numarator : numarator;
            this.ireductibil();
        }

        public void ireductibil()
        {
            int k = cmmdc(Math.Abs(numarator), numitor);
            numarator /= k;
            numitor /= k;
        }

        static int cmmdc(int a, int b)
        {
            if (b == 0) return a;
            return cmmdc(b, a % b);
        }

        public override string ToString()
        {
            if (numarator == 0) return "0";
            if (numitor == 1) return numarator.ToString();
            return $"{numarator}/{numitor}";
        }

        public static Rational operator +(Rational r1, Rational r2) =>
            new Rational(r1.numarator * r2.numitor + r2.numarator * r1.numitor, r1.numitor * r2.numitor);

        public static Rational operator -(Rational r1, Rational r2) =>
            new Rational(r1.numarator * r2.numitor - r2.numarator * r1.numitor, r1.numitor * r2.numitor);

        public static Rational operator *(Rational r1, Rational r2) =>
            new Rational(r1.numarator * r2.numarator, r1.numitor * r2.numitor);

        public static Rational operator /(Rational r1, Rational r2) =>
            new Rational(r1.numarator * r2.numitor, r1.numitor * r2.numarator);

        public static Rational operator ^(Rational r1, int k)
        {
            if (k < 0)
                return new Rational((int)Math.Pow(r1.numitor, -k), (int)Math.Pow(r1.numarator, -k));
            return new Rational((int)Math.Pow(r1.numarator, k), (int)Math.Pow(r1.numitor, k));
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            return r1.numarator == r2.numarator && r1.numitor == r2.numitor;
        }

        public static bool operator !=(Rational r1, Rational r2) => !(r1 == r2);

        public static bool operator <(Rational r1, Rational r2)
        {
            return r1.numarator * r2.numitor < r2.numarator * r1.numitor;
        }

        public static bool operator >(Rational r1, Rational r2) => r2 < r1;

        public static bool operator <=(Rational r1, Rational r2) => !(r1 > r2);

        public static bool operator >=(Rational r1, Rational r2) => !(r1 < r2);

       

        public override int GetHashCode()
        {
            return HashCode.Combine(numarator, numitor);
        }
    }

    class Test
    {
        public static void Main()
        {
            Rational r1 = new Rational(1, 2);
            Rational r2 = new Rational(3, 4);

            Console.WriteLine($"x = {r1}, y = {r2}");
            Console.WriteLine($"x == y: {r1 == r2}");
            Console.WriteLine($"x != y: {r1 != r2}");
            Console.WriteLine($"x < y:  {r1 < r2}");
            Console.WriteLine($"x > y:  {r1 > r2}");
            Console.WriteLine($"x <= y: {r1 <= r2}");
            Console.WriteLine($"x >= y: {r1 >= r2}");
        }
    }
}

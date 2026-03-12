//using System;

//namespace Lab2
//{
//    internal class Hello
//    {
//        // camp static
//        static int index = 0;

//        //constructor instanta
//        public Hello()
//        {

//            Console.WriteLine("Hello World!");
//        }
//        // constructor static
//        static Hello()
//        {
//            index++;
//        }
//        //destructor

//        ~Hello()
//        {
//            Console.WriteLine("Goodbye, World!");
//        }

//        public static int get_index()
//        {
//            return index;
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Hello hw1 = new Hello();
//            Console.WriteLine($"Index = {Hello.get_index()}");
//            Hello hw2 = new Hello();
//            Console.WriteLine($"Index = {Hello.get_index()}");
//        }
//    }
//}

// APLICATIA 1

// Sa se implementeze o clasa care sa contina operatiile definite
// ca metode de adunare scadere inmultire impartire a doua nr reale

//using System;

//namespace proj
//{
//    class NrReale
//    {
//        public double x, y;

//        public NrReale(double x = 0, double y = 0) 
//        {
//            this.x = x;
//            this.y = y;
//        }

//        public double suma()
//        {
//            return x + y;
//        }

//        public double dif()
//        {
//            return x - y;
//        }

//        public double prod()
//        { 
//            return x * y; 
//        }

//        public double imp()
//        {
//            return x / y;
//        }
//    }

//    internal class Program
//    {
//        static void Main()
//        {
//            NrReale n = new NrReale(20.2, 30.3);
//            n.x = 5;
//            Console.WriteLine(n.suma());
//        }
//    }
//}


//APLICATIA 2

// Sa se scrie un program orientat pe obiect care sa afiseze urmatoarele linii
// *
// **
// ***
// ****


// Numarul de linii va fi dat ca parametru al constructorului
// clasei iar afisarea stelutelor se va face intr-o metoda


//using System;

//namespace apl2
//{
//    class Star
//    {
//        int lines;

//        Star(int lines)
//        {
//            this.lines = lines;
//        }

//        void Draw()
//        {
//            for (int i = 0; i <= lines; i++)
//            {
//                for (int j = 1; j <= i; j++)
//                {
//                    Console.Write('*');
//                }
//                Console.WriteLine();
//            }
//        }

//        static void Main()
//            {
//                Star s = new Star(10);
//                s.Draw();
//            }
//    }
//}


//APLICATIA 3

// Se considera clasa dreptunghi avand caracteristicile lungime si latime; sa se scrie un
// constructor, o proprietate si o auto-proprietate si sa se calculeze aria in main prin 
// intermediul proprietatilor.


namespace apl3
{
    class Rectangle
    {
        int lungime;
        int Latime { get; set; }

        public Dreptunghi(int L=0, int l=0)
        {
            lungime = L;
            Latime = l;
        }
        public int Lungime
        {
            get { return lungime; }
            set { if(value > 0) lungime = value; }
        }
        static void Main()
        {
            Rectangle d = new Rectangle();
            d.Lungime = 50;
            d.Latime = 10;
            Console.WriteLine("Aria = " + d.Lungime *  d.Latime);
        }
    }
}
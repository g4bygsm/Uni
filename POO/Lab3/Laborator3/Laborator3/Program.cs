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

// Sa se implementeze o clasa care sa contina operatiile definite
// ca metode de adunare scadere inmultire impartire a doua nr reale

using System;

namespace proj
{
    class NrReale
    {
        public double x, y;
        
        public NrReale(double x = 0, double y = 0) 
        {
            this.x = x;
            this.y = y;
        }

        public double suma()
        {
            return x + y;
        }
    }

    internal class Program
    {
        static void Main()
        {
            NrReale n = new NrReale(20.2, 30.3);
            n.x = 5;
            Console.WriteLine(n.suma());
        }
    }
}
using System;

namespace Lab2
{
    internal class Hello
    {
        // camp static
        static int index = 0;

        //constructor instanta
        public Hello()
        {
            
            Console.WriteLine("Hello World!");
        }
        // constructor static
        static Hello()
        {
            index++;
        }
        //destructor

        ~Hello()
        {
            Console.WriteLine("Goodbye, World!");
        }

        public static int get_index()
        {
            return index;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hello hw1 = new Hello();
            Console.WriteLine($"Index = {Hello.get_index()}");
            Hello hw2 = new Hello();
            Console.WriteLine($"Index = {Hello.get_index()}");
        }
    }
}
using System;

namespace Lab2
{
    internal class Hello
    {
        static int index = 0;
        public Hello()
        {
            index++;
            Console.WriteLine($"index={index}");
            Console.WriteLine("Hello World!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hello h1 = new Hello();
            Hello h2 = new Hello();
        }
    }
}
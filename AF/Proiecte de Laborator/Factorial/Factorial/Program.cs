using System;

namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Afiseaza elementul 400 din Fibonacci
            Console.WriteLine(Fibonacci(400));

            Console.WriteLine();

            // Afiseaza 5000! (iterativ, ca sa nu crape memoria)
            Console.WriteLine(Factorial(5000));

            // Opreste consola sa nu se inchida instant
            Console.ReadLine();
        }

        // Metoda ITERATIVA pentru Factorial (fara eroare de memorie)
        static BigNumber Factorial(int n)
        {
            if (n == 0 || n == 1)
                return new BigNumber(1);

            BigNumber result = new BigNumber(1);

            for (int i = 2; i <= n; i++)
            {
                result = result * new BigNumber(i);
            }

            return result;
        }

        // Metoda Fibonacci de la curs
        static BigNumber Fibonacci(int n)
        {
            BigNumber[] fibonacci = new BigNumber[n];
            fibonacci[0] = new BigNumber(1);
            fibonacci[1] = new BigNumber(1);

            for (int i = 2; i < n; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            return fibonacci[n - 1];
        }
    }
}
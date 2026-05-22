using System;

namespace Greedy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bancnote = [500, 200, 100, 50, 20, 10, 5, 1];

            Console.Write("Introduceti suma de bani: ");
            int suma = int.Parse(Console.ReadLine());

            int numarTotalBancnote = 0;

            Console.Write("Bancnotele folosite sunt: ");

            for (int i = 0; i < bancnote.Length; i++)
            {
                while (suma >= bancnote[i])
                {
                    suma -= bancnote[i];
                    numarTotalBancnote++;
                    Console.Write(bancnote[i] + " ");
                }
            }
                Console.WriteLine();
                Console.WriteLine("Numarul minim de bancnote obtinute este: " + numarTotalBancnote);
            }
        }
    }
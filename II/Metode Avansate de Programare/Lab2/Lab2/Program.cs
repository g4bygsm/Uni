using System;
namespace Backtracking
{
   
   
    //class Program
    //{
    //    static int n;
    //    static int[] sol;
    //    static bool[] visit;

    //    static void perm(int k)
    //    {
    //        if (k == n)
    //        {
    //            for (int i = 0; i < n; i++)
    //                Console.Write(sol[i] + " ");
    //            Console.WriteLine();
    //            return;
    //        }

    //        for (int i = 1; i <= n; i++)
    //        {
    //            if (!visit[i])
    //            {
    //                sol[k] = i;
    //                visit[i] = true;

    //                perm(k + 1);

    //                visit[i] = false;
    //            }
    //        }
    //    }

    //    static void Main()
    //    {
    //        n = 5;
    //        sol = new int[n];
    //        visit = new bool[n + 1];

    //        perm(0);
    //    }
    //}
    //class Program
    //{
    //    static int n, p;
    //    static int[] sol;
    //    static bool[] visit;

    //    static void aranj(int k)
    //    {
    //        if (k == p)
    //        {
    //            for (int j = 0; j < p; j++)
    //                Console.Write(sol[j] + " ");
    //            Console.WriteLine();
    //            return;
    //        }

    //        for (int i = 1; i <= n; i++)
    //        {
    //            if (!visit[i])
    //            {
    //                sol[k] = i;
    //                visit[i] = true;

    //                aranj(k + 1);

    //                visit[i] = false;
    //            }
    //        }
    //    }

    //    static void Main()
    //    {
    //        n = 4;
    //        p = 2;
    //        sol = new int[p];
    //        visit = new bool[n + 1];

    //        aranj(0);
    //    }
    //}
    //    class Program
    //    {
    //        static int n, p;
    //        static int[] sol;

    //        static void comb(int k)
    //        {
    //            if (k == p)
    //            {
    //                for (int j = 0; j < p; j++)
    //                    Console.Write(sol[j] + " ");
    //                Console.WriteLine();
    //                return;
    //            }

    //            int start = 1;
    //            if (k > 0)
    //            {
    //                start = sol[k - 1] + 1;
    //            }

    //            for (int i = start; i <= n; i++)
    //            {
    //                sol[k] = i;
    //                comb(k + 1);
    //            }
    //        }

    //        static void Main()
    //        {
    //            n = 4;
    //            p = 2;
    //            sol = new int[p];

    //            comb(0);
    //        }
    //    }


    class ColorareHarta
    {
        static int n;
        static int[,] a;
        static int[] sol;
        static int numarSolutii = 0;
        static void Citire(int n)
        {
            a = new int[n + 1, n + 1];
            sol = new int[n + 1];
            Console.WriteLine("Introdu vecinii fiecarei tari:");
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"{i}: ");
                string rand = Console.ReadLine();
                string[] numere = rand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach(string numar in numere)
                {
                    int vecin = int.Parse(numar);
                    a[i, vecin] = 1;
                    a[vecin, i] = 1;

                }
            }
            Console.WriteLine("Harta inregistrata, start colorare");
        }
        static void Colorare(int k)
        {
            if (k > n)
            {
                numarSolutii++;
                Console.WriteLine("--- Solutia numarul " + numarSolutii + " ---");
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine("Culoarea tarii " + i + " este: " + sol[i]);
                }
                Console.WriteLine();
                return;
            }
            for (int i = 1; i <= 4; i++)
            {
                sol[k] = i;
                bool valid = true;

                for (int j = 1; j < k; j++)
                {
                    if (a[k, j] == 1 && sol[k] == sol[j])   
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid)
                {
                    Colorare(k + 1);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Introdu numarul de tari: ");
            n = int.Parse(Console.ReadLine());
            Citire(n);
            Colorare(1);

        }
    }
    
}
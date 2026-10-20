using System;
namespace Backtracking
{
    class Program
    {
        static char[] sol;
        static int n;

        static void par(int k, int d, int i)
        {
            if (k == n)
            {
                Console.WriteLine(new String(sol));
                return;
            }
            if (d < n / 2)
            {
                sol[k] = '(';
                par(k + 1, d + 1, i);
            }
            if (i < d)
            {

                sol[k] = ')';
                par(k + 1, d, i + 1);
            }
        }

        static void Main(string[] args)
        {

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            if (n % 2 == 0)
            {
                sol = new char[n];
                par(0, 0, 0);
            }
            else
            {
                Console.WriteLine("!!! n este impar !!!");
            }
           
        }
    }
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
}
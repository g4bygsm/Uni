// Sa se creeze un tip de date pt lucrul cu matrici. Sa se implementeze operatiile de adunare, scadere, inmultire a 2 matrici,
// ridicarea la putere si determinarea inversei 

using System;
using System.Text;

namespace Lab6
{
    public class Matrice
    {
        private int n, m;
        private double[,] mat;

        public Matrice(int n = 0, int m = 0)
        {
            this.n = n;
            this.m = m;
            mat = new double[this.n, this.m];
            Random r = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    mat[i, j] = r.Next(10);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    s.AppendFormat($"{mat[i, j],11:0.00}");
                s.Append("\n");
            }
            return s.ToString();
        }

        private double det(double[,] a, int n)
        {
            int i, j;
            double d, e, aux;
            if (n == 1)
                return a[0, 0];
            else
            {
                d = 0.0;

                // dezvoltare dupa ultima linie
                6           for (i = 0; i < n; i++)
                {
                    // semnul interschimbarii
                    if (((n - 1 - j) % 2 == 1) || (j == n - 1))
                        e = a[n - 1, j];
                    else
                        e = -a[n - 1, j];
                    // interschimbarea coloanei curente cu ultima linie
                    for (i = 0; i < n - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                    // formula de calcul
                    if ((n - 1 + j) % 2 == 0)
                        d += e * det(a, n - 1);
                    else
                        d -= e * det(a, n - 1);
                    // refacem matricea initiala
                    for (i = 0; i < n; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                }
                return d;
            }
        }
    }
    public Matrice inversa()
        {
            if (this.n == this.m)
            {
                double d = this.det(this.mat, this.m);
                if (d != 0)
                {
                    Matrice rez = new Matrice(this.n, this.n);
                    Matrice temp = new Matrice(this.n, this.n);
                    // matricea transpusa
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            temp.mat[i, j] = mat[i, j];
                    double aux;
                    int semn;
                    matricea adjuncta
                        for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            // interschimbam linia i cu ultima linie (n-1)
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[i, k];
                            }
                        }
                }
            }
        }
    class Program
    {
        static void Main()
        {
            int n1 = 2, m1 = 2, n2 = 2, m2 = 2;
            Matrice a = new Matrice(n1, m1);
            Matrice b = new Matrice(n2, m2);
            Console.WriteLine("Matricea A\n{0}", a);
            Console.WriteLine("Matricea B\n{0}", b);
        }
    }
}
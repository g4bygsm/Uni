using System;
using System.Collections.Generic;

namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // =================================================================
            // 1. CODUL DE LA CURS (Matrice, Factorial, Fibonacci)
            // =================================================================

            // Declarare Matrice
            Random random = new Random();
            int n = 10, m = 8;
            int[,] matrix = new int[n, m];

            // Valori aleatorii
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = random.Next(1, 10);

            // Extindere + afisare
            Console.WriteLine("--- Matricea Extinsa ---");
            matrix = Extindere(matrix);
            for (int i = 0; i < 2 * n - 1; i++)
            {
                for (int j = 0; j < 2 * m - 1; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine("\n--- Fibonacci (pozitia 400) ---");
            Console.WriteLine(Fibonacci(400));

            // Nota: Factorial(5000) dureaza extrem de mult (minute bune) din cauza 
            // recursivitatii adanci pe numere mari. Daca vrei sa testezi rapid, 
            // poti lasa codul asa sau sa pui o valoare mai mica, de exemplu Factorial(100).
            Console.WriteLine("\n--- Calcul 5000! ---");
            Console.WriteLine("Se calculeaza 5000!... (Apasati Ctrl+C daca vreti sa treceti peste)");
            Console.WriteLine(Factorial(5000));


            // =================================================================
            // 2. REZOLVARE CERINTA EXERCIȚIULUI 4: Expresia E = suma(i^i) de la 1 la 255
            // =================================================================
            Console.WriteLine("\n==================================================");
            Console.WriteLine("INCEPEM CALCULUL EXPRESIEI E PENTRU TEMA...");
            Console.WriteLine("==================================================");

            BigNumber sumaE = new BigNumber(0);

            for (int i = 1; i <= 255; i++)
            {
                sumaE = sumaE + Power(i, i);

                // Afisam progresul din 50 in 50 ca sa stii ca programul lucreaza activ
                if (i % 50 == 0 || i == 255)
                {
                    Console.WriteLine($"[Progres] Calculat pana la termenul: {i}^{i}");
                }
            }

            Console.WriteLine("\n>>> CALCUL FINALIZAT CU SUCCES! <<<");
            Console.WriteLine("Rezultatul complet al expresiei E este urmatorul numar urias:");
            Console.WriteLine(sumaE);

            // ACEASTA LINIE IMPIEDICA CONSOLA SA SE INCHIDA SINGURA!
            Console.WriteLine("\nProgramul s-a terminat. Apasati tasta ENTER pentru a inchide fereastra...");
            Console.ReadLine();
        }

        // Metoda de la curs: Calculati n! recursiv
        static BigNumber Factorial(int n)
        {
            if (n == 0 || n == 1)
                return new BigNumber(1);
            return new BigNumber(n) * Factorial(n - 1);
        }

        // Metoda de la curs: Calculati elementul de pe pozitia n din sirul lui Fibonacci
        static BigNumber Fibonacci(int n)
        {
            BigNumber[] fibonacci = new BigNumber[n];
            fibonacci[0] = new BigNumber(1);
            fibonacci[1] = new BigNumber(1);
            for (int i = 2; i < n; i++)
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            return fibonacci[n - 1];
        }

        // Metoda de la curs: Extindere matrice cu medii aritmetice
        static int[,] Extindere(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[,] Matrix = new int[2 * n - 1, 2 * m - 1];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Matrix[2 * i, 2 * j] = matrix[i, j];
                    if (j > 0)
                    {
                        Matrix[2 * i, 2 * j - 1] = (matrix[i, j - 1] + matrix[i, j]) / 2;
                    }
                }

            for (int i = 1; i < 2 * n - 1; i += 2)
                for (int j = 0; j < 2 * m - 1; j++)
                {
                    Matrix[i, j] = (Matrix[i - 1, j] + Matrix[i + 1, j]) / 2;
                }
            return Matrix;
        }

        // Metoda OPTIMIZATA (Ridicarea la putere in timp logaritmic)
        static BigNumber Power(int baseNum, int exponent)
        {
            BigNumber result = new BigNumber(1);
            BigNumber baseBig = new BigNumber(baseNum);

            while (exponent > 0)
            {
                if (exponent % 2 == 1)
                {
                    result = result * baseBig;
                }
                baseBig = baseBig * baseBig;
                exponent /= 2;
            }

            return result;
        }
    }
}
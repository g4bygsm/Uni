using System;

namespace L4
{
    class Program
    {
        static void Main(string[] args)
        {
            int nrStudentiBuniG1;
            int nrStudentiBuniG2;
            int nrStudentiSlabiG1;
            int nrStudentiSlabiG2;
            int nrStudentiMediocriG1;
            int nrStudentiMediocriG2;

            Console.WriteLine("Grupa 1 de studenti:");
            Console.Write("Studenti buni: ");
            nrStudentiBuniG1 = int.Parse(Console.ReadLine());
            Console.Write("Studenti mediocri: ");
            nrStudentiMediocriG1 = int.Parse(Console.ReadLine());
            Console.Write("Studenti slabi: ");
            nrStudentiSlabiG1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Grupa 2 de studenti:");
            Console.Write("Studenti buni: ");
            nrStudentiBuniG2 = int.Parse(Console.ReadLine());
            Console.Write("Studenti mediocri: ");
            nrStudentiMediocriG2 = int.Parse(Console.ReadLine());
            Console.Write("Studenti slabi: ");
            nrStudentiSlabiG2 = int.Parse(Console.ReadLine());

            int totalG1 = nrStudentiBuniG1 + nrStudentiMediocriG1 + nrStudentiSlabiG1;
            int totalG2 = nrStudentiBuniG2 + nrStudentiMediocriG2 + nrStudentiSlabiG2;

            if (totalG1 == 0 || totalG2 == 0)
            {
                Console.WriteLine("Una dintre grupe nu are niciun student. Nu se poate calcula probabilitatea.");
                return;  
            }

            int cazuriG1Bun = nrStudentiBuniG1 * (nrStudentiMediocriG2 + nrStudentiSlabiG2);
            int cazuriG1Mediocru = nrStudentiMediocriG1 * nrStudentiSlabiG2;

            int totalCazuriFavorabile = cazuriG1Bun + cazuriG1Mediocru;
            int totalCazuriPosibile = totalG1 * totalG2;

            double probabilitate = (double)totalCazuriFavorabile / totalCazuriPosibile;

            Console.WriteLine("\nProbabilitatea ca studentul din Grupa 1 sa fie mai bun decat cel din Grupa 2 este: ");
            Console.WriteLine(probabilitate);
        }
    }
}
namespace L3
{
    class Program
    {
        static bool Check(string input)
        {
            bool hasT = false;
            bool hasI = false;
            bool hasC = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 't')
                {
                    hasT = true;
                }
                if (input[i] == 'i')
                {
                    hasI = true;
                }
                if (input[i] == 'c')
                {
                    hasC = true;
                }
            }
            if (hasT && hasI && hasC)
            {
                return true;
            }
            return false;
        }


        static double Probability(string input)
        {
            if (input == null || input.Length < 3)
            {
                return 0.0;
            }
            string textMic = input.ToLower();
            int countT = 0, countI = 0, countC = 0;
            foreach (char c in textMic)
            {
                if (c == 't') countT++;
                else if (c == 'i') countI++;
                else if (c == 'c') countC++;
            }
            int n = textMic.Length;
            double probabilitate = ((double)countT / n) *
                           ((double)countI / (n - 1)) *
                           ((double)countC / (n - 2));

            return probabilitate;
        }
        static void Main(string[] args)
        {
            string input;
            Console.WriteLine("Introdu cuvantul:");
            input = Console.ReadLine(); 
            Console.WriteLine($"Probabilitatea este:{Probability(input)}");
            Console.WriteLine("Introdu cuvantul:");
            input = Console.ReadLine();
            Console.WriteLine($"Probabilitatea este:{Probability(input)}");
            Console.WriteLine("Introdu cuvantul:");
            input = Console.ReadLine();
            Console.WriteLine($"Probabilitatea este:{Probability(input)}");
            Console.WriteLine("Introdu cuvantul:");
            input = Console.ReadLine();
            Console.WriteLine($"Probabilitatea este:{Probability(input)}");
            Console.WriteLine("Introdu cuvantul:");
            input = Console.ReadLine();
            Console.WriteLine($"Probabilitatea este:{Probability(input)}");


        }
    }
}
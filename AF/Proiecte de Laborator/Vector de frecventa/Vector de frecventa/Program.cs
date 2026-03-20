namespace _3.VectorFrecventa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader reader = new StreamReader("../../../TextLung.txt");
            string text = reader.ReadToEnd();

            string alfabet = "abcdefghijklmnopqrstuvwxyz";
            int[] frecventa = new int[alfabet.Length];

            for (int i = 0; i < text.Length; i++)
            {
                int index = alfabet.IndexOf(text[i].ToString().ToLower());
                if (index == -1)
                    continue;
                frecventa[index]++;
            }


            int maxFreq = frecventa.Max();
            int inaltimeGrafic = 20; 

            int[] inaltimi = new int[26];
            float[] procente = new float[26];

            for (int i = 0; i < 26; i++)
            {
                procente[i] = maxFreq == 0 ? 0 : (float)frecventa[i] / maxFreq;
                inaltimi[i] = (int)(procente[i] * inaltimeGrafic);
                if (frecventa[i] > 0 && inaltimi[i] == 0)
                {
                    inaltimi[i] = 1;
                }
            }

            for (int rand = inaltimeGrafic; rand >= 1; rand--) 
            {
                for (int i = 0; i < 26; i++) 
                {
                    if (inaltimi[i] >= rand)
                    {
                        Console.ForegroundColor = procente[i] switch
                        {
                            > 0.8f => ConsoleColor.DarkRed,
                            > 0.7f => ConsoleColor.Red,
                            > 0.5f => ConsoleColor.DarkYellow,
                            > 0.3f => ConsoleColor.Yellow,
                            > 0.2f => ConsoleColor.Green,
                            _ => ConsoleColor.DarkGreen,
                        };
                        Console.Write("███ ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("    ");
                    }
                }
                Console.WriteLine(); 
            }
            for (int i = 0; i < 26; i++)
            {
                Console.Write($" {alfabet[i]}  "); 
            }
            Console.WriteLine();
            
            // bottom
            
            for (int i = 0; i < 26; i++)
            { 
                Console.Write($"{frecventa[i],-3} ");
            }
            Console.WriteLine();
        }
    }
}
using System;
using System.IO;

namespace Partial
{
    class Program
    {
        public static void Main()
        {
            string path = @"C:\Users\tripg\Documents\Projects\Coding\Uni\Uni\AF\Partial\Partial\data.in.txt";
            TextReader load = new StreamReader(path);
            string buffer;
            List<string> lines = new List<string>();
            int[] a = new int[101];
            int nr = 0;
            while( (buffer = load.ReadLine()) != null )
            {
                lines.Add(buffer);
            }
            load.Close();
            foreach (string line in lines)
            {
                string[] elem = line.Split(' ');
                foreach(string chara in elem)
                {
                    a[nr]=int.Parse(chara);
                    nr++; 
                }
            }

            for(int i  = 0; i < nr; i++)
            {
                Console.Write(a[i] + " ");
            }
        
        }
    }
}
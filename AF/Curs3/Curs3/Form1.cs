using System.Reflection.Metadata.Ecma335;

namespace Curs3
{
    public partial class Form1 : Form
    {

        
        // DEFINITIA NR PRIME (by laslow) da n are sens cica deci idk
        bool isPrime(int n)
        {
            if(n<2) return false;
            if (n == 2) return true;
            if(n%2==0) return false;
            for (int i = 3; i*i <= n; i++)
            {
                if(n%i == 0) return false;
            }
            return true;
        }

        // aci nuj ce am fct sincer 

        public Form1()
        {
          

            InitializeComponent();
            





            //List<string> data = new List<string>();
            //TextReader load = new StreamReader();
            //string buffer;
            //while ((buffer = load.ReadLine()) != null)
            //{
              
            //}   
            //List <int> ints = new List<int>();
            //for (int i = 0; i < data.Count; i++)
            //{
            //    string[] load = data[i].Split(' ');
            //    for (int j = 0; j < load.Length; j++)
            //    {
            //        ints.Add(int.Parse(load[j]));
            //    }
            //}

            //int n = int.Parse(ints[0]);
            //int[] v = new int[ints.Count - 1];
            //for (int i = 0; i < v.Length; i++)
            //{
            //    v[i] = ints[i + 1];
            //}
            


            

        }

        // Problema de examen
        // Construiti o functie booleana care determina(cat mai eficient) daca un nr 1<=n<10000 este perfect( 2xn=SumDiv(n) )
        // 6 = 1+2+3+6 = 12


        int SumDiv(int n)
        {
            int d = 1, s = 0;
            for(d;d*d<n;d++)
            {
                if (n % d == 0) s += d + (n / d);
            }
            if (d * d == n) s += d;


            return s;
        }

        bool IsPerf(int n) {
            return 2 * n == SumDiv(n);
        }

        // sunt doar 4 numere perfecte O[4]



        bool[] v = new bool[1000];
        int n = int.Parse(Console.ReadLine());
        string buffer;
        TextReader load = new StreamReader(@../../)
        while( (buffer = load.ReadLine())!= null)
            {
                string[] local = buffer.Split(' ');
                foreach(string s in local) v[int.Parse(s)] = true;
            }




        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

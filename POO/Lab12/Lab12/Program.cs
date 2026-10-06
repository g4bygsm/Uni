////// Sa se creeze un tip de date numit PERSOANA care sa contina Numele de tip string si varsta
////// de tip intreg reprezentate de tipul read-only. Clasa va contine un constructor pt initializare
////// avand 2 parametri corespunzatori celor 2 campuri. In main se vor adauga mai multe obiecte
////// de tipul persoana intr-o colectie generica de tipu LIST. Sa se afiseze persoanele din colectie
////// sortate lexico-grafic dupa nume si respectiv sortate crescator dupa varsta.
////// 

////namespace Lab12
////{
////    public class Persoana
////    {
////        public string Nume { get; }
////        public int Varsta { get; }

////        public Persoana(string n, int v)
////        {
////            Nume = n;
////            Varsta = v;
////        }

////        public override string ToString()
////        {
////            return Nume + ", " + Varsta.ToString() + " ani";
////        }

////        public static void print(List<Persoana> list)
////        {
////            foreach (object o in list)
////            {
////                Console.WriteLine(o);
////            }
////        }
////        public static void Main()
////        {
////            List<Persoana> pers = new List<Persoana>();
////            pers.Add(new Persoana("Ion", 54));
////            pers.Add(new Persoana("Laslo", 14));
////            pers.Add(new Persoana("Aurel", 44));
////            pers.Add(new Persoana("Walter", 26));
////            pers.Add(new Persoana("Jesse", 20));
////            pers.Add(new Persoana("Iohanis", 29));
////            pers.Add(new Persoana("Horea", 12));
////            pers.Add(new Persoana("Delia", 6));
////            pers.Sort(new SortByName());
////            Console.WriteLine("\n\nSortarea dupa nume: \n");
////            print(pers);

////            pers.Sort(new SortByAge());
////            Console.WriteLine("\n\nSortarea dupa varsta: \n");
////            print(pers);
////        }
////    }

////    public class SortByName : IComparer<Persoana>
////    {
////        public int Compare(Persoana p1, Persoana p2)
////        {
////            return string.Compare(p1.Nume, p2.Nume);
////        }
////    }
////    public class SortByAge : IComparer<Persoana>
////    {
////        public int Compare(Persoana p1, Persoana p2)
////        {
////            if(p1.Varsta < p2.Varsta)
////            {
////                return -1;
////            }
////            if(p1.Varsta > p2.Varsta)
////            {
////                return 1;
////            }
////            return 0;
////        }
////    }
////}


//// Se considera un fisier text de intrare de forma Nume Prenume N Nota1...Nota N unde n reprezinta
//// nr notelor. Datele din fisier se adauga intr-o colectie generica prin intermediul unei clase
//// denumite elev. Avand ca membri data numele, prenumele si media aritmetica a notelor. Sa se afiseze 
//// intr-un fisier de iesire lista inregistrarilor sortate descrescator in functie de medie
//// iar pentru medii egale ordinea alfabetica in functie de nume si prenume


//using System.Text;

//namespace Lab12
//{

//    public class Elevi
//    {
//        public string Nume { get; }
//        public string Prenume { get; }
//        public double Media { get; }
//        public Elevi(string nume, string prenume, double media)
//        {
//            Nume = nume;
//            Prenume = prenume;
//            Media = media;
//        }
//        public override string ToString()
//        {
//            StringBuilder s = new StringBuilder();
//            s.AppendFormat($"{Nume} {Prenume}, media {Media:0.00}");
//            return s.ToString();
//        }
//        public static void Main()
//        {
//            StreamReader f;
//            try
//            {
//                f = File.OpenText("in.txt");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//                return;
//            }
//            int n = Convert.ToInt32(f.ReadLine());
//            List<Elevi> lista = new List<Elevi>;
//            char[] delimitator = { ',', ' ' };
//            string s;
//            strint[] str;
//            int i;
//            double media, media_genereala = 0.0;
//            while ((s = f.ReadLine()) != null) {
//                str = s.Split(delimitator);
//                media = 0.0;
//                for (i = 0; i < ConvertToInt32(str[2]); i++)
//                {

//                    lista.Sort(new SortElevi());
//                    StreamWriter g = new StreamWriter()
//                }
//            }
//        }
//    }
//}



// Se considera o lista de valori in virgula mobila cu precizie de pana la 28-29 de cifre
// zecimale. Se cere valorilor in ordine descrescatoare in functie de partea fractionara

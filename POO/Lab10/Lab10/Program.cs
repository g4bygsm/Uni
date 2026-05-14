// Sa se implementeze interfetele IForma si IForma_ care sa contina o proprietate de tip read-only numita
// denumire, interfata iForma2D derivata din IForma care sa contina metodele Aria si LungimeFrontiera si 
// respectiv interfata IForma3D derivata din IForma si IForma_ care sa contina metoda Volum. Sa se 
// implementeze apoi clasele cerc si patrat care implementeaza interfata IForma2D si respectiv clasa Cub
// care implementeaza interfata IForma3D si care sa contina implementarea metodelor precizate in interfetele
// corespunzatoare. Metodele vor fi apelate din interiorul unei metode care are un parametru de tipul
// interfetei(variabila referinta de tipul unei interfete)


using System;

namespace Lab10
{
    public interface IForma
    {
        string denumire { get; }
    }

    public interface IForma_
    {
        string denumire { get; }
    }

    public interface IForma2D : IForma
    {
        double Aria();
        double LungFrontiera();
    }

    public interface IForma3D : IForma, IForma_
    {
        double Volum();
    }

    public class Cerc : IForma2D
    {
        public double raza;
        private const float PI = 3.14159f;
        string s = "cerc";
        public Cerc(double r)
        {
            raza = r;
        }
        public double Aria()
        {
            return (PI * raza * raza);
        }
        public double LungFrontiera()
        {
            return (2 * PI * raza);
        }
        public string denumire
        {
            get
            {
                return s;
            }
        }
    }

    public class Patrat : IForma2D
    {
        public double latura;
        string s = "patrat";
        public Patrat(double l)
        {
            latura = l;
        }

        public double Aria()
        {
            return (latura * latura);
        }

        public double LungFrontiera()
        {
            return (latura * 4);
        }
        public string denumire
        {
            get
            {
                return s;
            }
        }
    }

    public class Cub : IForma3D
    {
        public double latura;
        string s = "cub";
        public Cub(double l)
        {
            latura = l;
        }
        public double Volum()
        {
            return (latura * latura * latura);
        }

        string IForma.denumire
        {
            get
            {
                return s + "1";
            }
        }
        string IForma_.denumire
        {
            get
            {
                return s + "2";
            }
        }
        public string Denumire
        {
            get 
            {
                Cub c = new Cub(3);
                IForma f = c;
                return f.denumire;
            }
        }
    }

    class InterfDemo
    {
        static void DisplayInfo(IForma2D f)
        {
            Console.WriteLine($"aria={f.Aria():0.00} \t lungimea frontierei = {f.LungFrontiera():#.##}");
        }
        static void DisplayInfo(IForma3D f)
        {
            Console.WriteLine($"volumul =  {f.Volum():#.##}");
        }

        public static void Main()
        {
            Cerc c = new Cerc(3);
            Console.WriteLine("Afiseaza informatii despre {0}:", c.denumire);
            DisplayInfo(c);

            Patrat p = new Patrat(3);
            Console.WriteLine("\nAfiseaza informatii despre {0}:",p.denumire);
            DisplayInfo(p);

            Cub cub = new Cub(3);
            Console.WriteLine("\nAfiseaza informatii despre {0}:", cub.Denumire);
            DisplayInfo(cub);

            Console.WriteLine("\n");
        }
    }
    

}
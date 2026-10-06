
// a b c d e
// e d c b a


//namespace Lab1
//{
//    class Program
//    {
//       static void Main(string[] args)
//        {
//            string text = "abcde";
//            string newText = Palindrom(text, 0);
//            Console.WriteLine(newText);
//        }
//        static string Palindrom(string s, int index)
//        {

//            if (s.Length == 1)
//                return s;
//            if (s.Length == index)
//                return "";
//            return Palindrom(s, index + 1) + s[index];

//        }
//    }
//}



// cititi de la tast un x si declarati un nr y, faceti o functie recursiva care primeste ca
// parametri pe x si y si care dupa executia functiei daca tipariti pe y, y o sa fie nr x inversat


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int nrDisc = 4;
            Hanoi(nrDisc, 'A', 'C', 'B');
        }
        static void Hanoi(int n, char source, char dest, char aux)
        {
            if(n == 1) return;
            Hanoi(n, source, aux, dest);
            Hanoi(n, aux, dest, source);
        }
    }
}
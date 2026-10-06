// Proiectati o structura de date care sa gestioneze triajul intr-un spital de urgente

namespace Cap8
{

    public class Pacient
    {
        public int p;
        public string data;

        public Pacient(string data, int p)
        {
            this.data = data;
            this.p = p;
        }

        public override string ToString()
        {
            return data + " " + p;
        }
    }

    public class PQ
    {
        Pacient[] v;

        public PQ()
        {
            v = new Pacient[0];
        }
        public void Push(Pacient x)
        {
            bool first = true;
            Pacient[] t = new Pacient[v.Length + 1];
            int k = 0;
            for(int i = 0; i < v.Length; i++)
            {
                if (v[i].p <= x.p)
                {
                    t[k] = v[i];
                    k++;
                }
                else if (first)
                {
                    t[k] = x;
                    k++;
                    first = false;
                }
                else
                {
                    t[k] = v[i];
                    k++;
                }
            }
        }
    }
}



// Se da o multime de puncte in plan. Construiti o aplicatie C# care pozitioneaza k cercuri 
// disjuncte de raza r astfel incat numarul total de puncte incluse in cerc sa fie maxim.



// (CAP4) Se da o atza impartita in n intervale egale de la etapa la etapa furnicile se deplaseaza, iar cand se ciocnesc de alte furnici se intorc
// Pentru fisierul data.in care reprezinta n 
// Construiti o aplicatie care determina in cate etape e ata goala
using System.Numerics;

bool BinarySearch(int[] v, int st, int dr, int x)
{
    if (st <= dr)
    {
        int m = (st + dr) / 2;
        if (v[m] == x) return true;
        else if (x < v[m])
        {
            return BinarySearch(v, st, m - 1, x);
        }
        else return BinarySearch(v, m + 1, dr, x);
    }
    else 
    {
        return false;
    }
}
// Merge Sort (interclasare)
// Quick Sort (sortare rapida) -- examen (?)



// Verificăm care element este mai mic și îl punem în noul vector v3
if (v1[k1] < v2[k2])
{
    v3[k3] = v1[k1];
    k1++; // Trecem la următorul element din v1
    k3++; // Trecem la următoarea poziție liberă din v3
}
else
{
    v3[k3] = v2[k2];
    k2++; // Trecem la următorul element din v2
    k3++;
}

// Dacă s-au terminat elementele din v2, dar au mai rămas în v1, le copiem direct
while (k1 < m1)
{
    v3[k3] = v1[k1];
    k1++;
    k3++;
}

// Alternativ, dacă s-au terminat în v1, dar au mai rămas în v2
while (k2 < m2)
{
    v3[k3] = v2[k2];
    k2++;
    k3++;
}

// PROBLEMA
// Se dau 4 tije ABCD se considera A sursa, D destinatie iar B si C intermediare in contextul problemei 
// turnurilor din Harmon. Rezolvati un algoritm care muta n discuri de pe sursa pe destinatie. Considerati
// o solutie viabila cu un nr de pasi mai mic decat echivalentul.
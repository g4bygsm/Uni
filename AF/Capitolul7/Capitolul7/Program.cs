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

int[] v1 = new int[10];
int[] v2 = new int[10];
int k1;
int k2;


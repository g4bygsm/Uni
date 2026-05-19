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
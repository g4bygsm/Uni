using System;
using System.Collections.Generic;

namespace Factorial
{
    public class BigNumber
    {
        private List<int> digits;
        public int length;

        // Constructor implicit
        public BigNumber()
        {
            length = 0;
            digits = new List<int>();
        }

        // Constructor dintr-un numar intreg (int)
        public BigNumber(int original)
        {
            digits = new List<int>();

            if (original == 0)
            {
                Add(0);
            }
            else
            {
                while (original > 0)
                {
                    Add(original % 10);
                    original /= 10;
                }
                digits.Reverse();
            }
        }

        // Constructor dintr-o lista de cifre (Creeaza o copie sigura)
        public BigNumber(List<int> digits, int length)
        {
            this.digits = new List<int>(digits);
            this.length = length;
        }

        // Indexator pentru a citi cifrele direct prin obiect[i]
        public int this[int index]
        {
            get { return digits[index]; }
            private set { digits[index] = value; }
        }

        // Operatorul de adunare (+) - REPARAT COMPLET
        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            BigNumber result = new BigNumber();
            int carry = 0;

            int i = a.length - 1;
            int j = b.length - 1;

            // Adunam cifrele de la dreapta la stanga
            while (i >= 0 || j >= 0 || carry > 0)
            {
                int sum = carry;
                if (i >= 0) sum += a[i--];
                if (j >= 0) sum += b[j--];

                result.Add(sum % 10);
                carry = sum / 10;
            }

            result.Reverse();
            return result;
        }

        // Operatorul de inmultire (*) - REPARAT COMPLET
        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            // Daca unul dintre numere este 0, rezultatul inmultirii este 0
            if ((a.length == 1 && a[0] == 0) || (b.length == 1 && b[0] == 0))
                return new BigNumber(0);

            BigNumber result = new BigNumber(0);

            // Inmultim fiecare cifra din b cu intregul numar a
            for (int i = b.length - 1; i >= 0; i--)
            {
                int digitB = b[i];
                if (digitB == 0) continue;

                BigNumber partial = new BigNumber();
                int carry = 0;

                for (int j = a.length - 1; j >= 0; j--)
                {
                    int prod = (a[j] * digitB) + carry;
                    partial.Add(prod % 10);
                    carry = prod / 10;
                }

                if (carry > 0)
                    partial.Add(carry);

                partial.Reverse();

                // Adaugam zerouri la coada in functie de ordinul cifrei (zeci, sute...)
                int zerosCount = b.length - 1 - i;
                for (int k = 0; k < zerosCount; k++)
                {
                    partial.Add(0);
                }

                // Adunam rezultatul partial la cel final
                result = result + partial;
            }

            return result;
        }

        // Metode ajutatoare (Helper functions)
        public void Reverse()
        {
            digits.Reverse();
        }

        public void Add(int digit)
        {
            digits.Add(digit);
            length++;
        }

        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < length; i++)
            {
                result += this[i];
            }
            return result;
        }
    }
}
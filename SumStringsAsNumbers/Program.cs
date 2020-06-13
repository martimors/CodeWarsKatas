using System;

namespace SumStringsAsNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.sumStrings("000000000000000000050095301248058391139327916261", "8105590009602350419725"));
        }
    }
    public static class Kata
    {
        public static string sumStrings(string a, string b)
        {

            // The method must handle ANY size positive number OR nulls OR leading 0-padded number (all as strings!)
            // Trim leading zeroes
            a = a.TrimStart(new Char[] { '0' });
            b = b.TrimStart(new Char[] { '0' });
            // a is the larger number
            if (a.Length < b.Length)
            {
                string temp = a;
                a = b;
                b = temp;
            }

            // pad out b with zeroes
            b = b.PadLeft(a.Length, '0');

            bool remainder = default(bool);
            int currentSum = default(int);
            string sum = string.Empty;
            // loop through the strings and add
            for (int i = a.Length - 1; i >= 0; i--)
            {
                // Calculate the sum of the position
                currentSum = a[i] - '0' + b[i] - '0' + (remainder ? 1 : 0);
                remainder = (currentSum >= 10);
                currentSum -= (remainder ? 10 : 0);
                // Append the result to the string
                sum = sum + currentSum;

            }
            // Append the final remainder if needed
            sum = sum + (remainder ? "1" : string.Empty);
            return Reverse(sum);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

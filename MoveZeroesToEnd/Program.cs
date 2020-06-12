using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveZeroesToEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new int[] { 1, 4, 6, 0, 1, 5, 13, 35, 0, 5 };
            Console.WriteLine(Kata.MoveZeroes(test));
        }
    }
    public class Kata
    {
        public static int[] MoveZeroes(int[] arr)
        {
            var list = new List<int>();
            int nZero = 0;

            foreach (int i in arr)
            {
                if (i == 0)
                {
                    nZero++;
                }
                else
                {
                    list.Add(i);
                }
            }
            for (int i = 1; i <= nZero; i++)
            {
                list.Add(0);
            }
            return list.ToArray();
        }

    }
}

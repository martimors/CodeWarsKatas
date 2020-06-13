using System;
using System.Collections.Generic;
using System.Linq;

namespace EnoughIsEnough
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Kata.DeleteNth(new int[] { 20, 37, 20, 21 }, 1)));
        }
        public class Kata
        {
            public static int[] DeleteNth(int[] arr, int x)
            {
                var l = new List<int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    int v = l.Count(n => n == arr[i]);
                    if (v < x) l.Add(arr[i]);
                }
                return l.ToArray();
            }
        }
    }
}

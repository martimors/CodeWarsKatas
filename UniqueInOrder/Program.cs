using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueInOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = new int[] { 1, 1, 3, 1, 5, 12, 43, 43, 1, 43, -12, -12 };
            var test2 = new string[] { "Hungary", "Norway", "Norway", "Norway", "Denmark", "Sweden", "Denmark", "Latvia", "Latvia", "Norway" };
            string test3 = "AAAABBBCCDAABBB";
            var test4 = new List<int>() { 1, 2, 2, 3, 3 };
            Console.WriteLine(string.Join(" ", Kata.UniqueInOrder(test1)));
            Console.WriteLine(string.Join(" ", Kata.UniqueInOrder(test2)));
            Console.WriteLine(string.Join(" ", Kata.UniqueInOrder(test3)));
            Console.WriteLine(string.Join(" ", Kata.UniqueInOrder(test4)));
            Console.WriteLine(string.Join(" ", Kata.UniqueInOrder("")));
        }
    }

    public static class Kata
    {
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            IEnumerable<T> outvalue = Enumerable.Empty<T>();
            if (!iterable.Any()) return outvalue;
            outvalue = outvalue.Concat(new[] { iterable.ElementAt(0) });
            for (int i = 1; i < iterable.Count(); i++)
            {
                if (iterable.ElementAt(i).Equals(iterable.ElementAt(i - 1))) { }
                else
                {
                    outvalue = outvalue.Concat(new[] { iterable.ElementAt(i) });
                }
            }
            return outvalue;
        }
    }
}

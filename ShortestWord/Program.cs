using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.FindShort("She wondered what his eyes were saying beneath his mirrored sunglasses."));
        }
    }
    public class Kata
    {
        public static int FindShort(string s)
        {
            var words = s.Split(" ");
            var lengths = new List<int>();
            foreach (string word in words)
            {
                lengths.Add(word.Length);
            }

            return lengths.Min();
        }
    }
}

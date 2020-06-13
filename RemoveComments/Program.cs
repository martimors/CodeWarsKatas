using System;
using System.Text.RegularExpressions;

namespace RemoveComments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StripCommentsSolution.StripComments("asdhiasd #39458\n\n123\n$gautur", new string[] { "#", "$" }));
        }
        public class StripCommentsSolution
        {
            public static string StripComments(string text, string[] commentSymbols)
            {
                foreach (string symbol in commentSymbols)
                {
                    text = Regex.Replace(text, @"\#(.*)".Replace("#", symbol), "");
                }
                return Regex.Replace(text, @"\s (.*)", "");
            }
        }
    }
}

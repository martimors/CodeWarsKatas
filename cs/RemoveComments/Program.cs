using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RemoveComments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StripCommentsSolution.StripComments("a\n", new string[] { "a" }).Replace(" ", "£").Replace("\n", "\\n"));
        }
        public class StripCommentsSolution
        {
            public static string StripComments(string text, string[] commentSymbols)
            {
                foreach (string symbol in commentSymbols)
                {
                    text = Regex.Replace(text, @"LOL(.*)".Replace("LOL", Regex.Escape(symbol)), "");
                }
                string outstring = string.Join("\n", text.Split('\n').Select(s => s.TrimEnd()));
                return outstring.Replace("\n", "") == string.Empty ? string.Empty : outstring;
            }
        }
    }
}

using System;

namespace PaintfuckInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = PaintFuck.Interpret("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 42, 6, 9);
            Console.WriteLine(sol);
        }
    }
}

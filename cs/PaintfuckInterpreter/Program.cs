using System;

namespace PaintfuckInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = PaintFuck.Interpret("o*e*eq*reqrqp*ppooqqeaqqsr*yqaooqqqfqarppppfffpppppygesfffffffffu*wrs*agwpffffst*w*uqrw*qyaprrrrrw*nuiiiid???ii*n*ynyy??ayd*r:rq????qq::tqaq:y???ss:rqsr?s*qs:q*?qs*tr??qst?q*r", 7, 6, 9);
            Console.WriteLine(sol);
        }
    }
}

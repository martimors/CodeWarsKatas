using System;

namespace GrowthOfAPopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Arge.NbYear(1500, 5, 100, 5000));
        }
    }


    class Arge
    {
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            // Solution of dp/dy = aug + percent*p
            double dp0 = (double)p0;
            double daug = (double)aug;
            double dpercent = percent / 100;
            double dp = (double)p;
            double c1 = dp0 + (daug / dpercent);


            double outval = Math.Log((dp + (aug / dpercent)) / c1) / dpercent;

            return (int)Math.Ceiling(outval);

        }
    }
}

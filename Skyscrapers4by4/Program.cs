using System;
using Skyscrapers4by4.Utils;

namespace Skyscrapers4by4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var clues = new int[]{ 2, 2, 1, 3,
                           2, 2, 3, 1,
                           1, 2, 2, 3,
                           3, 2, 1, 3};

            int[][] solution = Skyscrapers.SolvePuzzle(clues);
            Printing.Print2DArray(solution);
        }
        public class Skyscrapers
        {
            public static int[][] SolvePuzzle(int[] clues)
            {
                var solution = new Solver(clues).Board;
                return solution;
            }


        }

    }
}

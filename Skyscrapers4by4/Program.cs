using System;

namespace Skyscrapers4by4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var clues = new[] { 0, 0, 1, 2,
                                0, 2, 0, 0,
                                0, 3, 0, 0,
                                0, 1, 0, 0 };

            int[][] solution = Skyscrapers.SolvePuzzle(clues);
            Printing.Print2DArray(solution);
        }
        public class Skyscrapers
        {
            public static int[][] SolvePuzzle(int[] clues)
            {
                var solution = new Solver(clues).Board;
                Printing.Print2DArray(solution);
                return solution;
            }


        }

    }
}

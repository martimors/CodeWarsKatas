using System;
namespace Skyscrapers4by4
{

    class Printing
    {
        public static void Print2DArray<T>(T[][] matrix)
        {
            Console.WriteLine("\nThe board now looks like this:");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }


    }
}
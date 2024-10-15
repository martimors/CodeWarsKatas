using System;
using System.Text;

namespace PaintfuckInterpreter
{
    public static class PaintFuck
    {
        public static string Interpret(string code, int iterations, int width, int height)
        {
            Console.WriteLine($"{code} {iterations} {width} {height}");
            // Initialize the grid
            var grid = new bool[height, width];
            int i = 0;
            int row = 0;
            int col = 0;
            int pos = 0;
            char c;

            while (i <= iterations && pos < code.Length)
            {
                // Read first character
                c = code[pos];

                // Switch case to decide what to do
                switch (c)
                {
                    case 'n':
                    case 's':
                        row = MoveY(c, row, height);
                        pos++;
                        break;
                    case 'e':
                    case 'w':
                        col = MoveX(c, col, width);
                        pos++;
                        break;
                    case '*':
                        grid[row, col] = grid[row, col] ? false : true;
                        pos++;
                        break;
                    case '[':
                    case ']':
                        pos = grid[row, col] ? JumpOverBlock(pos, code, c == '[') : pos + 1;
                        break;
                    default:
                        // Invalid characters don't count towards the iterations
                        pos ++;
                        break;
                }

                // Go to next iteration
                i++;
            }
            return ConvertBoolGridToString(grid);
        }

        public static string Reverse(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int MoveX(char dir, int col, int width)
        {
            if (dir == 'e') { col++; } else { col--; }
            if (col < 0) { col = width - 1; }
            else if (col > width - 1) { col = 0; }
            return col;
        }

        public static int MoveY(char dir, int row, int height)
        {
            if (dir == 's') { row++; } else { row--; }
            if (row < 0) { row = height - 1; }
            else if (row > height - 1) { row = 0; }
            return row;
        }

        private static string ConvertBoolGridToString(bool[,] grid)
        {
            // Lines separated by \r\n
            StringBuilder o = new StringBuilder();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    o.Append(grid[i, j] ? "1" : "0");
                    if (j == grid.GetLength(1) - 1) { o.Append("\r\n"); }
                }
            }
            return o.ToString().TrimEnd();
        }

        private static int JumpOverBlock(int pos, string code, bool forwards)
        {
            // Reverse the string if backwards
            if (!forwards) { code = code.Reverse().Replace('[', 'X').Replace(']', '[').Replace('X', ']'); pos = code.Length - 1 - pos; }
            int closingBracePosition = 0;
            int openBr = 0;
            bool bracesMatch = false;
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == '[') { openBr++; } else if (code[i] == ']') { openBr--; }
                if (i == pos) { openBr = 1; }
                if (i > pos && openBr == 0) { closingBracePosition = i; bracesMatch = true; break; }
            }
            if (!bracesMatch) { throw new ArgumentException("Braces don't match!"); }

            // Reverse the string again if we were going reverse
            if (!forwards) { closingBracePosition = code.Length - 2 - closingBracePosition; }

            return closingBracePosition + 1;
        }
    }
}
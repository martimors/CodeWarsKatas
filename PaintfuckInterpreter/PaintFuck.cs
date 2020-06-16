using System.Text;

namespace PaintfuckInterpreter
{
    public static class PaintFuck
    {
        public static string Interpret(string code, int iterations, int width, int height)
        {
            // Initialize the grid
            var grid = new bool[height, width];
            int i = 0;
            int row = 0;
            int col = 0;
            int pos = 0;
            char c;

            while (i < iterations && pos < code.Length)
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
                        col = MoveX(c, col, height);
                        pos++;
                        break;
                    case '*':
                        grid[row, col] = grid[row, col] ? false : true;
                        pos++;
                        break;
                    case '[':
                        break;
                    case ']':
                        break;
                }

                // Go to next
                i++;
            }
            return ConvertBoolGridToString(grid);
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
            return o.ToString();
        }
    }
}
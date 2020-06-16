using System.Linq;
using System;
using System.Collections.Generic;

namespace Skyscrapers4by4
{
    class Solver
    {
        private int[][] board = new int[][] { new int[4], new int[4], new int[4], new int[4] };
        private int[][] trialBoard = new int[][] { new int[4], new int[4], new int[4], new int[4] };
        private bool[,,] valuePossible = new bool[4, 4, 4];
        private int[] clues = new int[16];
        private int[] buildingHeights = new[] { 1, 2, 3, 4 };

        public int[][] Board { get => board; }

        public Solver(int[] _clues)
        {
            // Save input as attribute
            this.clues = _clues;

            // All values possible to start with
            for (int i = 0; i < buildingHeights.Length; i++)
            {
                for (int j = 0; j < buildingHeights.Length; j++)
                {
                    for (int k = 0; k < buildingHeights.Length; k++)
                    {
                        valuePossible[i, j, k] = true;
                    }
                }
            }

            // Start solving
            this.Solve();
        }


        public void Solve()
        {
            int row = 0; int col = 0; int choice;
            while (board.Select(x => x.Min()).Min() == 0)
            {
                Printing.Print2DArray(board);
                // There are > 0 possible numbers?
                var possibilities = GetPossibleValues(row, col);
                if (possibilities.Count > 0)
                {
                    // Yes: Pick a possible number
                    choice = possibilities[0];
                }
                else
                {
                    // No: Replenish all posibilities and step one back
                    // Also unset the value
                    board[row][col] = 0;
                    ReplenishPossibleValues(row, col);
                    var newPos = StepOne(row, col, false);
                    row = newPos[0]; col = newPos[1];
                    continue;
                }
                if (row == 2 && col == 1 && choice == 4)
                {
                    int a = 1;
                }

                // Check rules
                if (IsUniqueInCross(row, col, choice) && ViewIsOKFromAllSides(row, col, choice))
                {
                    // If ok, set value and check the views
                    board[row][col] = choice;
                    if (CluesFitWithBuildingHeights(row, col))
                    {
                        Console.WriteLine($"Value {choice} is ok at {row}:{col}");
                        // If ok step one forwards
                        var newPos = StepOne(row, col, true);
                        row = newPos[0]; col = newPos[1];
                        continue;
                    }

                }

                // If not ok (ie exited loop without hitting continue), remove from possibilities and unset
                board[row][col] = 0;
                if (row == 2 && col == 0 && choice == 3){
                    int a = 1;
                }
                valuePossible[row, col, choice - 1] = false;


            }

        }

        public bool CluesFitWithBuildingHeights(int row, int col)
        {
            var clues = CluesFromPosition(row, col);
            var rowValues = RowValues(row);
            var colValues = ColValues(col);

            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 0) { continue; }
                switch (i)
                {
                    case 0: // Top
                        if (!VectorFitsWithClue(colValues, clues[i])) { return false; }
                        break;
                    case 1: // Right
                        if (!VectorFitsWithClue(ReverseArray(rowValues), clues[i])) { return false; }
                        break;
                    case 2: // Bottom
                        if (!VectorFitsWithClue(ReverseArray(colValues), clues[i])) { return false; }
                        break;
                    case 3: // Left
                        if (!VectorFitsWithClue(rowValues, clues[i])) { return false; }
                        break;
                }
            }
            return true;

        }

        public static bool VectorFitsWithClue(int[] vector, int clue)
        {
            if (vector.Contains(0)) { return true; }
            int view = default(int);
            int highestBuilding = default(int);
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] > highestBuilding)
                {
                    view++; highestBuilding = vector[i];
                }
            }

            return view == clue;

        }


        public static int[] StepOne(int fromRow, int fromCol, bool forwards)
        {
            int row = fromRow; int col = fromCol;

            if (forwards) { if (fromCol == 3) { col = 0; row++; } else { col++; } }
            else { if (fromCol == 0) { col = 3; row--; } else { col--; } }
            return new int[] { row, col };
        }

        private bool ViewIsOKFromAllSides(int row, int col, int n)
        {
            var clues = CluesFromPosition(row, col);
            var rowValues = RowValues(row);
            var colValues = ColValues(col);

            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 0) { continue; }
                switch (i)
                {
                    case 0: // Top
                        if (!View(colValues).Contains(clues[i])) { return false; }
                        break;
                    case 1: // Right
                        if (!View(ReverseArray(rowValues)).Contains(clues[i])) { return false; }
                        break;
                    case 2: // Bottom
                        if (!View(ReverseArray(colValues)).Contains(clues[i])) { return false; }
                        break;
                    case 3: // Left
                        if (!View(rowValues).Contains(clues[i])) { return false; }
                        break;
                }
            }
            return true;
        }

        private List<int> GetPossibleValues(int row, int col)
        {
            var possibleValues = new List<int>();
            if (board[row][col] != 0) { possibleValues.Add(board[row][col]); return possibleValues; }
            for (int i = 0; i < valuePossible.GetLength(2); i++)
            {
                if (valuePossible[row, col, i]) { possibleValues.Add(i + 1); }
            }
            return possibleValues;
        }

        private void ReplenishPossibleValues(int row, int col)
        {
            for (int i = 0; i < valuePossible.GetLength(2); i++)
            {
                valuePossible[row, col, i] = true;
            }
        }

        private int[] RowValues(int row) { return board[row]; }
        private int[] ColValues(int col) { return board.Select(x => x[col]).ToArray(); }

        private static List<int> View(int[] vector)
        {
            // Based on logic, remove possibilities based on the position
            var p = new List<int>() { 1, 2, 3, 4 };
            if (vector[3] == 4 || vector[0] == 1) { p.Remove(1); }
            if (vector[3] == 3 || vector[3] == 2 || vector[3] == 1 || vector[2] == 1) { p.Remove(4); }
            if (vector[2] == 4 || vector[0] == 2) { p.Remove(4); p.Remove(1); }
            if (vector[2] == 2) { p.Remove(4); p.Remove(3); }
            if (vector[2] == 1) { p.Remove(4); }
            if (vector[0] == 4) { p.Remove(2); p.Remove(3); p.Remove(4); }
            if (vector[0] == 3 || vector[1] == 4) { p.Remove(1); p.Remove(3); p.Remove(4); }
            if (vector[1] == 3) { p.Remove(2); p.Remove(4); }

            return p;
        }



        private bool IsUniqueInCross(int row, int col, int n)
        {
            var rowValues = RowValues(row);
            var colValues = ColValues(col);

            return !(rowValues.Contains(n) || colValues.Contains(n));
        }

        private int[] CluesFromPosition(int row, int col)
        {
            int top = col;
            int right = row + 4;
            int left = 15 - row;
            int bottom = 11 - col;

            return new int[] { clues[top], clues[right], clues[bottom], clues[left] };
        }

        private int[] PositionFromClueIndex(int index)
        {
            if (index < 4)
            {
                return new[] { 0, index };
            }
            else if (index >= 4 && index < 8)
            {
                return new[] { index - 4, 3 };
            }
            else if (index >= 8 && index < 12)
            {
                return new[] { 3, 11 - index };
            }
            else
            {
                return new[] { 15 - index, 0 };
            }
        }

        private void FillInFoursAndOnes()
        {
            for (int i = 0; i < clues.Length; i++)
            {
                var pos = PositionFromClueIndex(i);
                switch (clues[i])
                {
                    case 1:
                        Board[pos[0]][pos[1]] = 4;
                        break;
                    case 4:
                        Board[pos[0]][pos[1]] = 1;
                        break;
                    case 2:
                        valuePossible[pos[0], pos[1], 3] = false; break;
                    case 3:
                        valuePossible[pos[0], pos[1], 2] = false;
                        valuePossible[pos[0], pos[1], 3] = false; break;
                }

            }
        }

        private void SetPositionTo(int row, int col, int n)
        {
            board[row][col] = n;
        }

        private static int[] ReverseArray(int[] arr)
        {
            var reversed = new int[arr.Length];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                reversed[arr.Length - i - 1] = arr[i];
            }
            return reversed;
        }
    }
}
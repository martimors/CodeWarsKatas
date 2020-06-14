using System.Linq;
using System;
using System.Collections.Generic;
using Skyscrapers4by4.Utils;

namespace Skyscrapers4by4
{
    class Solver
    {
        private int[][] board = new int[][] { new int[4], new int[4], new int[4], new int[4] };
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
            var previousBoard = board.ToList().ToArray();// This doesnt work because arrays are reference types!!!
            // We know that all positions next to 4 must be 1, and next to 1 must be 4
            FillInFoursAndOnes();

            // Loop through each position and check the rules to see if something can be inserted
            while (board.Min().Min() == 0)
            {
                previousBoard = board;
                for (int row = 0; row < board.Length; row++)
                {
                    for (int col = 0; col < board.Length; col++)
                    {
                        if (board[row][col] == 0)
                        {
                            ApplyClueRules(row, col);
                        }
                    }
                }
                Console.WriteLine("Finished iteration!");
                Printing.Print2DArray(board);
            }

        }


        private void ApplyClueRules(int row, int col)
        {
            var possibleValues = GetPossibleValues(row, col);

            var clue = CluesFromPosition(row, col);

            // Value must be unique in cross
            foreach (int value in buildingHeights)
            {
                if (!IsUniqueInCross(row, col, value))
                {
                    possibleValues.Remove(value);
                }
                if (possibleValues.Count == 1)
                {
                    SetPositionTo(row, col, possibleValues[0]);
                    return;
                }
            }

            // If all clues are 0 we can give up here
            if (clue.Max() == 0) { return; }

            // If this position is the only one with one possible number in the row or the column
            var temp = possibleValues;

            if (row == 2 && col == 0)
            {
                Console.WriteLine("LOL!");
            }
            for (int i = 0; i < buildingHeights.Length; i++)
            {
                if (i != col)
                {
                    temp = temp.Except(GetPossibleValues(row, i)).ToList();
                }
            }
            if (temp.Count == 1)
            {
                SetPositionTo(row, col, temp[0]);
            }

            // Same for column
            temp = possibleValues;
            for (int i = 0; i < buildingHeights.Length; i++)
            {
                if (i != row)
                {
                    temp = temp.Except(GetPossibleValues(col, i)).ToList();
                }
            }
            if (temp.Count == 1)
            {
                SetPositionTo(row, col, temp[0]);
            }
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

        private int[] RowValues(int row) { return board[row]; }
        private int[] ColValues(int col) { return board.Select(x => x[col]).ToArray(); }

        private bool IsUniqueInCross(int row, int col, int n)
        {
            var clues = CluesFromPosition(row, col);
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
    }
}
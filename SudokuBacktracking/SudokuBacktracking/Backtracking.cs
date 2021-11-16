using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBacktracking
{
    class Backtracking
    {
        private int n = 9;
        int[,] board;
        bool color = true;

        public Backtracking()
        {
            // define the size of the board
            board = new int[, ] {
                { 3, 1, 6, 5, 0, 8, 4, 0, 2 },
                { 5, 2, 0, 1, 3, 0, 0, 0, 0 },
                { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
                { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
                { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
                { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
                { 1, 3, 0, 9, 0, 7, 2, 5, 0 },
                { 0, 9, 0, 0, 5, 0, 0, 7, 4 },
                { 7, 4, 5, 2, 8, 6, 3, 0, 9 }
               };
        }

        public bool isSafe(int[,] board, int row, int col, int num)
        {

            // check if the num exists on row
            for (int d = 0; d < board.GetLength(0); d++)
            {
                if (board[row, d] == num)
                {
                    return false;
                }
            }

            // check if the num exists on col
            for (int r = 0; r < board.GetLength(0); r++)
            {
                if (board[r, col] == num)
                {
                    return false;
                }
            }

            // check if the corresponding square for row and col contains unique numbers
            int sqrt = (int)Math.Sqrt(Convert.ToDouble(n));
            int boxRowStart = row - row % sqrt; // row = 2, sqrt = 3 => boxRowStart = 2 - 2%3 = 0
            int boxColStart = col - col % sqrt; // col = 4, sqrt = 3 => boColStart = 4 - 4%3 = 3

            for (int r = boxRowStart; r < boxRowStart + sqrt; r++)
            {
                for (int d = boxColStart; d < boxColStart + sqrt; d++)
                {
                    if (board[r, d] == num)
                    {
                        return false;
                    }
                }
            }

            // return true if it's safe
            return true;
        }

        public bool SolveSudoku()
        {
            int row = -1;
            int col = -1;
            bool isEmpty = true;

            // fill board
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // if the value is 0 we change isEmpty to false
                    if (board[i, j] == 0)
                    {
                        row = i;
                        col = j;

                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                {
                    break;
                }
            }

            // if the board is filled return true so we can print our solution
            if (isEmpty)
            {
                return true;
            }

            // else for each-row backtrack
            for (int num = 1; num <= n; num++)
            {
                // if it's safe to place the value on the row and column that has value 0 we place it
                if (isSafe(board, row, col, num))
                {
                    board[row, col] = num;
                    // print solution if we found a solution
                    if (SolveSudoku())
                    {
                        print();
                        return true;
                    }
                    // change the value for row and col back to 0 to find other value that is safe
                    else
                    {
                        board[row, col] = 0;
                    }
                }
            }
            return false;
        }

        public void ChangeConsoleColor()
        {
            color = !color;
            if(color) Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.Green;
        }

        public void print()
        {
            for (int r = 0; r < n; r++)
            {
                for (int d = 0; d < n; d++)
                {
                    if((d) % (int)Math.Sqrt(n) == 0) ChangeConsoleColor();

                    Console.Write(board[r, d]);
                    Console.Write(" ");
                }
                if ((r + 1) % (int)Math.Sqrt(n) != 0) ChangeConsoleColor();

                Console.Write("\n");
            }
            Console.Write("\n\n\n");
        }
    }
}

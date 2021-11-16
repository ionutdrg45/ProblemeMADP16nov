using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nQueensBacktracking
{
    public class Backtracking
    {
        private int queens;
        int[,] board;

        public Backtracking(int queens)
        {
            // initiate the number of queens from parameter
            this.queens = queens;
            // define the size of the board
            board = new int[queens,queens];

            // initialize the board with 0
            for (int line = 0; line < queens; line++)
            {
                for (int col = 0; col < queens; col++)
                {
                    board[line, col] = 0;
                }
            }
        }

        // printing the solution
        void PrintSolution()
        {
            for(int row = 0; row < queens; row++)
            {
                for(int col = 0; col < queens; col++)
                {
                    if (board[row, col] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Q ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("■ ");
                    }
                }
                Console.Write("\n");
            }
        }

        // check if it's safe to place the queen on line 'row' and column 'col'
        bool isSafe(int[,] board, int row, int col)
        {
            int i, j;

            // check the columns from the left of the current column on same row
            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            // check the diagonal from the possible solution to left up
            i = row; j = col;
            while(i >= 0 && j >= 0)
            {
                if (board[i, j] == 1)
                    return false;
                i--;
                j--;
            }

            // check the diagonal from the possible solution to left down
            i = row; j = col;
            while (i < queens && j >= 0)
            {
                if (board[i, j] == 1)
                    return false;
                i++;
                j--;
            }

            return true;
        }

        // recursive function to solve N Queens problem
        bool solveNQueensRecursive(int[,] board, int col)
        {
            // if all queens were placed and we find a solution return true
            if (col >= queens)
                return true;

            // going through each line with the column specified recursively
            for (int row = 0; row < queens; row++)
            {
                // checking if is safe to put the queen on line 'row' and column 'col'
                if (isSafe(board, row, col))
                {
                    // if it's safe, we place the queen there
                    board[row, col] = 1;

                    // proceed to next column to find the position for next queen
                    if (solveNQueensRecursive(board, col + 1))
                        return true;

                    // if for column 'col' wasn't match a row for the queen we are backtrack the queen from the board
                    board[row, col] = 0;
                }
            }

            // return false if the queen cannot be placed in any row on column 'col'
            return false;
        }

        public void SolveNQueens()
        {
            if (solveNQueensRecursive(board, 0) == false) Console.WriteLine("No solution.");
            else PrintSolution();
        }
    }
}

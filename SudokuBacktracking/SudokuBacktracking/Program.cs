using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBacktracking
{
    class Program
    {
        static void Main(string[] args)
        {
            new Backtracking().SolveSudoku();
            Console.ReadKey();
        }
    }
}

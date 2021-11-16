using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nQueensBacktracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new object that calls function SolveNQueens from class Backtracking and give as parameter the number of queens
            // the number of queens will be setted in the constructor
            new Backtracking(6).SolveNQueens();
            Console.ReadKey();
        }
    }
}

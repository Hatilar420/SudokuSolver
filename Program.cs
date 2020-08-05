using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokoSolver
{
    class Sudoku
    {
        private int[,] SudokuArray = new int[9,9]; 
        public Sudoku (int[,] arr)
        {
            SudokuArray = arr;
        }
        public void Display()
        {
            for(int i = 0; i<9; i++)
            {
                for (int j = 0; j < 9; j++) Console.Write($"{SudokuArray[i,j]} |");
                Console.WriteLine();
            }
        }

        private bool ColumnCheck(int row ,int column , int number)
        {
            for(int i =0; i<9;i++)
            {
                if (i != row)
                {
                    if (number == SudokuArray[i, column]) return true;
                }
            }
            return false;
        }

        private bool RowCheck(int row ,int column ,int number)
        {
            for(int i =0; i<9;i++)
            {
                if (i != column)
                {
                    if (number == SudokuArray[row, i]) return true;
                }
            }
            return false;
        }
        private bool SquareCheck(int row,int column,int number)
        {
            int RowTemp = (row / 3) * 3;
            int ColumnTemp = (column / 3) * 3;
            for(int i =0;i<3;i++)
            {
                for(int j =0;j<3;j++)
                {
                    if (((RowTemp + i) != row) || ((ColumnTemp + j) != column))
                    {
                        if (number == SudokuArray[RowTemp + i, ColumnTemp + j]) return true;
                    }
                }
            }
            return false;
        }
        private bool CanPlace(int row ,int column , int number)
        {
            if (SquareCheck(row, column, number)) return false;
            if (RowCheck(row, column, number)) return false;
            if (ColumnCheck(row, column, number)) return false;
            return true;
        }

        public bool Solve(int row , int column)
        {
            if (column == 9)
            {
                column = 0;
                row++;
                if (row == 9)
                {
                    return true;
                }
            }
            if (SudokuArray[row, column] != 0)
            { return Solve(row, column + 1); }

            for(int i =1;i<=9;i++)
            {
                if(CanPlace(row,column,i))
                {
                    SudokuArray[row, column] = i;
                    if (Solve(row, column + 1))
                    {
                        return true;
                    }
                    SudokuArray[row, column] = 0;
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = { {0,0,6,0,7,9,2,0,3},
                           {3,5,1,0,0,2,9,0,7},
                           {0,0,0,8,1,0,0,0,0},
                           {0,0,2,0,3,8,0,0,0},
                           {9,7,8,0,0,0,5,3,4},
                           {0,0,0,9,4,0,8,0,0},
                           {0,0,0,0,5,7,0,0,0},
                           {6,0,7,3,0,0,1,2,5},
                           {2,0,5,6,9,0,7,0,0}};
            Sudoku board = new Sudoku(arr);
            bool b = board.Solve(0,0);
            board.Display();
            Console.ReadKey();
        } 
    }
   }


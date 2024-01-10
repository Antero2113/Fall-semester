using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class SecondPart
    {
        private readonly int[,] matrix;

        public int GetElement(int rows, int cols)
        {
            int element = matrix[rows, cols];
            return element;
        }

        public SecondPart()
        {
            matrix = new int[,]{
                { 1, 2, 3 },
                { -4, 5, -6 },
                { 7, 8, 9 }};
        }
        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + " or " + nameof(cols));
            }

            matrix = new int[rows, cols];

            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }
        }

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public int GetSumOfRowsWithBelowZero()
        {
            int counterSum = 0;
            int c = 0;
            int mark = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    c += matrix[i, j];
                    if (matrix[i, j] < 0)
                    {
                        mark = 1;
                    }
                }
                if (mark == 1)
                {
                    counterSum += c;
                }
                c = 0;
                mark = 0;
            }

            return counterSum;
        }

        public void GetSaddlePoints()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minElement = int.MaxValue;
                int columnOfMinElement = -1;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int element = matrix[i, j];
                    if (element < minElement)
                    {
                        minElement = element;
                        columnOfMinElement = j;
                    }
                }
                if (IsSaddlePoint(i, columnOfMinElement))
                {
                    Console.WriteLine("Седловая точка: [{0}, {1}]", i, columnOfMinElement);
                }
            }
        }

        private bool IsSaddlePoint(int rowIndex, int columnOfMinElement)
        {
            int element = matrix[rowIndex, columnOfMinElement];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, columnOfMinElement] > element)
                {
                    return false;
                }
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[rowIndex, j] < element)
                    {
                    return false;
                    }
            }
                return true;
        }
    }
}

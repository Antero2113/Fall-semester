using Lab1;
using System.ComponentModel.DataAnnotations;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1:");
            Console.Write("Введите размер массива: ");

            int size = int.Parse(Console.ReadLine());

            var firstPart = new FirstPart(size);

            Console.WriteLine("Исходный массив: ");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Минимальный элемент: ");
            Console.WriteLine(firstPart.GetMin());

            Console.WriteLine("Сумма элементов между первым и последним положительными: ");
            Console.WriteLine(firstPart.GetSumBetweenPositive());

            Console.WriteLine("Сортированный массив: ");
            firstPart.SortByZero();
            PrintVector(firstPart.Vector);

            Console.WriteLine(" ");
            Console.WriteLine("Часть 2:");
            var secondPart = new SecondPart(10, 10);
            Console.WriteLine("Исходный массив: ");
            PrintMatrix(secondPart.Matrix);
            Console.WriteLine(secondPart.GetElement(2,3));

            Console.WriteLine("Сумма элементов строк с отрицательными элементами: ");
            Console.WriteLine(secondPart.GetSumOfRowsWithBelowZero());

            Console.WriteLine("Седловые точки матрицы: ");
            secondPart.GetSaddlePoints();
            
            Console.WriteLine("Седловые точки матрицы, тест: ");
            var test = new SecondPart();
            PrintMatrix(test.Matrix);
            test.GetSaddlePoints();
        }


        static void PrintVector(IEnumerable<int> vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

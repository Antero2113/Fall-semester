using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class FirstPart
    {
        private readonly int[] array;

        public FirstPart(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var random = new Random();

            array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
        }

        public IReadOnlyList<int> Vector
        {
            get
            {
                return array;
            }
        }

        public int GetSumBetweenPositive()
        {
            int start = -1;
            int finish = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    finish = i;
                    if (start == -1)
                    {
                        start = i;
                    }
                }
            }

            int sum = 0;


            for (int i = start+1; i < finish; i++)
            {
                //Console.Write(array[i]);
                //Console.Write(" ");
                sum += array[i];
            }

            return sum;
        }

        public void SortByZero()
        {
            int n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    array[i] = array[n];
                    array[n] = 0;
                    n++;
                }
            }
        }

        public int GetMin()
        {
            int min = array.Min();

            return min;
        }
    }
}

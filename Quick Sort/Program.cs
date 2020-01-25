using System;
using System.Linq;
using System.Collections.Generic;

namespace Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 3, 6, 4, 2, 9, 1, 8, 7 };
            QuickSort(array);

            for (int i = 0; i < array.Length; i++) {
                Console.Write(array[i] + " ");
            }
        }

        static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        static void QuickSort(int[] array, int start, int end)
        {
            if(start >= end) {
                return;
            }

            int number = array[start];
            int i = start, j = end;

            while (i < j)
            {
                while (i < j && array[j] > number) {
                    j--;
                }

                array[i] = array[j];

                while(i < j && array[i] < number) {
                    i++;
                }

                array[j] = array[i];
            }

            array[i] = number;
            QuickSort(array, start, i - 1);
            QuickSort(array, i + 1, end);
        }
    }
}

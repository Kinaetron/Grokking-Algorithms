using System;
using System.Linq;
using System.Collections.Generic;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectionSort(new int[] { 8, 3, 1, 7, 10 }).ToList().ForEach(i => Console.Write("{0}\t", i));
            Console.Read();
        }

        private static IEnumerable<int> SelectionSort(IEnumerable<int> list)
        {
            var castList = list.ToList();
            var count = castList.Count();
            var newList = new List<int>();

            for (int i = 0; i < count; i++)
            {
                int smallestIndex = FindSmallestIndex(castList);
                newList.Add(castList.ElementAt(smallestIndex));
                castList.RemoveAt(smallestIndex);
            }

            return newList;
        }

        private static int FindSmallestIndex(IEnumerable<int> list)
        {
            int smallest = list.ElementAt(0);
            int smallestIndex = 0;

            for (int i = 0; i < list.Count(); i++)
            {
               if(list.ElementAt(i) < smallest) {
                    smallest = list.ElementAt(i);
                    smallestIndex = i;
                }
            }

            return smallestIndex;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace Sum_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(new int[] { 8, 2, 1, 7, 10 }));
        }

        private static int Sum(IEnumerable<int> list)
        {
            if(list.Count() <= 0) {
                return 0;
            }

            return list.ElementAt(0) + Sum(list.Skip(1));
        }
    }
}

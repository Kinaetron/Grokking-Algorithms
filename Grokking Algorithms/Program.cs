using System;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberList = new int[] { 1, 3, 5, 7, 9 };
            Console.WriteLine(BinarySearch(numberList, 3));
        }

        private static int BinarySearch(int[] list, int answer)
        {
            int low = 0;
            int high = list.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int guess = list[mid];

                if(guess == answer) {
                    return mid;
                }

                if(guess > answer) {
                    high -= 1;
                }
                else {
                    low += 1;
                }
            }

            return 0;
        }
    }
}

using System;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            CountDown(10);
        }

        private static void CountDown(int i)
        {
            if(i <= 0) {
                return;
            }

            Console.WriteLine(i);
            CountDown(i - 1);
        }
    }
}

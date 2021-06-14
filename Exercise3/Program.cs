using System;
using System.Collections.Generic;

namespace Exercise3
{
    class Program
    {
        static void VarTest()
        {
            var i = 43;

            var s = "...This is only a test...";

            var numbers = new int[] { 4, 9, 16 };

            var complex =
                new SortedDictionary<string, List<DateTime>>();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var numbers = new int[] { 4, 9, 16 };
            foreach (var c in numbers)
                Console.WriteLine(c);

        }
    }
}

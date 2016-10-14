using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerable_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Method(new[] { 1, 2, 3 }).ToArray();
            Method(new[] { 5, 6, 7 });
        }

        static IEnumerable<int> Method(int[] numbers)
        {
            Console.WriteLine("Method");

            foreach (var item in numbers)
            {
                yield return item + 2;
            }
        }
    }
}

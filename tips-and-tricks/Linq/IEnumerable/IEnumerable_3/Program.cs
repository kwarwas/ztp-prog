using System;
using System.Collections.Generic;

namespace IEnumerable_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = Method(new[] { 5, 6, 7 });

            Console.WriteLine(string.Join(", ", collection));
            Console.WriteLine(string.Join(", ", collection));
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

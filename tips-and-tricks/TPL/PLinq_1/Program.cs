using System;
using System.Diagnostics;
using System.Linq;

namespace PLinq_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int listSize = 10000000;

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            double sum = 0;
            for (int n = 1; n <= listSize; n++)
            {
                var a = n * 2;
                var b = Math.Sin((2 * Math.PI * a) / 1000);
                var c = Math.Pow(b, 2);
                sum += c;
            }

            Console.WriteLine($"for loop {sum} in {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();

            var s = Enumerable.Range(1, listSize)
                .Select(n => n * 2)
                .Select(n => Math.Sin((2 * Math.PI * n) / 1000))
                .Select(n => Math.Pow(n, 2))
                .Sum();

            Console.WriteLine($"LINQ {s} in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}

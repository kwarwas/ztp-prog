using System;
using System.Diagnostics;
using System.Linq;

namespace PLinq_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int listSize = 10000000;

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var s3 = Enumerable.Range(1, listSize)
                .AsParallel()
                .Select(n => n * 2)
                .Select(n => Math.Sin((2 * Math.PI * n) / 1000))
                .Select(n => Math.Pow(n, 2))
                .Sum();

            Console.WriteLine($"PLINQ {s3} in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}

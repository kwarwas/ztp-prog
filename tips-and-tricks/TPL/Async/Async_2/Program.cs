using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Async_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();

            sw.Start();

            Task.WaitAll(Method(), Method(), Method());

            Console.WriteLine(sw.Elapsed);
        }

        static async Task Method()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}

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

            var t1 = Task.Run(() => Method());
            var t2 = Task.Run(() => Method());
            //var t3 = Task.Run(() => Method());
            Method();

            Task.WaitAll(t1, t2);

            Console.WriteLine(sw.Elapsed);
        }

        static void Method()
        {
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
        }
    }
}

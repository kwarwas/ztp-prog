using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Async_4
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Process(i);
            }
        }

        static void Process(int index)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("{0} processed", index);
        }

        //static void Main(string[] args)
        //{
        //    var sw = new Stopwatch();
        //    sw.Start();

        //    var tasks = Enumerable.Range(1, 10)
        //        .Select(x => Process(x));

        //    Task.WaitAll(tasks.ToArray());

        //    Console.WriteLine(sw.Elapsed);
        //}

        //static async Task Process(int index)
        //{
        //    await Task.Delay(TimeSpan.FromSeconds(1))
        //        .ContinueWith(x => Console.WriteLine("{0} processed", index));
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_1
{
    class Program
    {
        static void Main(string[] args)
        {
            M1().Wait();
            //Console.WriteLine(M2().Result);
            Console.WriteLine(M3().Result);
            Console.WriteLine(M4().Result);

            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        static async Task M1()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
        }

        //see warning
        //static async Task<int> M2()
        //{
        //    return 2;
        //}

        static async Task<int> M3()
        {
            return await Task.Run(() => 2);
        }

        static async Task<int> M4()
        {
            return await Task.FromResult(2);
        }
    }
}

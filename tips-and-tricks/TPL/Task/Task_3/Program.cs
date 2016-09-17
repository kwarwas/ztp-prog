using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var parent = Task.Run(() =>
            {
                Console.WriteLine("Outer started");
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    Console.WriteLine("Inner finish");
                }, token, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
            }, token);

            Thread.Sleep(5);
            tokenSource.Cancel();
            parent.Wait(token);

            Console.WriteLine($"Status: {parent.Status}");
            Console.ReadLine();
        }
    }
}

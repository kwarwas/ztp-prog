using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var ct = tokenSource.Token;

            var task = Task.Run(() =>
            {
                while (true)
                {
                    if (ct.IsCancellationRequested)
                    {
                        ct.ThrowIfCancellationRequested();
                        break;
                    }
                }
            }, ct);

            Thread.Sleep(5);
            tokenSource.Cancel();

            try
            {
                task.Wait(ct);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.CancellationToken.CanBeCanceled);
            }
            finally
            {
                tokenSource.Dispose();
            }

            Console.WriteLine("Finish");
            Console.ReadKey();
        }
    }
}

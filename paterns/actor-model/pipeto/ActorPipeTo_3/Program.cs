using ActorPipeTo.Actors;
using ActorSchedule.Messages;
using Akka.Actor;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ActorPipeTo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("ActorPipeTo");

            var actor = system.ActorOf<OrderActor>();

            var sw = new Stopwatch();
            sw.Start();

            var tasks = Enumerable
                .Range(1, 10)
                .Select(x => actor.Ask<Guid>(new OrderMessage(x, "Akka.NET Book")))
                .ToArray();

            Task.WaitAll(tasks);

            foreach (var item in tasks)
            {
                Console.WriteLine(item.Result);
            }

            Console.WriteLine(sw.Elapsed);

            system.WhenTerminated.Wait();
        }
    }
}

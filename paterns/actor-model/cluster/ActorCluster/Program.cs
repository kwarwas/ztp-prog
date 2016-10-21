using System;
using System.Linq;
using System.Threading.Tasks;
using ActorCluster.Actors;
using ActorCluster.Messages;
using Akka.Actor;
using Akka.Routing;

namespace ActorCluster
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("ActorCluster");

            var props = Props.Create<OrderActor>().WithRouter(FromConfig.Instance);

            var actor = system.ActorOf(props, "OrderActor");

            Console.ReadLine();

            Enumerable.Range(1, 10).ToList().ForEach
            (
                x => actor.Tell(new OrderMessage(x, "Akka.NET Book"))
            );

            Console.ReadLine();
        }
    }
}

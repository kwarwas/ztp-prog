using ActorTypes.Actors;
using ActorTypes.Messages;
using Akka.Actor;
using Akka.Routing;
using System;
using System.Linq;

namespace Routers
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("Routers");

            var props = Props.Create<OrderTypedActor>().WithRouter(new RoundRobinPool(5));

            var actor = system.ActorOf(props);

            Enumerable.Range(1, 9).ToList().ForEach
            (
                x => actor.Tell(new OrderMessage(x, "Akka.NET Book"))
            );

            Console.ReadLine();
        }
    }
}

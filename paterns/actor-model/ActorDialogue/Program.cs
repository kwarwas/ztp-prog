using ActorTypes.Actors;
using ActorTypes.Messages;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorDialogue
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("ActorDialogue");

            var untypedActor = system.ActorOf<OrderForwardActor>();

            untypedActor.Tell(new OrderMessage(10, new[] { "Prod", "Pro" }));

            Console.ReadLine();
        }
    }
}

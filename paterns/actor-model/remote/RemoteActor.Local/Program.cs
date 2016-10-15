using Akka.Actor;
using RemoteActor.Common.Actors;
using RemoteActor.Common.Messages;
using System;

namespace RemoteActor.Local
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("RemoteActor");

            var actor = system.ActorOf(Props.Create<OrderActor>(), "OrderActor");

            for (int i = 1; i <= 5; i++)
            {
                actor.Tell(new OrderMessage(i, $"Akka.NET Book {i}"));
            }

            Console.WriteLine("All messages have been sent");

            system.WhenTerminated.Wait();
        }
    }
}

﻿using ActorPipeTo.Actors;
using ActorPipeTo.Messages;
using Akka.Actor;

namespace ActorPipeTo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("ActorPipeTo");

            var actor = system.ActorOf<OrderActor>();

            for (int i = 1; i <= 10; i++)
            {
                actor.Tell(new OrderMessage(i, "Akka.NET Book"));
            }

            system.WhenTerminated.Wait();
        }
    }
}

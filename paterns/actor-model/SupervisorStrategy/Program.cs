﻿using ActorRouters.Actors;
using ActorRouters.Messages;
using Akka.Actor;
using System;
using System.Threading.Tasks;

namespace SupervisorStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("SupervisorStrategy");

            var orderReceiveActor = system.ActorOf<OrderReceiveActor>();

            orderReceiveActor.Tell(new OrderMessage(10, new[] { "Prod", "Pro" }));

            Task.Delay(TimeSpan.FromSeconds(1)).Wait();

            orderReceiveActor.Tell(new OrderMessage(10, new[] { "Prodddd", "Pro" }));

            Console.ReadLine();
        }
    }
}
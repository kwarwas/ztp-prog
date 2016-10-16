using ActorPersistence.Actors;
using ActorPersistence.Commands;
using ActorPersistence.Events;
using Akka.Actor;
using MongoDB.Bson.Serialization;

namespace ActorPersistence
{
    class Program
    {
        static void Main(string[] args)
        {
            BsonClassMap.RegisterClassMap<OrderDetailsAdded>();

            var system = ActorSystem.Create("ActorPersistence");

            var actor = system.ActorOf(Props.Create<OrderActor>("ORD002"));

            actor.Tell(new AddOrderDetails("Akka.NET Book 1", 10.5m));
            actor.Tell(new AddOrderDetails("Akka.NET Book 2", 12.5m));
            actor.Tell(new AddOrderDetails("Akka.NET Book 3", 34.5m));

            actor.Tell(new CalculatePrice());

            actor.Tell(new AddOrderDetails("Akka.NET Book 4", 10.5m));

            actor.Tell(new ThrowError());

            actor.Tell(new AddOrderDetails("Akka.NET Book 5", 10.5m));
            actor.Tell(new AddOrderDetails("Akka.NET Book 6", 10.5m));

            actor.Tell(new CalculatePrice());

            system.WhenTerminated.Wait();
        }
    }
}

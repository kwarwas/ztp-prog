using Akka.Actor;
using ActorTypes.Messages;
using System;

namespace ActorTypes.Actors
{
    public class OrderTypedActor : TypedActor, IHandle<OrderMessage>
    {
        private readonly Guid _id = Guid.NewGuid();

        public void Handle(OrderMessage message)
        {
            Console.WriteLine("#{0} Receive message: {1} {2}", _id, message.Id, message.Name);
        }
    }
}
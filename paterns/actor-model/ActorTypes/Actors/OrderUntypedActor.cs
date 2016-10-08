using Akka.Actor;
using ActorTypes.Messages;
using System;

namespace ActorTypes.Actors
{
    public class OrderUntypedActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            var orderMessage = message as OrderMessage;

            if (orderMessage != null)
            {
                Console.WriteLine("Receive message: {0} {1}", orderMessage.Id, orderMessage.Name);
            }
        }
    }
}
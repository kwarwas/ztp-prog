using Akka.Actor;
using System;
using ActorDialogue.Messages;

namespace ActorRouters.Actors
{
    public class OrderForwardActor : ReceiveActor
    {
        public OrderForwardActor()
        {
            Receive<OrderMessage>(message => Forward(message));
        }

        private void Forward(OrderMessage message)
        {
            var target = Context.ActorOf<OrderReceiveActor>();

            target.Forward(message);
        }
    }
}
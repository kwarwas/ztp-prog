using Akka.Actor;
using ActorRouters.Messages;
using System;

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

            Console.WriteLine(target);

            target.Forward(message);
        }
    }
}
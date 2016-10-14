using Akka.Actor;
using ActorSchedule.Messages;
using System;

namespace ActorSchedule.Actors
{
    public class OrderActor : ReceiveActor
    {
        private ICancelable _cancelable;

        public OrderActor()
        {
            Receive<OrderMessage>(x => Handle(x));
        }

        public void Handle(OrderMessage message)
        {
            Console.WriteLine("#Receive message: {0} {1}", message.Id, message.Name);
        }

        protected override void PreStart()
        {
            _cancelable = Context.System.Scheduler.ScheduleTellRepeatedlyCancelable(
                TimeSpan.Zero,
                TimeSpan.FromSeconds(5),
                Self,
                new OrderMessage(1, "Akka.NET Book"),
                Self);
        }

        protected override void PostStop()
        {
            _cancelable.Cancel();
        }
    }
}
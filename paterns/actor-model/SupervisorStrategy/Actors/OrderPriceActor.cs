using Akka.Actor;
using System;

namespace ActorRouters.Actors
{
    public class OrderPriceActor : ReceiveActor
    {
        public Guid Guid { get; } = Guid.NewGuid();

        public OrderPriceActor()
        {
            Receive<string>(message => GetPrice(message));
        }

        private bool GetPrice(string message)
        {
            Console.WriteLine("{0} {1}", Guid, message);

            if (message.Length == 4)
            {
                throw new Exception();
            }

            Console.WriteLine("jest");

            Sender.Tell((decimal)message.Length, Self);

            return true;
        }

        protected override void PreStart()
        {
            Console.WriteLine("PreStart");
            base.PreStart();
        }

        protected override void PostStop()
        {
            Console.WriteLine("PostStop");
            base.PostStop();
        }

        public override void AroundPostRestart(Exception cause, object message)
        {
            Console.WriteLine(cause);
            base.AroundPostRestart(cause, message);
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine(reason.Message);
            base.PreRestart(reason, message);
        }
    }
}
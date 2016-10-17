using Akka.Actor;

namespace ActorRouters.Actors
{
    public class OrderPriceActor : ReceiveActor
    {
        public OrderPriceActor()
        {
            Receive<string>(message => GetPrice(message));
        }

        private void GetPrice(string message)
        {
            Sender.Tell((decimal)message.Length, Self);
        }
    }
}
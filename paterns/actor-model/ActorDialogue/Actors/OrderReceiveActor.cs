using Akka.Actor;
using ActorRouters.Messages;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace ActorRouters.Actors
{
    public class OrderReceiveActor : ReceiveActor
    {
        public OrderReceiveActor()
        {
            Receive<OrderMessage>(message => CalculateTotalPrice(message));
        }

        private void CalculateTotalPrice(OrderMessage message)
        {
            var tasks = message.Names
                .Select(x => Context.ActorOf<OrderPriceActor>().Ask<decimal>(x))
                .ToArray();

            Task.WaitAll(tasks);

            Console.WriteLine("Total price: ${0}", tasks.Sum(x => x.Result));
        }
    }
}
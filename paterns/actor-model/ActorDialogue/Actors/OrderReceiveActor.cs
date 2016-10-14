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

        private bool CalculateTotalPrice(OrderMessage message)
        {
            var tasks = message.Names.Select(x => Context.ActorOf<OrderPriceActor>().Ask<decimal>(x));

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Total price: ${0}", tasks.Sum(x => x.Result));

            return true;
        }
    }
}
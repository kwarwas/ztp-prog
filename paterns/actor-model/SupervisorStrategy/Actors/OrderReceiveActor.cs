using Akka.Actor;
using ActorRouters.Messages;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace ActorRouters.Actors
{
    public class OrderReceiveActor : ReceiveActor
    {
        IActorRef actor;
        public OrderReceiveActor()
        {
            Receive<OrderMessage>(message => CalculateTotalPrice(message));

            actor = Context.ActorOf<OrderPriceActor>();
        }

        private bool CalculateTotalPrice(OrderMessage message)
        {
            //var tasks = message.Names.Select(x => Context.ActorOf<OrderPriceActor>().Ask<decimal>(x));

            //Task.WaitAll(tasks.ToArray());

            //Console.WriteLine("Total price: ${0}", tasks.Sum(x => x.Result));

            actor.Tell(message.Names.First());

            return true;
        }

        //protected override Akka.Actor.SupervisorStrategy SupervisorStrategy()
        //{
        //    return new OneForOneStrategy( //or AllForOneStrategy
        //     maxNrOfRetries: 10,
        //     withinTimeRange: TimeSpan.FromSeconds(30),
        //     decider: Decider.From(x =>
        //     {
        //         //Maybe we consider ArithmeticException to not be application critical
        //         //so we just ignore the error and keep going.
        //         if (x is ArithmeticException)
        //         {
        //             Console.WriteLine("Resume");
        //             return Directive.Resume;
        //         }

        //         //Error that we cannot recover from, stop the failing actor
        //         else if (x is NotSupportedException) return Directive.Stop;

        //         //In all other cases, just restart the failing actor
        //         else return Directive.Restart;
        //     }));
        //}
    }
}
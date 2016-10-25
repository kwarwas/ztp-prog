using ActorSupervisorStrategy.Messages;
using Akka.Actor;

namespace ActorSupervisorStrategy.Actors
{
    public class OrderReceiveActor : ReceiveActor
    {
        IActorRef actor = Context.ActorOf<OrderPriceActor>();

        public OrderReceiveActor()
        {
            Receive<OrderMessage>(message => actor.Tell(message.Name));
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
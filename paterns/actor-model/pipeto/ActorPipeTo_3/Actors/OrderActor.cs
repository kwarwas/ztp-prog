using Akka.Actor;
using System;
using System.Threading.Tasks;
using ActorPipeTo.Messages;

namespace ActorPipeTo.Actors
{
    public class OrderActor : ReceiveActor
    {
        public OrderActor()
        {
            Receive<OrderMessage>(x => Handle(x));
        }

        public void Handle(OrderMessage message)
        {
            Console.WriteLine("Receive message: {0}", message.Id);
            Console.WriteLine("Processing message: {0}", message.Id);
            Process(message).PipeTo(Sender);
        }

        async Task<Guid> Process(OrderMessage message)
        {
            return await Task.Delay(TimeSpan.FromSeconds(1))
                .ContinueWith(x =>
                {
                    Console.WriteLine("Message {0} processed", message.Id);
                    return Guid.NewGuid();
                });
        }
    }
}
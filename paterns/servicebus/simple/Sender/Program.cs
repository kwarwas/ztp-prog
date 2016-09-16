using MassTransit;
using Messaging;
using System;
using System.Threading.Tasks;

namespace Sender
{
    class SendObserver : ISendObserver
    {
        public Task PostSend<T>(SendContext<T> context) where T : class
        {
            return Console.Out.WriteLineAsync($"PostSend: {context.MessageId}");
        }

        public Task PreSend<T>(SendContext<T> context) where T : class
        {
            return Console.Out.WriteLineAsync($"PreSend: {context.MessageId}");
        }

        public Task SendFault<T>(SendContext<T> context, Exception exception) where T : class
        {
            return Console.Out.WriteLineAsync($"Fault: {exception.Message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), hostCfg =>
                {
                    hostCfg.Username("guest");
                    hostCfg.Password("guest");
                });
            });

            var endpoint = bus.GetSendEndpoint(new Uri("rabbitmq://localhost/order.service")).Result;

            bus.ConnectSendObserver(new SendObserver());

            var guid = Guid.NewGuid();

            endpoint.Send<IOrderMessage>(new
            {
                Name = $"Order {guid}",
                Weight = 134.5
            }).Wait();

            Console.WriteLine($"Order {guid} sent");

            Console.WriteLine("Finish");
        }
    }
}

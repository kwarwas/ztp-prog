using MassTransit;
using Messaging;
using System;

namespace Receiver
{
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

                cfg.ReceiveEndpoint(host, "order.service", e =>
                {
                    e.Handler<IOrderMessage>(x => Console.Out.WriteLineAsync($"Handler: {x.Message.Name}"));
                });
            });
            
            bus.Start();

            Console.WriteLine("Bus started");

            Console.ReadLine();

            bus.Stop();

            Console.WriteLine("Bus stoped");
        }
    }
}

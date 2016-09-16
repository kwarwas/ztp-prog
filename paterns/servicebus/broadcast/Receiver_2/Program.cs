using MassTransit;
using Messaging;
using System;
using Serilog;

namespace Receiver_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.UseSerilog(logger);

                var host = cfg.Host(new Uri("rabbitmq://localhost/"), hostCfg =>
                {
                    hostCfg.Username("guest");
                    hostCfg.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "order.service.2", e =>
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

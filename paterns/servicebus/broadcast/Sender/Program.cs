using MassTransit;
using Messaging;
using Serilog;
using System;

namespace Sender
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
            });

            var guid = Guid.NewGuid();

            bus.Start();

            bus.Publish<IOrderMessage>(new
            {
                Name = $"Order {guid}",
                Weight = 134.5
            });

            Console.WriteLine($"Order {guid} sent");

            Console.ReadLine();

            bus.Stop();

            Console.WriteLine("Finish");
        }
    }
}

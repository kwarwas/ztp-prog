using System;
using Akka.Persistence;
using System.Collections.Generic;
using System.Linq;
using ActorPersistence.Commands;
using ActorPersistence.Events;

namespace ActorPersistence.Actors
{
    public class OrderActor : ReceivePersistentActor
    {
        private int _counter = 0;
        public string OrderId { get; }
        public List<OrderDetailsAdded> OrderDetails { get; private set; }

        public override string PersistenceId { get; }
        
        public OrderActor(string orderId)
        {
            PersistenceId = $"Order_{orderId}";
            OrderId = orderId;
            OrderDetails = new List<OrderDetailsAdded>();

            Recover<OrderDetailsAdded>(message =>
            {
                Console.WriteLine("RECOVER message: {0} {1}", message.Name, message.Price);
                OrderDetails.Add(message);
            });

            Recover<SnapshotOffer>(offer =>
            {
                Console.WriteLine("RECOVER FROM SNAPSHOT");
                var orders = offer.Snapshot as List<OrderDetailsAdded>;

                if (orders != null)
                {
                    OrderDetails.AddRange(orders);
                }
            });

            Command<AddOrderDetails>(command => HandleOrderDetails(command));
            Command<CalculatePrice>(command => HandlePrice(command));
            Command<ThrowError>(command => HandleError(command));
        }

        private void HandleOrderDetails(AddOrderDetails command)
        {
            Console.WriteLine("Receive message: {0} {1}", command.Name, command.Price);

            var orderDetails = new OrderDetailsAdded(command.Name, command.Price);

            Persist(orderDetails, x =>
            {
                Console.WriteLine("PERSIST message: {0} {1}", orderDetails.Name, orderDetails.Price);
                OrderDetails.Add(x);

                if (++_counter == 5)
                {
                    Console.WriteLine("SAVE SNAPSHOT");
                    SaveSnapshot(OrderDetails);
                    _counter = 0;
                }
            });
        }

        private void HandlePrice(CalculatePrice command)
        {
            Console.WriteLine("Total price: {0}", OrderDetails.Sum(x => x.Price));
        }

        private void HandleError(ThrowError message)
        {
            throw new Exception();
        }
    }
}
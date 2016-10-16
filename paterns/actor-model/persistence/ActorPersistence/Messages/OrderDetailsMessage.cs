namespace ActorPersistence.Messages
{
    public class OrderDetailsMessage
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public OrderDetailsMessage(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}

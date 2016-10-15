namespace ActorScheduler.Messages
{
    public class OrderMessage
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public OrderMessage(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

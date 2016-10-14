using System.Collections.Immutable;

namespace ActorRouters.Messages
{
    public class OrderMessage
    {
        public int Id { get; private set; }
        public ImmutableArray<string> Names { get; set; }

        public OrderMessage(int id, string[] names)
        {
            Id = id;
            Names = names.ToImmutableArray();
        }
    }
}

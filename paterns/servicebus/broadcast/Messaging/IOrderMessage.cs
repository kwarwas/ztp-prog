namespace Messaging
{
    public interface IOrderMessage
    {
        string Name { get; set; }
        double Weight { get; set; }
    }
}

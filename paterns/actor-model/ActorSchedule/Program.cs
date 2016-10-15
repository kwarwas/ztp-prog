using ActorSchedule.Actors;
using Akka.Actor;

namespace ActorSchedule
{
    public class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("ActorSchedule");

            var actor = system.ActorOf<OrderActor>();

            system.WhenTerminated.Wait();
        }
    }
}

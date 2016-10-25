using Akka.Actor;

namespace RemoteActor.Remote
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("RemoteActor");

            system.WhenTerminated.Wait();
        }
    }
}

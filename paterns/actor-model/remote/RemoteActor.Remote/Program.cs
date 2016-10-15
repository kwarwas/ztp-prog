using Akka.Actor;

namespace ActorStashing
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


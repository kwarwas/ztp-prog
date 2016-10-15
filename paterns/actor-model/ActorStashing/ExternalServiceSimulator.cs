using System;
using System.Threading.Tasks;
using ActorStashing.Messages;

namespace ActorStashing
{
    class ExternalServiceSimulator
    {
        private int counter = 0;

        public bool IsBusy
        {
            get
            {
                return ++counter == 2 || counter == 3;
            }
        }

        public void Proccess(OrderMessage message)
        {
            Console.WriteLine("Message {0} processing", message.Id);
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
        }
    }
}

using ActorThrowsException.Actors;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorThrowsException
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem actorSystem = ActorSystem.Create("AS");

            IActorRef actor1 = actorSystem.ActorOf<Parent>();
            IActorRef actor2 = actorSystem.ActorOf<StandAloneActor>();

            for (int i = 0; i < 3; i++)
            {
                actor1.Tell(new TestMessage() { Id = i });
                actor2.Tell(new TestMessage() { Id = i });
            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}

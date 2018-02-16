using Akka.Actor;
using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RouterActors
{
    class Program
    {
        static void Main(string[] args)
        {
            bool waitForTermination = true;
            Console.WriteLine("Starting...");

            ActorSystem actorSystem = ActorSystem.Create("main");
            actorSystem.RegisterOnTermination(() => { waitForTermination = false; });

            IActorRef actor = actorSystem.ActorOf(Props.Create(() => new DoNothingActor())
                    .WithRouter(new RoundRobinPool(10)), "doNothingActorPool");

            for (int i = 0; i < 20; i++)
            {
                actor.Tell(i + 1);
            }

            while (waitForTermination)
            {
                Console.WriteLine("... working...");
                Thread.Sleep(10 * 1000);
            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}

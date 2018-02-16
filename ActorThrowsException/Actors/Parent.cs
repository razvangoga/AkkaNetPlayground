using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorThrowsException.Actors
{
    public class Parent : ReceiveActor
    {
        private IActorRef _child;

        public Parent()
        {
            this._child = Context.ActorOf<Child>();

            this.Receive<TestMessage>(m => this.OnMessageRecieved(m));
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy( //or AllForOneStrategy
                                          //maxNrOfRetries: 10,                
                                          //duration: TimeSpan.FromSeconds(30),
                decider: Decider.From(x =>
                {
                    Console.WriteLine($"Parent Decider -> {x.ToString()}");

                    //Maybe we consider ArithmeticException to not be application critical
                    //so we just ignore the error and keep going.
                    //if (x is ArithmeticException) return Directive.Resume;

                    //Error that we cannot recover from, stop the failing actor
                    //else if (x is NotSupportedException) return Directive.Stop;

                    //In all other cases, just restart the failing actor
                    //else 
                        return Directive.Resume;
                }));
        }

        private void OnMessageRecieved(TestMessage m)
        {
            this._child.Tell(m);
        }
    }
}

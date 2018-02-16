using ActorThrowsException.Exceptions;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorThrowsException.Actors
{
    public class Child : ReceiveActor
    {
        public Child()
        {
            this.Receive<TestMessage>(m => this.OnMessageRecieved(m));
        }

        private void OnMessageRecieved(TestMessage m)
        {
            throw new EpicFailException($"Some epic fail for child {m.Id}");
        }

        //protected override void PreRestart(Exception reason, object message)
        //{
        //    Console.WriteLine($"Child PreRestart -> {reason.Message}");
        //}
    }
}

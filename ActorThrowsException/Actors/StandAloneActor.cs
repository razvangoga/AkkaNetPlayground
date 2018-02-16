using ActorThrowsException.Exceptions;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorThrowsException.Actors
{
    public class StandAloneActor : ReceiveActor
    {
        public StandAloneActor()
        {
            this.Receive<TestMessage>(m => this.RecieveAndHandleException(this.OnMessageRecieved, m));
        }

        private void OnMessageRecieved(TestMessage m)
        {
            throw new EpicFailException($"Some epic fail for stand alone {m.Id}");
        }

        private void RecieveAndHandleException<T>(Action<T> handler, T message)
        {
            try
            {
                handler(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Handled - {ex.Message}");
                //Console.WriteLine(ex.ToString());
            }
        }

    }
}

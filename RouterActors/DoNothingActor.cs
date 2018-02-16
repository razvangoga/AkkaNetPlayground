using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RouterActors
{
    public class DoNothingActor : ReceiveActor
    {
        private static Random _random = new Random(21);

        public DoNothingActor()
        {
            this.ReceiveAsync<int>(DoNothing);
        }

        private async Task DoNothing(int m)
        {
            int seconds = _random.Next(10, 30);
            Console.WriteLine($"starting {m} - waiting for {seconds}s");
            Thread.Sleep(seconds * 1000);
            Console.WriteLine($"finished {m} - waited  for {seconds}s");
            if (m == 20)
                await Context.System.Terminate();
        }
    }
}

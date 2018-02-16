using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorThrowsException.Actors
{
    public class TestMessage
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Message : {this.Id}";
        }
    }
}

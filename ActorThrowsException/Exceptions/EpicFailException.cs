using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorThrowsException.Exceptions
{
    public class EpicFailException : Exception
    {
        public EpicFailException(string message) : base(message)
        {

        }
    }
}

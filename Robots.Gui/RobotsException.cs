using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui
{
    public class RobotsException : Exception
    {
        public RobotsException()
        {
        }

        public RobotsException(string message) : base(message)
        {
        }

        public RobotsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RobotsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

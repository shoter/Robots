using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public readonly struct RobotLogEntry
    {
        public string Message { get; }
        public DateTime Time { get; }

        public RobotLogEntry(string msg) : this(msg, DateTime.Now) { }

        public RobotLogEntry(string msg, DateTime time)
        {
            this.Message = msg;
            this.Time = time;
        }
        
    }
}

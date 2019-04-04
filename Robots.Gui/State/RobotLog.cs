using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public class RobotLog : IRobotLog
    {
        public List<string> MessagesList { get; } = new List<string>();

        public IEnumerable<string> Messages => MessagesList;

        public RobotLog() { }

        public IRobotLog AddMessage(string msg)
        {
            MessagesList.Add(msg);
            return this;
        }

        public IRobotLog Clear()
        {
            MessagesList.Clear();
            return this;
        }
    }
}

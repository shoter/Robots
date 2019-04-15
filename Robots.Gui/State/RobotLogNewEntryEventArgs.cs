using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public class RobotLogNewEntryEventArgs
    {
        public RobotLogEntry NewEntry { get; }

        public RobotLogNewEntryEventArgs(RobotLogEntry entry)
        {
            this.NewEntry = entry;
        }
    }
}

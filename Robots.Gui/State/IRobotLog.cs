using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public interface IRobotLog
    {
        IEnumerable<RobotLogEntry> Entries { get; }

        IRobotLog AddEntry(RobotLogEntry entry);

        IRobotLog Clear();
    }
}

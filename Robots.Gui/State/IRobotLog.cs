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

        event EventHandler<RobotLogNewEntryEventArgs> NewEntry;

        event EventHandler EntriesCleared;

        IRobotLog AddEntry(RobotLogEntry entry);

        IRobotLog Clear();
    }
}

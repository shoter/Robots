using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public class RobotLog : IRobotLog
    {
        public List<RobotLogEntry> MessagesList { get; } = new List<RobotLogEntry>();

        public IEnumerable<RobotLogEntry> Entries => MessagesList;

        public event EventHandler<RobotLogNewEntryEventArgs> NewEntry;

        public event EventHandler EntriesCleared;

        public IRobotLog AddEntry(RobotLogEntry entry)
        {
            MessagesList.Add(entry);

            NewEntry?.Invoke(this, new RobotLogNewEntryEventArgs(entry));

            return this;
        }

        public IRobotLog Clear()
        {
            MessagesList.Clear();

            EntriesCleared?.Invoke(this, EventArgs.Empty);
            return this;
        }
    }
}

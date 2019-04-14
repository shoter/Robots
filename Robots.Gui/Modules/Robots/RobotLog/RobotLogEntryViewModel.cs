using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotLog
{
    public class RobotLogEntryViewModel : IRobotLogEntryViewModel
    {
        public DateTime Time { get; }

        public string Text { get; }

        public RobotLogEntryViewModel(string text) : this(text, DateTime.Now) { }

        public RobotLogEntryViewModel(string text, DateTime time)
        {
            this.Time = time;
            this.Text = text;
        }

        public RobotLogEntryViewModel(RobotLogEntry entry) : this(entry.Message, entry.Time) { }
    }
}

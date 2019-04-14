using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotLog
{
    public interface IRobotLogViewModel
    {
        IEnumerable<IRobotLogEntryViewModel> Entries { get; }

        /// <summary>
        /// Assigns Robot log to this viewmodel. It will take all entries from log.
        /// </summary>
        /// <param name="log"></param>
        void SetLog(IRobotLog log);

        void AddEntry(IRobotLogEntryViewModel entry);

        /// <summary>
        /// Removes all entries
        /// </summary>
        void Clear();
    }
}

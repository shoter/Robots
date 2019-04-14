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

        void AddEntry(IRobotLogEntryViewModel entry);

        /// <summary>
        /// Removes all entries
        /// </summary>
        void Clear();
    }
}

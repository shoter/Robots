using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotLog
{
    public interface IRobotLogEntryViewModel
    {
        DateTime Time { get; }
        string Text { get; }
    }
}

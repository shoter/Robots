using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotList
{
    public interface IRobotListItemViewModel
    {
        ulong Id { get; }

        string DisplayName { get; }

        /// <summary>
        /// Displays robot status - if idle or if it is running the program
        /// </summary>
        string Status { get; }

        event EventHandler<RobotListItemEventArgs> RobotSelected;
    }
}

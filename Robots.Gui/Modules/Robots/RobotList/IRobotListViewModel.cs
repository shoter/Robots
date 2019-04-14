using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotList
{
    public interface IRobotListViewModel
    {
        IEnumerable<IRobotListItemViewModel> Robots { get; }

        event EventHandler<RobotListItemEventArgs> RobotSelected;
    }
}

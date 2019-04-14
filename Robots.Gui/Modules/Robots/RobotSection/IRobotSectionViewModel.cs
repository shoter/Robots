using Robots.Gui.Modules.Robots.RobotList;
using Robots.Gui.Modules.Robots.RobotView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotSection
{
    public interface IRobotSectionViewModel
    {
        IRobotListViewModel RobotList { get; }
        IRobotViewViewModel RobotView { get; }
    }
}

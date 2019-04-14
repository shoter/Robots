using Robots.Gui.Modules.Robots.RobotLog;
using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotView
{
    public interface IRobotViewViewModel
    {
        IRobotLogViewModel RobotLog { get; }

        void SetRobot(IRobotState robot);
    }
}

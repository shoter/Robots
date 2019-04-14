using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotList
{
    public class RobotListItemEventArgs : EventArgs
    {
        public IRobotState Robot { get; }

        public RobotListItemEventArgs(IRobotState robot)
        {
            this.Robot = robot;
        }

    }
}

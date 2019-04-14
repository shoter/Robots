using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Robots.Gui.Modules.Robots.RobotLog;
using Robots.Gui.State;

namespace Robots.Gui.Modules.Robots.RobotView
{
    public class RobotViewViewModel : IRobotViewViewModel
    {
        public IRobotLogViewModel RobotLog { get; }

        public RobotViewViewModel() { }

        [Inject]
        public RobotViewViewModel(IRobotLogViewModel robotLog)
        {
            this.RobotLog = robotLog;
        }

        public void SetRobot(IRobotState robot)
        {
            throw new NotImplementedException();
        }
    }
}

using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotList
{
    public class RobotListItemViewModel : IRobotListItemViewModel
    {
        private readonly IRobotState robot;

        public event EventHandler<RobotListItemEventArgs> RobotSelected;

        public string DisplayName => $"Robot {robot.Id}";

        public ulong Id => robot.Id;

        public string Status => robot.Status;


        public RobotListItemViewModel() { }

        public RobotListItemViewModel(IRobotState robot)
        {
            this.robot = robot;
        }

        public void SelectRobot()
        {
            RobotSelected?.Invoke(this, new RobotListItemEventArgs(robot));
        }

        
    }
}

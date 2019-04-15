using Robots.Gui.Base;
using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotList
{
    public class RobotListItemViewModel : ViewModelBase, IRobotListItemViewModel
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
            this.robot.PropertyChanged += robot_PropertyChanged;

        }

        private void robot_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IRobotState.Status))
                NotifyPropertiesChanged(nameof(Status));
        }

        public void SelectRobot()
        {
            RobotSelected?.Invoke(this, new RobotListItemEventArgs(robot));
        }

        
    }
}

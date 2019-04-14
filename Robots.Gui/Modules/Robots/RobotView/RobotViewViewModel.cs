using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ninject;
using Robots.Core.Programs;
using Robots.Gui.Base;
using Robots.Gui.Modules.Robots.RobotLog;
using Robots.Gui.State;

namespace Robots.Gui.Modules.Robots.RobotView
{
    public class RobotViewViewModel : ViewModelBase, IRobotViewViewModel
    {
        public IRobotLogViewModel RobotLog { get; }

        private IRobotState Robot { get; set; } = null;

        public List<IRobotViewProgramViewModel> Programs { get; } = new List<IRobotViewProgramViewModel>();


        private IRobotViewProgramViewModel selectedProgram = null;
        public IRobotViewProgramViewModel SelectedProgram
        {
            get => selectedProgram;
            set
            {
                selectedProgram = value;
                Robot.AssignProgram(value.Program);
                NotifyPropertyChanged();
            }
        }

        public string RobotName => $"Robot {Robot?.Id}";

        public Visibility Visibility => Robot == null ? Visibility.Hidden : Visibility.Visible;

        public RobotViewViewModel() { }

        [Inject]
        public RobotViewViewModel(IApplicationState state, IRobotLogViewModel robotLog)
        {
            this.RobotLog = robotLog;

            foreach (var p in state.Programs)
            {
                Programs.Add(new RobotViewProgramViewModel(p));
            }
        }

        public void SetRobot(IRobotState robot)
        {
            Robot = robot;
            RobotLog.SetLog(robot.RobotLog);
            selectedProgram = null;

            foreach (var p in Programs)
            {
                if (p.Program == robot.AssignedProgram)
                {
                    selectedProgram = p;
                    break;
                }
            }

            NotifyPropertiesChanged(nameof(Visibility), nameof(SelectedProgram), nameof(RobotName));
        }
    }
}
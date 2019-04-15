using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Ninject;
using Robots.Core.ProgramExecution;
using Robots.Core.Programs;
using Robots.Gui.Base;
using Robots.Gui.Commands;
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

        public bool IsProgramModificationEnabled
        {
            get
            {
                if(Robot?.IsProgramRunning ?? false)
                {
                    return false;
                }

                return true;
            }
        }

        public string Status => Robot?.Status;

        public string RobotName => $"Robot {Robot?.Id}";

        public Visibility Visibility => Robot == null ? Visibility.Hidden : Visibility.Visible;

        private static ICommand startProgramCommand;

        public ICommand StartProgramCommand => startProgramCommand;

        public RobotViewViewModel() { }

        static RobotViewViewModel()
        {
            startProgramCommand = new ActionCommand<RobotViewViewModel>(startProgram, canStartProgram);
        }

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

            NotifyPropertiesChanged(nameof(Visibility), nameof(Status), nameof(SelectedProgram), nameof(RobotName), nameof(IsProgramModificationEnabled));
        }

        private static void startProgram(RobotViewViewModel vm)
        {
            var r = vm.Robot;

            var executor = r.RunProgram();

            executor.ProgramExecutionEnd += vm.onProgramEnd;

            vm.NotifyPropertiesChanged(nameof(IsProgramModificationEnabled), nameof(Status));
        }

        private static bool canStartProgram(RobotViewViewModel vm)
        {
            var r = vm.Robot;

            if (r != null && r.AssignedProgram != null && r.IsProgramRunning == false)
                return true;
            return false;
        }

        private void onProgramEnd(object sender, EventArgs e)
        {
            IProgramExecutor executor = sender as IProgramExecutor;

            // Remember that robot can be changed!

            if(Robot.Robot == executor.Robot)
            {
                NotifyPropertiesChanged(nameof(IsProgramModificationEnabled), nameof(Status), nameof(IsProgramModificationEnabled));
            }
            App.Current.Dispatcher.Invoke(() =>
                        CommandManager.InvalidateRequerySuggested()
                        );
        }
    }
}
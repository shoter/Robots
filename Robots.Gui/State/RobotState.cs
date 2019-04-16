using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Common;
using Robots.Core;
using Robots.Core.ProgramExecution;
using Robots.Core.Programs;
using Robots.SDK;

namespace Robots.Gui.State
{
    public class RobotState : IRobotState, INotifyPropertyChanged
    {
        public string Name { get; set; }

        public ulong Id { get; }

        private static UniqueIdGenerator uniqueId = new UniqueIdGenerator();

        public IRobot Robot { get; }

        public IProgram AssignedProgram { get; private set; } = null;

        public IRobotLog RobotLog { get; }

        private IProgramExecutor ProgramExecutor { get; set; } = null;

        public bool IsProgramRunning => ProgramExecutor?.IsCompleted == false;

        public string Status
        {
            get
            {
                if (IsProgramRunning == false)
                    return "Idle";
                return $"Running {AssignedProgram.Name}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IProgramExecutionService programExecutionService;

        public RobotState(IProgramExecutionService programExecutionService, IRobot robot, IRobotLog robotLog)
        {
            this.programExecutionService = programExecutionService;
            this.Robot = robot;
            this.RobotLog = robotLog;
            this.Id = uniqueId.Id;
            this.Name = $"Robot {Id}";
        }

        public void AssignProgram(IProgram program)
        {
            // This is so dirty... Waiting for C# 8.0 and non-nullable references. Then code will be super tidy!
            Debug.Assert(program != null);
            if (CanAssignProgram() == false)
                throw new RobotsException("Cannot assign program!");

            this.AssignedProgram = program;
        }

        public bool CanAssignProgram() => !IsProgramRunning;

        public IProgramExecutor RunProgram()
        {
            if (IsProgramRunning)
                throw new RobotsException("Robot cannot run 2 programs at same time!");
            RobotLog.Clear();


            ProgramExecutor = programExecutionService.Execute(AssignedProgram, Robot);

            RobotLog.AddEntry(new RobotLogEntry($"Program {AssignedProgram} execution started!"));

            ProgramExecutor.ProgramExecutionEnd += onProgramExecutionEnd;

            ProgramExecutor.CommandExecutionStart += programExecutor_CommandExecutionStart;
            ProgramExecutor.CommandExecutionEnd += programExecutor_CommandExecutionEnd;

            notifyPropertiesChanged(nameof(Status));

            return ProgramExecutor;
        }

        private void programExecutor_CommandExecutionEnd(object sender, ProgramExecutorCommandEventArgs e)
        {
            RobotLog.AddEntry(new RobotLogEntry($"Completed execution of command: {e.Command.Describe()}."));
        }

        private void programExecutor_CommandExecutionStart(object sender, ProgramExecutorCommandEventArgs e)
        {
            RobotLog.AddEntry(new RobotLogEntry($"Starting execution of command: {e.Command.Describe()}."));
        }

        private void onProgramExecutionEnd(object sender, EventArgs e)
        {
            var exec = sender as IProgramExecutor;

            exec.ProgramExecutionEnd -= onProgramExecutionEnd;

            RobotLog.AddEntry(new RobotLogEntry($"Program {exec.Program.Name} execution completed!"));

            notifyPropertiesChanged(nameof(Status));
        }

        public void DeassignProgram()
        {
            if (CanAssignProgram() == false)
                throw new RobotsException("Cannot deassign program! Program is already running!");

            this.AssignedProgram = null;
        }

        private void notifyPropertiesChanged(params string[] props)
        {
            foreach (var p in props)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
    }
}

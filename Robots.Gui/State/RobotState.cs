using System;
using System.Collections.Generic;
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
    public class RobotState : IRobotState
    {
        public string Name { get; set; }

        public ulong Id { get; }

        private static UniqueIdGenerator uniqueId = new UniqueIdGenerator();

        public IRobot Robot { get; }

        public IProgram AssignedProgram { get; private set; } = null;

        public IRobotLog RobotLog { get; }

        public bool IsProgramRunning { get; private set; } = false;

        public string Status
        {
            get
            {
                if (IsProgramRunning == false)
                    return "Idle";
                return $"Running {AssignedProgram.Name}";
            }
        }

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

            IsProgramRunning = true;
            var executor = programExecutionService.Execute(AssignedProgram, Robot);

            executor.ProgramExecutionEnd += onProgramExecutionEnd;

            return executor;
        }

        private void onProgramExecutionEnd(object sender, EventArgs e)
        {
            var exec = sender as IProgramExecutor;

            IsProgramRunning = false;
            exec.ProgramExecutionEnd -= onProgramExecutionEnd;
        }

        public void DeassignProgram()
        {
            if (CanAssignProgram() == false)
                throw new RobotsException("Cannot deassign program! Program is already running!");

            this.AssignedProgram = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Core.Common;
using Robots.Core.Programs;
using Robots.SDK;

namespace Robots.Gui.State
{
    public class RobotState : IRobotState
    {
        public ulong Id { get; }

        private static UniqueIdGenerator uniqueId = new UniqueIdGenerator();

        public IRobot Robot { get; }

        public IProgram AssignedProgram { get; private set; } = null;

        public IRobotLog RobotLog { get; }

        public bool IsProgramRunning { get; private set; } = false;

        public RobotState(IRobot robot, IRobotLog robotLog)
        {
            this.Robot = robot;
            this.RobotLog = robotLog;
            this.Id = uniqueId.Id;
        }

        public void AssignProgram(IProgram program)
        {
            if (CanAssignProgram() == false)
                throw new RobotsException("Cannot assign program!");
            this.AssignedProgram = program;
        }

        public bool CanAssignProgram() => !IsProgramRunning;

        public void RunProgram()
        {
            if (IsProgramRunning)
                throw new RobotsException("Robot cannot run 2 programs at same time!");

            IsProgramRunning = true;
            AssignedProgram.Start(Robot);
            AssignedProgram.OnProgramExecutionEnd += onProgramExecutionEnd;
        }

        private void onProgramExecutionEnd(object sender, ProgramEventArgs e)
        {
            if (Robot != e.Robot)
                return;

            IsProgramRunning = false;
            AssignedProgram.OnProgramExecutionEnd -= onProgramExecutionEnd;
        }
    }
}

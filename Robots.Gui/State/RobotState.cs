using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Core.Programs;
using Robots.SDK;

namespace Robots.Gui.State
{
    public class RobotState : IRobotState
    {
        public IRobot Robot { get; }

        public IProgram AssignedProgram { get; private set; }

        public bool IsProgramRunning { get; private set; }

        public void RunProgram()
        {
            Debug.Assert(IsProgramRunning == false);

            IsProgramRunning = true;
            AssignedProgram.Start(Robot);
            AssignedProgram.OnProgramExecutionEnd += onProgramExecutionEnd;

        }

        private void onProgramExecutionEnd(object sender, EventArgs e)
        {
            if(Robot != e.)
            IsProgramRunning = false;
            AssignedProgram.OnProgramExecutionEnd -= onProgramExecutionEnd;
        }
    }
}

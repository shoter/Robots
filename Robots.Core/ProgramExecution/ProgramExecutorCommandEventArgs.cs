using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.ProgramExecution
{
    public class ProgramExecutorCommandEventArgs
    {
        public IProgramCommand Command { get; }
        public IProgram Program { get; }
        public IRobot Robot { get; }

        public ProgramExecutorCommandEventArgs(IProgramCommand command, IProgram program, IRobot robot)
        {
            this.Command = command;
            this.Program = program;
            this.Robot = robot;
        }
    }
}

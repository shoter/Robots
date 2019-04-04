using Robots.SDK;
using System;

namespace Robots.Core.Programs
{
    public class ProgramCommandEventArgs : ProgramEventArgs 
    {
        public IProgramCommand Command { get; }

        public ProgramCommandEventArgs(IRobot robot, IProgramCommand command) : base(robot)
        {
            this.Command = command;
        }
    }
}

using System;

namespace Robots.Core.Programs
{
    public class ProgramCommandEventArgs : EventArgs
    {
        public IProgramCommand Command { get; }

        public ProgramCommandEventArgs(IProgramCommand command)
        {
            this.Command = command;
        }
    }
}

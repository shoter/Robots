using System;

namespace Robots.Core.Programs
{
    public class ProgramCommandEventArgs : EventArgs
    {
        public ICommand Command { get; }

        public ProgramCommandEventArgs(ICommand command)
        {
            this.Command = command;
        }
    }
}

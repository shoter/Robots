using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ProgramCommandList
{
    public class ProgramCommandItemEventArgs : EventArgs
    {
        public IProgramCommand Command { get; }

        public ProgramCommandItemEventArgs(IProgramCommand command)
        {
            this.Command = command;
        }
    }
}

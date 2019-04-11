using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.AddProgram.CommandList
{
    public class AddCommandEventArgs : EventArgs
    {
        public IProgramCommand Command { get; }

        public AddCommandEventArgs(IProgramCommand command)
        {
            this.Command = command;
        }
    }
}

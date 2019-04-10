using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.AddProgram.CommandList
{
    public class CommandListStateEventArgs
    {
        public CommandListState State { get; }

        public CommandListStateEventArgs(CommandListState state)
        {
            this.State = state;
        }
        
    }
}

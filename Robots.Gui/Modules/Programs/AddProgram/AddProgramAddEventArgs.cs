using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Robots.Gui.Modules.Programs.AddProgram
{
    public class AddProgramAddEventArgs : EventArgs
    {
        public ICommand Command { get; }

        public AddProgramAddEventArgs(ICommand command)
        {
            this.Command = command;
        }
        
    }
}

using Robots.Gui.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Robots.Gui.Modules.Programs.AddProgram.CommandList
{
    public abstract class CommandListBaseViewModel : ViewModelBase
    {
        public event EventHandler<AddProgramAddEventArgs> AddProgram;
        public event EventHandler<CommandListStateEventArgs> Transition;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Robots.Gui.Modules.Programs.ProgramCommandList
{
    public interface IProgramCommandListItemViewModel
    {
        string DisplayName { get; }

        event EventHandler<ProgramCommandItemEventArgs> CommandRemove;

        ICommand CommandRemoveCommand { get; }
    }
}

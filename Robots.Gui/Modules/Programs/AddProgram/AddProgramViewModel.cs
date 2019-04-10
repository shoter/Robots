using Robots.Gui.Base;
using Robots.Gui.Modules.Programs.AddProgram.CommandList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.AddProgram
{
    public class AddProgramViewModel
    {
        public event EventHandler<AddProgramAddEventArgs> AddProgram;

        public ViewModelBase CommandAddViewModel { get; private set; }

        public CommandListState CommandState { get; private set; } = CommandListState.Buttons;

        public void ProceedToAddMoveCommand()
        {

        }

    }
}

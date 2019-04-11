using Robots.Core.Programs;
using Robots.Gui.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Robots.Gui.Modules.Programs.ProgramCommandList
{
    public class  ProgramCommandListItemViewModel
    {
        private readonly IProgramCommand command;

        public string DisplayName => command.Describe();

        public event EventHandler<ProgramCommandItemEventArgs> CommandRemove;

        public ICommand CommandRemoveCommand { get; }

        public ProgramCommandListItemViewModel(IProgramCommand command)
        {
            this.command = command;
            this.CommandRemoveCommand = new ActionCommand<ProgramCommandListItemViewModel>(onCommandRemove);
        }

        private static void onCommandRemove(ProgramCommandListItemViewModel item)
        {
            item.CommandRemove?.Invoke(item, new ProgramCommandItemEventArgs(item.command));
        }
    }
}

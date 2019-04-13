using Robots.Core.Programs;
using Robots.Gui.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Robots.Gui.Modules.Programs.AddProgram.CommandList
{
    public class CommandListViewModel : CommandListBaseViewModel
    {
        public ICommand MoveCommand { get; }
        public ICommand TurnCommand { get; }
        public ICommand BeepCommand { get; }

        public CommandListViewModel()
        {
            MoveCommand = new ActionCommand<CommandListViewModel>(x => TransitionInvoke(CommandListState.Move));
            TurnCommand = new ActionCommand<CommandListViewModel>(x => x.TransitionInvoke(CommandListState.Turn));
            BeepCommand = new ActionCommand<CommandListViewModel>(x => x.AddCommandInvoke(new BeepCommand()));
        }
    }
}


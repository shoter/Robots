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
    public class CommandMoveViewModel : CommandListBaseViewModel
    {
        public double? Distance { get; set; }
        public string Hint { get; } = "Distance";
        
        public static ICommand AddMoveCommand { get; }
        public static ICommand BackCommand { get; }

        static CommandMoveViewModel()
        {
            BackCommand = new ActionCommand<CommandMoveViewModel>(item => item.TransitionInvoke(CommandListState.Buttons));
            AddMoveCommand = new ActionCommand<CommandMoveViewModel>(onAddMove, canAdd);
        }

        private static bool canAdd(CommandMoveViewModel item)
        {
            return item.Distance.HasValue && item.IsAddingCommandsEnabled;
        }

        private static void onAddMove(CommandMoveViewModel item)
        {
            item.AddCommandInvoke(new MoveCommand(item.Distance.Value));
            item.TransitionInvoke(CommandListState.Buttons);
        }
    }
}

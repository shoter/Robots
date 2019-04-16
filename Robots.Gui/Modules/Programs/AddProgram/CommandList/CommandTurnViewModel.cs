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
    public class CommandTurnViewModel : CommandListBaseViewModel
    {
        public double? Angle { get; set; }
        public string Hint { get; } = "Angle";

        public static ICommand AddTurnCommand { get; }
        public static ICommand BackCommand { get; }

        static CommandTurnViewModel()
        {
            BackCommand = new ActionCommand<CommandTurnViewModel>(item => item.TransitionInvoke(CommandListState.Buttons));
            AddTurnCommand = new ActionCommand<CommandTurnViewModel>(onAddMove, canAdd);

        }

        private static bool canAdd(CommandTurnViewModel item)
        {
            return item.Angle.HasValue && item.IsAddingCommandsEnabled;
        }

        private static void onAddMove(CommandTurnViewModel item)
        {
            item.AddCommandInvoke(new TurnCommand(item.Angle.Value));
            item.TransitionInvoke(CommandListState.Buttons);
        }
    }
}

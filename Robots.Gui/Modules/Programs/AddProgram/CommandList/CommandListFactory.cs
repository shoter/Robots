using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Robots.Gui.Base;

namespace Robots.Gui.Modules.Programs.AddProgram.CommandList
{
    public class CommandListFactory : ICommandListFactory
    {
        public UserControl CreateControl(CommandListState state)
        {
            switch (state)
            {
                case CommandListState.Buttons:
                    return new CommandListControl();
                case CommandListState.Move:
                    return new CommandMoveControl();
                case CommandListState.Turn:
                    return new CommandTurnControl();
            }
            throw new NotImplementedException(nameof(state));
        }

        public CommandListBaseViewModel CreateViewModel(CommandListState state)
        {
            switch (state)
            {
                case CommandListState.Buttons:
                    return new CommandListViewModel();
                case CommandListState.Move:
                    return new CommandMoveViewModel();
                case CommandListState.Turn:
                    return new CommandTurnViewModel();
            }
            throw new NotImplementedException(nameof(state));
        }
    }
}
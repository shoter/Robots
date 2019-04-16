using Robots.Core.Programs;
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
        public event EventHandler<AddCommandEventArgs> AddProgram;
        public event EventHandler<CommandListStateEventArgs> Transition;

        private bool isAddingCommandsEnabled = true;
        public bool IsAddingCommandsEnabled
        {
            get => isAddingCommandsEnabled;
            set
            {
                isAddingCommandsEnabled = value;
                App.Current.Dispatcher.Invoke(() =>
                            CommandManager.InvalidateRequerySuggested()
                            );
            }
        }

        protected void AddCommandInvoke(IProgramCommand command)
        {
            AddProgram?.Invoke(this, new AddCommandEventArgs(command));
        }

        protected void TransitionInvoke(CommandListState newState)
        {
            Transition?.Invoke(this, new CommandListStateEventArgs(newState));
        }

    }
}

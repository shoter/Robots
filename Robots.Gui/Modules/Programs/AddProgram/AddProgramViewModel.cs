using Ninject;
using Robots.Gui.Base;
using Robots.Gui.Modules.Programs.AddProgram.CommandList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Robots.Gui.Modules.Programs.AddProgram
{
    public class AddProgramViewModel : ViewModelBase
    {
        public event EventHandler<AddCommandEventArgs> AddProgram;

        public CommandListBaseViewModel CommandAddViewModel { get; private set; }

        public UserControl CommandAddControl { get; private set; }


        public CommandListState CommandState { get; private set; } = CommandListState.Buttons;

        private ICommandListFactory CommandListFactory { get; }

        [Inject]
        public AddProgramViewModel(ICommandListFactory commandListFactory)
        {
            this.CommandListFactory = commandListFactory;
            changeState(CommandState);
        }

        public AddProgramViewModel()
        {
            CommandAddViewModel = new CommandListViewModel();
            CommandAddControl = new CommandListControl();
        }

        private void onStateChange(object sender, CommandListStateEventArgs e )
        {
            Debug.Assert(sender == CommandAddViewModel);
            var state = e.State;

            CommandAddViewModel.Transition -= onStateChange;
            CommandAddViewModel.AddProgram -= onCommandAdd;

            changeState(state);
        }

        private void changeState(CommandListState state)
        {
            CommandAddControl = CommandListFactory.CreateControl(state);
            CommandAddControl.DataContext = CommandAddViewModel = CommandListFactory.CreateViewModel(state);
            CommandState = state;

            CommandAddViewModel.Transition += onStateChange;
            CommandAddViewModel.AddProgram += onCommandAdd;

            NotifyPropertiesChanged(nameof(CommandState), nameof(CommandAddViewModel), nameof(CommandAddControl));
        }

        private void onCommandAdd(object sender, AddCommandEventArgs e)
        {
            Debug.Assert(sender == CommandAddViewModel);
            var command = e.Command;

            AddProgram?.Invoke(this, e);
        }

    }
}

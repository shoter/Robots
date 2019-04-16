using Ninject;
using Robots.Gui.Base;
using Robots.Gui.Helpers;
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
    public class AddProgramViewModel : ViewModelBase, IAddProgramViewModel
    {
        public event EventHandler<AddCommandEventArgs> AddCommand;

        public CommandListBaseViewModel CommandAddViewModel { get; private set; }

        public IUserControlProxy CommandAddControl { get; private set; }

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
            CommandAddControl = new CommandListControl().AsProxy();
        }

        private void onStateChange(object sender, CommandListStateEventArgs e)
        {
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
            var command = e.Command;

            AddCommand?.Invoke(this, e);
        }

    }
}

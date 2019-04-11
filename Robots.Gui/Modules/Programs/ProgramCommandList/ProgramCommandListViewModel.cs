using Robots.Core.Programs;
using Robots.Gui.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Robots.Gui.Modules.Programs.ProgramCommandList
{
    public class ProgramCommandListViewModel
    {
        private IProgram Program { get; }

        private ObservableCollection<ProgramCommandListItemViewModel> CommandsCollection { get; } = new ObservableCollection<ProgramCommandListItemViewModel>();

        // User should not have an ability to modify this collection. There is some important logic combined with events that needs to be handled in case of adding/removing items. Therefore public methods should be used.
        // I could use events for that but there are events that also involves the whole collection replacement. There would be too much cases to handle compared to simple add/remove methods.
        public IEnumerable<ProgramCommandListItemViewModel> Commands => CommandsCollection;


        public ProgramCommandListViewModel(IProgram program)
        {
            this.Program = program;
        }

        public ProgramCommandListViewModel() { }

        public ProgramCommandListViewModel AddCommand(IProgramCommand command)
        {
            var item = new ProgramCommandListItemViewModel(command);

            item.CommandRemove += onCommandRemoval;

            CommandsCollection.Add(item);

            return this;
        }

        private void onCommandRemoval(object sender, ProgramCommandItemEventArgs e)
        {
            var item = sender as ProgramCommandListItemViewModel;
            item.CommandRemove -= onCommandRemoval;
            CommandsCollection.Remove(item);
            Program.RemoveCommand(e.Command);
        }
    }
}

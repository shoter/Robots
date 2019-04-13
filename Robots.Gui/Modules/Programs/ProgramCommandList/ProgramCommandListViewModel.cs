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
    public class ProgramCommandListViewModel : IProgramCommandListViewModel
    {
        private IProgram Program { get; set; }

        private ObservableCollection<ProgramCommandListItemViewModel> CommandsCollection { get; } = new ObservableCollection<ProgramCommandListItemViewModel>();

        // User should not have an ability to modify this collection. There is some important logic combined with events that needs to be handled in case of adding/removing items. Therefore public methods should be used.
        // I could use events for that but there are events that also involves the whole collection replacement. There would be too much cases to handle compared to simple add/remove methods.
        public IEnumerable<IProgramCommandListItemViewModel> Commands => CommandsCollection;


        public void AddCommand(IProgramCommand command)
        {
            addCommandViewModel(command);
            Program.AddCommand(command);
        }

        private void onCommandRemoval(object sender, ProgramCommandItemEventArgs e)
        {
            var item = sender as ProgramCommandListItemViewModel;
            item.CommandRemove -= onCommandRemoval;
            CommandsCollection.Remove(item);
            Program.RemoveCommand(e.Command);
        }

        public void SetProgram(IProgram program)
        {
            CommandsCollection.Clear();

            Program = program;

            if (program != null)
            {

                foreach (var c in Program.Commands)
                {
                    addCommandViewModel(c);
                }
            }
        }

        private void addCommandViewModel(IProgramCommand command)
        {
            var item = new ProgramCommandListItemViewModel(command);

            item.CommandRemove += onCommandRemoval;

            CommandsCollection.Add(item);
        }
    }
}

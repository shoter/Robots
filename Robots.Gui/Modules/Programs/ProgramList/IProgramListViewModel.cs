using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ProgramList
{
    public interface IProgramListViewModel
    {
        ObservableCollection<IProgramListItemViewModel> Programs { get; }

        event EventHandler<ProgramListItemEventArgs> ProgramRemove;
        event EventHandler<ProgramListItemEventArgs> ProgramSelect;
    }
}

using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ViewModels
{
    public class ProgramListViewModel
    {
        public ObservableCollection<ProgramListItemViewModel> Programs { get; } = new ObservableCollection<ProgramListItemViewModel>();

        public ProgramListViewModel(IApplicationState state)
        {
            foreach(var p in state.Programs)
            {
                Programs.Add(new ProgramListItemViewModel(p));
            }
        }
    }
}

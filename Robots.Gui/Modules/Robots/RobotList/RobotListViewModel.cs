using Ninject;
using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotList
{
    public class RobotListViewModel : IRobotListViewModel
    {
        public IEnumerable<IRobotListItemViewModel> Robots { get; }

        public event EventHandler<RobotListItemEventArgs> RobotSelected;

        public int Count => Robots?.Count() ?? -1;

        public RobotListViewModel() { }

        [Inject]
        public RobotListViewModel(IApplicationState state)
        {
            var robotList = new List<IRobotListItemViewModel>();

            foreach(var r in state.Robots)
            {
                var vm = new RobotListItemViewModel(r);
                vm.RobotSelected += (_, e) => RobotSelected?.Invoke(this, e);
                robotList.Add(vm);
            }

            Robots = robotList;
        }
    }
}

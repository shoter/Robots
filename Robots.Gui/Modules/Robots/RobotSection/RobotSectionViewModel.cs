using Ninject;
using Robots.Gui.Base;
using Robots.Gui.Modules.Robots.RobotList;
using Robots.Gui.Modules.Robots.RobotView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotSection
{
    public class RobotSectionViewModel : ViewModelBase, IRobotSectionViewModel
    {
        public IRobotListViewModel RobotList { get; } 

        public IRobotViewViewModel RobotView { get; }

        public RobotSectionViewModel() { }

        [Inject]
        public RobotSectionViewModel(IRobotListViewModel robotList, IRobotViewViewModel robotView)
        {
            this.RobotList = robotList;
            this.RobotView = robotView;

            this.RobotList.RobotSelected += robotList_RobotSelected;
        }

        private void robotList_RobotSelected(object sender, RobotListItemEventArgs e)
        {
            RobotView.SetRobot(e.Robot);
        }
    }
}

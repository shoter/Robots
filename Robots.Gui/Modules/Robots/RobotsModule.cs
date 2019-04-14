using Ninject.Modules;
using Robots.Gui.Modules.Robots.RobotList;
using Robots.Gui.Modules.Robots.RobotLog;
using Robots.Gui.Modules.Robots.RobotSection;
using Robots.Gui.Modules.Robots.RobotView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots
{
    public class RobotsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRobotListViewModel>().To<RobotListViewModel>().InTransientScope();
            Bind<IRobotLogViewModel>().To<RobotLogViewModel>().InTransientScope();
            Bind<IRobotSectionViewModel>().To<RobotSectionViewModel>().InTransientScope();
            Bind<IRobotViewViewModel>().To<RobotViewViewModel>().InTransientScope();
        }
    }
}

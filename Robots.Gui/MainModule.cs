using Ninject.Modules;
using Robots.Core.Robots;
using Robots.Gui.State;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            // reuse one instance over whole program
            Kernel.Bind<IApplicationState>().To<ApplicationState>().InSingletonScope();

            Kernel.Bind<IRobotFactory>().To<RobotFactoryMock>().InSingletonScope();
        }
    }
}

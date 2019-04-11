using Ninject;
using Robots.Gui.Modules.Notifications;
using Robots.Gui.Modules.Programs;
using Robots.Gui.Modules.Programs.AddProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui
{
    public class RobotsKernel : StandardKernel
    {
        public RobotsKernel()
        {
            this.Load(
                new MainModule(),
                new ProgramModule(),
                new NotificationModule()
                );
        }
    }
}

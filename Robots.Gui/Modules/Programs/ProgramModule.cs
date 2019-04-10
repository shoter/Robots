using Ninject.Modules;
using Robots.Gui.Modules.Programs.ProgramList;
using Robots.Gui.Modules.Programs.ProgramsSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs
{
    public class ProgramModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ProgramListViewModel>().ToSelf().InTransientScope();
            Bind<ProgramSectionViewModel>().ToSelf().InTransientScope();

            Bind<IProgramService>().To<ProgramService>().InSingletonScope();
        }
    }
}

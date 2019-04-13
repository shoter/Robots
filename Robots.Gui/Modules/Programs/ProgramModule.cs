using Ninject.Modules;
using Robots.Core.Programs;
using Robots.Gui.Modules.Programs.AddProgram;
using Robots.Gui.Modules.Programs.AddProgram.CommandList;
using Robots.Gui.Modules.Programs.ProgramCommandList;
using Robots.Gui.Modules.Programs.ProgramList;
using Robots.Gui.Modules.Programs.ProgramsSection;
using Robots.Gui.Modules.Programs.ProgramView;
using Robots.Gui.State;
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
            Bind<IProgramListViewModel>().To<ProgramListViewModel>().InTransientScope();
            Bind<IProgramSectionViewModel>().To<ProgramSectionViewModel>().InTransientScope();
            Bind<IAddProgramViewModel>().To<AddProgramViewModel>().InTransientScope();
            Bind<IProgramViewViewModel>().To<ProgramViewViewModel>().InTransientScope();
            Bind<IProgramCommandListViewModel>().To<ProgramCommandListViewModel>().InTransientScope();

            Bind<IProgramService>().To<ProgramService>().InSingletonScope();
            Bind<ICommandListFactory>().To<CommandListFactory>().InSingletonScope();
            Bind<IProgramFactory>().To<ProgramFactory>().InSingletonScope();
        }
    }
}

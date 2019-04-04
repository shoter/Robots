using Robots.Gui.Modules.Programs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs
{
    public class ProgramViewModelLocator
    {
        public ProgramListViewModel ProgramList => DependencyResolver.Get<ProgramListViewModel>();
    }
}

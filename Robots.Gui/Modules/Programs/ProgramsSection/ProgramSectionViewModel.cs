using Ninject;
using Robots.Gui.Modules.Programs.ProgramList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ProgramsSection
{
    public class ProgramSectionViewModel
    {
        public ProgramListViewModel ProgramList { get; set; }

        public ProgramSectionViewModel()
        {
            ProgramList = new ProgramListViewModel();
        }

        [Inject]
        public ProgramSectionViewModel(ProgramListViewModel programList)
        {
            this.ProgramList = programList;
        }
    }
}

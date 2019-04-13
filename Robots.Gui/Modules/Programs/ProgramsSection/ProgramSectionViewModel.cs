using Ninject;
using Robots.Core.Programs;
using Robots.Gui.Modules.Programs.ProgramList;
using Robots.Gui.Modules.Programs.ProgramView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ProgramsSection
{
    public class ProgramSectionViewModel : IProgramSectionViewModel
    {
        private IProgram SelectedProgram { get; set; }

        public IProgramListViewModel ProgramList { get; }
        public IProgramViewViewModel ProgramView { get; }

        private IProgramService ProgramService { get; }

        public ProgramSectionViewModel()
        {
            ProgramList = new ProgramListViewModel();

        }

        [Inject]
        public ProgramSectionViewModel(IProgramListViewModel programList, IProgramViewViewModel programView, IProgramService programService)
        {
            this.ProgramList = programList;
            this.ProgramView = programView;
            this.ProgramService = programService;

            ProgramList.ProgramSelect += programList_ProgramSelect;
            ProgramList.ProgramRemove += programList_ProgramRemove;
        }

        private void programList_ProgramRemove(object sender, ProgramListItemEventArgs e)
        {
            if(e.Item.Id == SelectedProgram.Id)
            {
                ProgramView.SetProgram(null);
            }
        }

        private void programList_ProgramSelect(object sender, ProgramListItemEventArgs e)
        {
            SelectedProgram = ProgramService.GetProgram(e.Item.Id);
            ProgramView.SetProgram(SelectedProgram);
        }
    }
}

using Ninject;
using Robots.Core.Programs;
using Robots.Gui.Base;
using Robots.Gui.Modules.Programs.AddProgram;
using Robots.Gui.Modules.Programs.AddProgram.CommandList;
using Robots.Gui.Modules.Programs.ProgramCommandList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Robots.Gui.Modules.Programs.ProgramView
{
    public class ProgramViewViewModel : ViewModelBase
    {
        private IProgram Program { get; set; }

        public string Name
        {
            get => Program?.Name;
            set => Program.Name = value;
        }

        public AddProgramViewModel AddProgram { get; }
        public ProgramCommandListViewModel ProgramCommandList { get; private set; }

        [Inject]
        public ProgramViewViewModel(AddProgramViewModel addProgram, ProgramCommandListViewModel commandList)
        {
            this.AddProgram = addProgram;
            this.ProgramCommandList = commandList;

            this.AddProgram.AddProgram += onProgramAdded;
        }

        private void onProgramAdded(object sender, AddCommandEventArgs e)
        {
            ProgramCommandList.AddCommand(e.Command);
        }

        public ProgramViewViewModel()
        {
            AddProgram = new AddProgramViewModel();
        }

        public void SetProgram(IProgram program)
        {
            this.Program = program;
            ProgramCommandList = new ProgramCommandListViewModel(Program);

            NotifyPropertiesChanged(nameof(Name), nameof(AddProgram), nameof(ProgramCommandList));
        }
        
    }
}

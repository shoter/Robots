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
using System.Windows;
using System.Windows.Controls;

namespace Robots.Gui.Modules.Programs.ProgramView
{
    public class ProgramViewViewModel : ViewModelBase, IProgramViewViewModel
    {
        private IProgram Program { get; set; }

        public Visibility CanShow => Program == null ? Visibility.Hidden : Visibility.Visible;

        public string Name
        {
            get => Program?.Name;
            set => Program.Name = value;
        }

        public IAddProgramViewModel AddProgram { get; }
        public IProgramCommandListViewModel ProgramCommandList { get; }

        [Inject]
        public ProgramViewViewModel(IAddProgramViewModel addProgram, IProgramCommandListViewModel commandList)
        {
            this.AddProgram = addProgram;
            this.ProgramCommandList = commandList;

            this.AddProgram.AddCommand += onProgramCommandAdded;
        }

        private void onProgramCommandAdded(object sender, AddCommandEventArgs e)
        {
            ProgramCommandList.AddCommand(e.Command);
        }

        public ProgramViewViewModel()
        {
        }

        public void SetProgram(IProgram program)
        {
            this.Program = program;
            ProgramCommandList.SetProgram(program);

            NotifyPropertiesChanged(nameof(Name), nameof(AddProgram), nameof(ProgramCommandList), nameof(CanShow));
        }
        
    }
}

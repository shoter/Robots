using Ninject;
using Robots.Core.ProgramExecution;
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

        public bool IsModifable
        {
            get
            {
                if (Program == null)
                    return false;
                return programExecutionService.IsProgramRunning(Program) == false;
            }
        }

        private readonly IProgramExecutionService programExecutionService;

        [Inject]
        public ProgramViewViewModel(IProgramExecutionService programExecutionService, IAddProgramViewModel addProgram, IProgramCommandListViewModel commandList)
        {
            this.AddProgram = addProgram;
            this.ProgramCommandList = commandList;
            this.programExecutionService = programExecutionService;

            this.AddProgram.AddCommand += onProgramCommandAdded;

            programExecutionService.ProgramExecutionStarted += programStartedOrCompleted;
            programExecutionService.ProgramExecutionCompleted += programStartedOrCompleted;
        }

        private void programStartedOrCompleted(object sender, ProgramExecutionServiceProgramEventArgs e)
        {
            if (e.Program == Program)
                AddProgram.CommandAddViewModel.IsAddingCommandsEnabled = IsModifable;
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
            AddProgram.CommandAddViewModel.IsAddingCommandsEnabled = IsModifable;

            NotifyPropertiesChanged(nameof(Name), nameof(AddProgram), nameof(ProgramCommandList), nameof(CanShow), nameof(IsModifable));
        }
        
    }
}

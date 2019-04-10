using Robots.Core.Programs;
using Robots.Gui.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Robots.Gui.Modules.Programs.ProgramList
{
    public class ProgramListItemViewModel
    {
        public event EventHandler<ProgramListItemEventArgs> ProgramRemove;
        public event EventHandler<ProgramListItemEventArgs> ProgramSelect;

        public ICommand RemoveProgram { get; }
        public ICommand SelectProgram { get; }

        private IProgram program;

        public string Name
        {
            get => program.Name;
            set => program.Name = value;
        }

        public ulong Id => program.Id;


        public ProgramListItemViewModel(IProgram program)
        {
            this.program = program;

            this.RemoveProgram = new ActionCommand<ProgramListItemViewModel>(this.onRemoveProgram);
            this.SelectProgram = new ActionCommand<ProgramListItemViewModel>(this.onSelectProgram);
        }

        private void onRemoveProgram(ProgramListItemViewModel item)
        {
            Debug.Assert(this == item);

            ProgramRemove?.Invoke(this, new ProgramListItemEventArgs(item));
        }

        private void onSelectProgram(ProgramListItemViewModel item)
        {
            Debug.Assert(this == item);

            ProgramSelect?.Invoke(this, new ProgramListItemEventArgs(item));
        }
    }
}

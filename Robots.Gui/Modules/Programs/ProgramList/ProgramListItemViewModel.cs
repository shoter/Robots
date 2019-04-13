using Robots.Core.Programs;
using Robots.Gui.Base;
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
    public class ProgramListItemViewModel : ViewModelBase, IProgramListItemViewModel
    {
        public event EventHandler<ProgramListItemEventArgs> ProgramRemove;
        public event EventHandler<ProgramListItemEventArgs> ProgramSelect;

        public static ICommand RemoveProgram { get; }
        public static ICommand SelectProgram { get; }

        private IProgram program;

        public string Name
        {
            get => program.Name;
            set => program.Name = value;
        }

        public ulong Id => program.Id;

        static ProgramListItemViewModel()
        {
            RemoveProgram = new ActionCommand<ProgramListItemViewModel>(onRemoveProgram);
            SelectProgram = new ActionCommand<ProgramListItemViewModel>(onSelectProgram);
        }

        public ProgramListItemViewModel(IProgram program)
        {
            this.program = program;

            program.PropertyChanged += Program_PropertyChanged;

        }

        private void Program_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(program.Name))
            {
                NotifyPropertiesChanged(nameof(Name));
            }
        }

        private static void onRemoveProgram(ProgramListItemViewModel item)
        {
            item.ProgramRemove?.Invoke(item, new ProgramListItemEventArgs(item));
        }        

        private static void onSelectProgram(ProgramListItemViewModel item)
        {
            item.ProgramSelect?.Invoke(item, new ProgramListItemEventArgs(item));
        }
    }
}

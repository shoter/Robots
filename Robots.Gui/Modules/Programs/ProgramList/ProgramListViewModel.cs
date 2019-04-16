using Ninject;
using Robots.Core.Programs;
using Robots.Gui.Commands;
using Robots.Gui.Modules.Notifications;
using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Robots.Gui.Modules.Programs.ProgramList
{
    public class ProgramListViewModel : IProgramListViewModel
    {
        public ObservableCollection<IProgramListItemViewModel> Programs { get; } = new ObservableCollection<IProgramListItemViewModel>();
        public event EventHandler<ProgramListItemEventArgs> ProgramRemove;
        public event EventHandler<ProgramListItemEventArgs> ProgramSelect;

        public static ICommand NewProgramCommand { get; } 

        private readonly IProgramService programService;
        private readonly INotificationService notificationService;
        private readonly IProgramFactory programFactory;

        
        /// <summary>
        /// This constructor is ignored by ninject.
        /// </summary>
        public ProgramListViewModel()
        {
        }

        static ProgramListViewModel()
        {
            NewProgramCommand = new ActionCommand<ProgramListViewModel>(onNewProgram);
        }

        [Inject]
        public ProgramListViewModel(IApplicationState state, IProgramService programService, IProgramFactory programFactory, INotificationService notificationService)
        {
            this.programService = programService;
            this.notificationService = notificationService;
            this.programFactory = programFactory;

            foreach(var p in state.Programs)
            {
                addNewItem(p);
            }
        }

        private void addNewItem(IProgram p)
        {
            // TODO : If I want to make the event control unit testable I need to use factory pattern for this.
            var vm = new ProgramListItemViewModel(p);
            Programs.Add(vm);

            vm.ProgramRemove += onProgramItemRemoval;
            vm.ProgramSelect += onProgramItemSelect;
        }

        private void onProgramItemRemoval(object sender, ProgramListItemEventArgs e)
        {
            if(programService.CanRemoveProgram(e.Item.Id) == false)
            {
                notificationService.ShowWarningMessageBox("Cannot remove the program. It is probably actively used by some robot.");
                return;
            }

            Programs.Remove(e.Item);
            programService.RemoveProgram(e.Item.Id);
            ProgramRemove?.Invoke(this, e);
        }

        private void onProgramItemSelect(object sender, ProgramListItemEventArgs e)
        {
            ProgramSelect?.Invoke(this, e);
        }

        private static void onNewProgram(ProgramListViewModel item)
        {
            // Why did I used factory pattern here :
            // I am creating business model here. If that would be a real program a lot of logic would be involved which we would like to hide here as we are on different abstraction level than constructing business model entities.
            // Also a lot of code would be involved here

            IProgram program = item.programFactory.Create();
            item.addNewItem(program);
        }
    }
}

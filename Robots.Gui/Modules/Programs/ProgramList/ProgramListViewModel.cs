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

namespace Robots.Gui.Modules.Programs.ProgramList
{
    public class ProgramListViewModel
    {
        public ObservableCollection<ProgramListItemViewModel> Programs { get; } = new ObservableCollection<ProgramListItemViewModel>();

        private readonly IProgramService programService;
        private readonly INotificationService notificationService;

        public ProgramListViewModel(IApplicationState state, IProgramService programService, INotificationService notificationService)
        {
            this.programService = programService;
            this.notificationService = notificationService;

            foreach(var p in state.Programs)
            {
                var vm = new ProgramListItemViewModel(p);
                Programs.Add(vm);

                vm.OnProgramRemoval += onProgramItemRemoval;
            }
        }

        private void onProgramItemRemoval(object sender, ProgramListItemEventArgs e)
        {
            Programs.Remove(e.Item);

            if(programService.CanRemoveProgram(e.Item.Id) == false)
            {
                notificationService.ShowWarningMessageBox("Cannot remove the program. It is probably actively used by some robot.");
                return;
            }

            programService.RemoveProgram(e.Item.Id);
        }
    }
}

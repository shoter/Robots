using Robots.Gui.Base;
using Robots.Gui.Helpers;
using Robots.Gui.Modules.Programs.ProgramsSection;
using Robots.Gui.Modules.Robots.RobotSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        public IProgramSectionViewModel ProgramSection { get; }
        public IRobotSectionViewModel RobotSection { get; }

        private MainWindowState state = MainWindowState.None;
        public MainWindowState State
        {
            get => state;
            set
            {
                state = value;
                CurrentControl = controlFactory.Create(value);
                NotifyPropertyChanged();
            }
        }

        public IUserControlProxy CurrentControl { get; private set; }

        private readonly IMainWindowControlFactory controlFactory;


        public MainWindowViewModel(IProgramSectionViewModel programSection, IRobotSectionViewModel robotSection, IMainWindowControlFactory controlFactory)
        {
            this.RobotSection = robotSection;
            this.ProgramSection = programSection;

            this.controlFactory = controlFactory;
        }
    }
}

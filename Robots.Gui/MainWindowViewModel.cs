using Robots.Gui.Base;
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

        private MainWindowState state = new MainWindowState();
        public MainWindowState State
        {
            get => state;
            set
            {
                state = value;
                NotifyPropertyChanged();
            }
        }


        public MainWindowViewModel(IProgramSectionViewModel programSection, IRobotSectionViewModel robotSection)
        {
            this.RobotSection = robotSection;
            this.ProgramSection = programSection;
        }
    }
}

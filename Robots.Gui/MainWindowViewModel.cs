using Ninject;
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

        private MainWindowState state;
        public MainWindowState State
        {
            get => state;
            set
            {
                state = value;
                CurrentControl = controlFactory.Create(value);
                NotifyPropertyChanged();
                NotifyPropertiesChanged(nameof(CurrentControl));
            }
        }

        public IUserControlProxy CurrentControl { get; private set; }

        private readonly IMainWindowControlFactory controlFactory;

        public MainWindowViewModel() { }

        [Inject]
        public MainWindowViewModel(IMainWindowControlFactory controlFactory)
        {
            this.controlFactory = controlFactory;
            State = MainWindowState.None;
        }
    }
}

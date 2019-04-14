using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Robots.Gui.Helpers;
using Robots.Gui.Modules.Programs.ProgramsSection;
using Robots.Gui.Modules.Robots.RobotSection;

namespace Robots.Gui
{
    public class MainWindowControlFactory : IMainWindowControlFactory
    {
        private readonly IKernel kernel;

        public MainWindowControlFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public IUserControlProxy Create(MainWindowState state)
        {
            switch (state)
            {
                case MainWindowState.Robots:
                    {
                        var vm = kernel.Get<IRobotSectionViewModel>();
                        var control = new RobotSectionControl();
                        control.DataContext = vm;
                        return control.AsProxy();
                    }

                case MainWindowState.Programs:
                    {
                        var vm = kernel.Get<IProgramSectionViewModel>();
                        var control = new ProgramSectionControl();
                        control.DataContext = vm;
                        return control.AsProxy();
                    }
            }

            return UserControlProxy.NullProxy;
        }
    }
}
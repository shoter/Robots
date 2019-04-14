using Robots.Gui.Modules.Programs.ProgramsSection;
using Robots.Gui.Modules.Robots.RobotSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui
{
    public interface IMainWindowViewModel
    {
        IProgramSectionViewModel ProgramSection { get; }
        IRobotSectionViewModel RobotSection { get; }

        MainWindowState State { get; set; }
    }
}

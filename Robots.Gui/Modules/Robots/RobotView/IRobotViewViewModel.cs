using Robots.Gui.Modules.Robots.RobotLog;
using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Robots.Gui.Modules.Robots.RobotView
{
    public interface IRobotViewViewModel
    {
        IRobotLogViewModel RobotLog { get; }

        List<IRobotViewProgramViewModel> Programs { get; }

        IRobotViewProgramViewModel SelectedProgram { get; set; }

        bool IsProgramModificationEnabled { get; }

        string RobotName { get; }

        Visibility Visibility { get; }

        void SetRobot(IRobotState robot);
    }
}

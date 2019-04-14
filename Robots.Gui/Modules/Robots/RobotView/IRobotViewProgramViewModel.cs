using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotView
{
    public interface IRobotViewProgramViewModel
    {
        IProgram Program { get; }
        string Name { get; } 
    }
}

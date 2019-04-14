using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotView
{
    public class RobotViewProgramViewModel : IRobotViewProgramViewModel
    {
        public IProgram Program { get; }

        public string Name => Program.Name;

        public RobotViewProgramViewModel(IProgram program)
        {
            this.Program = program;
        }
    }
}

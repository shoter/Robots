using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ProgramView
{
    public class ProgramViewCommandViewModel
    {
        private readonly IProgramCommand command;

        public string Name => command.ToString();

        public ProgramViewCommandViewModel(IProgramCommand command)
        {
            this.command = command;
        }
    }
}

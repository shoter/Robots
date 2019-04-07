using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ProgramList
{
    public class ProgramListItemEventArgs : EventArgs
    {
        public ProgramListItemViewModel Item { get; set; }

        public ProgramListItemEventArgs(ProgramListItemViewModel vm)
        {
            this.Item = vm;
        }

    }
}

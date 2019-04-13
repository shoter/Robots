using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ProgramList
{
    public interface IProgramListItemViewModel
    {
        event EventHandler<ProgramListItemEventArgs> ProgramRemove;
        event EventHandler<ProgramListItemEventArgs> ProgramSelect;

        string Name { get; set; }

        ulong Id { get; }
    }
}

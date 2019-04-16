using Robots.Core.Programs;
using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs
{
    public interface IProgramService
    {
        bool CanRemoveProgram(ulong programId);
        void RemoveProgram(ulong programId);
        IProgram GetProgram(ulong programId);
    }
}

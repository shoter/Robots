using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public interface IApplicationState
    {
        IEnumerable<IRobotState> Robots { get; }
        IEnumerable<IProgram> Programs { get; }

        void AddProgram(IProgram program);
        void RemoveProgram(IProgram program);
        IProgram GetProgram(ulong programId);
    }
}

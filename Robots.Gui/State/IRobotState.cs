using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public interface IRobotState
    {
        ulong Id { get; }

        IRobot Robot { get; }
        IProgram AssignedProgram { get; }
        bool IsProgramRunning { get; }

        void AssignProgram(IProgram program);
        void DeassignProgram();

        bool CanAssignProgram();

        void RunProgram();
    }
}

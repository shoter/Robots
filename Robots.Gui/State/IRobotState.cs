using Robots.Core.ProgramExecution;
using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public interface IRobotState : INotifyPropertyChanged
    {
        ulong Id { get; }

        IRobot Robot { get; }
        IProgram AssignedProgram { get; }
        IRobotLog RobotLog { get; }

        bool IsProgramRunning { get; }

        string Status { get; }

        void AssignProgram(IProgram program);
        void DeassignProgram();

        bool CanAssignProgram();

        IProgramExecutor RunProgram();
    }
}

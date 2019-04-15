using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.ProgramExecution
{
    /// <summary>
    /// Represents a class that is running a program on given robot.
    /// It has information what is currently happening to the given robot.
    /// Should automatically start execution after creation
    /// </summary>
    public interface IProgramExecutor
    {
       bool IsCompleted { get; } 

        IProgram Program { get; }
        IRobot Robot { get; }

        event EventHandler<ProgramExecutorCommandEventArgs> CommandExecutionStart;
        event EventHandler<ProgramExecutorCommandEventArgs> CommandExecutionEnd;
        event EventHandler<EventArgs> ProgramExecutionEnd;
    }
}

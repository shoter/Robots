using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.Programs
{
    public interface IProgramExecutor
    {
        event EventHandler<ProgramExecutorEventArgs> OnCommandExecutionStart;
        event EventHandler<ProgramExecutorEventArgs> OnCommandExecutionEnd;
        event EventHandler<ProgramExecutorEventArgs> OnProgramExecutionEnd;

        bool IsRunning { get; }
        IProgramCommand CurrentCommand { get; }
        IRobot CurrentRobot { get; }
        IProgram CurrentProgram { get; }

        /// <summary>
        /// Starts execution of the program on the given robot.
        /// It will use thread from thread pool to do that.
        /// </summary>
        /// <param name="program"></param>
        void Start(IProgram program, IRobot robot);
    }
}

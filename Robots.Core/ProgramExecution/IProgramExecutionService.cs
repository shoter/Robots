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
    /// Responsible for delegating program execution to robots.
    /// Created for sole purpose of not using one robot by 2 programs at same time.
    /// </summary>
    public interface IProgramExecutionService
    {
        IProgramExecutor Execute(IProgram program, IRobot robot);

        bool CanExecute(IProgram program, IRobot robot);

        bool IsProgramRunning(IProgram program);
    }
}

using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.ProgramExecution
{
    public interface IProgramExecutorFactory
    {
        IProgramExecutor Create(IProgram program, IRobot robot);
    }
}

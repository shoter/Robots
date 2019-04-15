using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.ProgramExecution
{
    public class ProgramExecutorFactory : IProgramExecutorFactory
    {
        public IProgramExecutor Create(IProgram program, IRobot robot) => new ProgramExecutor(program, robot);
    }
}

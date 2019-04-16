using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.ProgramExecution
{
    public class ProgramExecutionServiceProgramEventArgs
    {
        public IProgram Program { get; }

        public ProgramExecutionServiceProgramEventArgs(IProgram program)
        {
            this.Program = program;
        }
    }
}

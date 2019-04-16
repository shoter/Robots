using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Core.ProgramExecution;
using Robots.Core.Programs;
using Robots.Gui.State;

namespace Robots.Gui.Modules.Programs
{
    public class ProgramService : IProgramService
    {
        private IApplicationState State { get; }

        private readonly IProgramExecutionService programExecutionService;

        public ProgramService(IProgramExecutionService programExecutionService, IApplicationState state)
        {
            this.State = state;
            this.programExecutionService = programExecutionService;
        }

        public virtual bool CanRemoveProgram(ulong programId)
        {
            var program = GetProgram(programId);

            if (programExecutionService.IsProgramRunning(program))
                return false;
            return true;
        }


        public virtual void RemoveProgram(ulong programId)
        {
            Debug.Assert(CanRemoveProgram(programId));

            foreach(var r in State.Robots)
            {
                if(r.AssignedProgram?.Id == programId)
                {
                    r.DeassignProgram();
                }
            }

            State.RemoveProgram(State.GetProgram(programId));
        }

        public virtual IProgram GetProgram(ulong programId)
        {
            return State.GetProgram(programId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Core.Programs;
using Robots.Gui.State;

namespace Robots.Gui.Modules.Programs
{
    public class ProgramService : IProgramService
    {
        private IApplicationState State { get; }

        public ProgramService(IApplicationState state)
        {
            this.State = state;
        }

        public virtual IEnumerable<IRobotState> GetRobotsRunningProgram(ulong programId)
        {
            foreach(var r in State.Robots)
            {
                if (r.IsProgramRunning && r.AssignedProgram.Id == programId)
                    yield return r;
            }
        }

        public virtual bool CanRemoveProgram(ulong programId)
        {
            if (GetRobotsRunningProgram(programId).Any())
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
    }
}

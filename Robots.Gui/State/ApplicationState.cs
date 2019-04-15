using Robots.Core.ProgramExecution;
using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public class ApplicationState : IApplicationState
    {
        public IEnumerable<IRobotState> Robots => RobotsList;

        public IEnumerable<IProgram> Programs => ProgramsList;

        private List<IRobotState> RobotsList { get; } = new List<IRobotState>();

        private List<IProgram> ProgramsList { get; } = new List<IProgram>();


        public ApplicationState(IRobotFactory robotFactory, IProgramExecutionService programExecutionService)
        {
            var robots = robotFactory.GetRegisteredRobots();

            RobotsList.Capacity = robots.Count();

            foreach (var r in robots)
                RobotsList.Add(new RobotState(programExecutionService, r, new RobotLog()));
        }

        public void AddProgram(IProgram program) => ProgramsList.Add(program);

        public void RemoveProgram(IProgram program) => ProgramsList.Remove(program);

        public IProgram GetProgram(ulong programId) => ProgramsList.First(p => p.Id == programId);
    }
}

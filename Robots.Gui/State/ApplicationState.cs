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


        public ApplicationState(IRobotFactory robotFactory)
        {
            var robots = robotFactory.GetRegisteredRobots();

            RobotsList.Capacity = robots.Count();

            foreach (var r in robots)
                RobotsList.Add(new RobotState(r, new RobotLog()));

            for(int i = 0; i <5; ++i)
            ProgramsList.Add(new Program());
        }
    }
}

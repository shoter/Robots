using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.Robots
{
    public class RobotFactoryMock : IRobotFactory
    {
        private readonly IRobot[] robots;

        public RobotFactoryMock()
        {
            const int robotCount = 15;

            robots = new IRobot[robotCount];
            for(int i = 0;i < robotCount; ++i)
            {
                robots[i] = createRobot();
            }
        }

        public IEnumerable<IRobot> GetRegisteredRobots() => robots;

        private IRobot createRobot() => new RobotMock();
    }
}

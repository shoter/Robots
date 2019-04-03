using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.SDK
{
    public interface IRobotFactory
    {
        IEnumerable<IRobot> GetRegisteredRobots();
    }
}

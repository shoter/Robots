using Robots.SDK;
using System;
using System.Threading.Tasks;

namespace Robots.Core.Robots
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotMock : IRobot
    {
        public Task Beep()
        {
            return Task.Delay(500);
        }

        public Task Move(double distance)
        {
            return Task.Delay((int)Math.Min(5000, distance));
        }

        public Task Turn(double angle)
        {
            return Task.Delay((int)Math.Min(5000, angle));
        }
    }
}

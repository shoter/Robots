using Robots.SDK;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Robots.Core.Robots
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotMock : IRobot
    {
        private static uint createdRobots = 0;
        public string Name { get; }

        /// <summary>
        /// Only 1 method can be executed at one time
        /// </summary>
        private Mutex exclusivenessMutex = new Mutex();



        public RobotMock()
        {
            Name = $"Robot {++createdRobots}";
        }


        public Task Beep()
        {
            lock(exclusivenessMutex)
                return Task.Delay(500);
        }

        public Task Move(double distance)
        {
            lock(exclusivenessMutex)
                return Task.Delay((int)Math.Min(5000, distance));
        }

        public Task Turn(double angle)
        {
            lock(exclusivenessMutex)
                return Task.Delay((int)Math.Min(5000, angle));
        }

        public override string ToString() => Name;
    }
}

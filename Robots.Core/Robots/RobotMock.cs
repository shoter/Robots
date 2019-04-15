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


        public void Beep()
        {
            lock (exclusivenessMutex)
                Thread.Sleep(500);
        }

        public void Move(double distance)
        {
            lock (exclusivenessMutex)
                Thread.Sleep((int)Math.Min(5000, distance));
        }

        public void Turn(double angle)
        {
            lock (exclusivenessMutex)
                Thread.Sleep((int)Math.Min(5000, angle));
        }

        public override string ToString() => Name;
    }
}

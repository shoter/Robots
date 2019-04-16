using Robots.Common;
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
        private static readonly UniqueIdGenerator uniqueId = new UniqueIdGenerator();

        public string Name { get; }

        /// <summary>
        /// Only 1 method can be executed at one time.
        /// Somehow simulation of the thing that robot cannot do 2 things at the same time.
        /// </summary>
        private readonly Mutex exclusivenessMutex = new Mutex();



        public RobotMock()
        {
            Name = $"Robot {uniqueId.Id}";
        }


        public void Beep()
        {
            lock (exclusivenessMutex)
                Thread.Sleep(500);
        }

        public void Move(double distance)
        {
            lock (exclusivenessMutex)
                Thread.Sleep((int)Math.Max(Math.Min(10_000, distance * 10), 100));
        }

        public void Turn(double angle)
        {
            lock (exclusivenessMutex)
                Thread.Sleep((int)Math.Max(Math.Min(10_000, angle), 100));
        }

        public override string ToString() => Name;
    }
}

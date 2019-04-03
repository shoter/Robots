using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.SDK;

namespace Robots.Core.Programs
{
    public class MoveCommand : IProgramCommand
    {
        private double distance;

        public MoveCommand(double distance)
        {
            this.distance = distance;
        }

        public string Describe() => $"Move for distance of {distance}";

        public Task Execute(IRobot robot) => robot.Move(distance);
    }
}

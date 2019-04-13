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
        public double Distance { get; }

        public MoveCommand(double distance)
        {
            this.Distance = distance;
        }

        public string Describe() => $"Move for distance of {Distance}";

        public Task Execute(IRobot robot) => robot.Move(Distance);
    }
}

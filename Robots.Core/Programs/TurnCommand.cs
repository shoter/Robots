using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.SDK;

namespace Robots.Core.Programs
{
    public class TurnCommand : ICommand
    {
        private double angle;

        public TurnCommand(double angle)
        {
            this.angle = angle;
        }

        public string Describe() => $"Turn by angle of {angle}";

        public Task Execute(IRobot robot) => robot.Turn(angle);
    }
}

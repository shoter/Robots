using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.SDK;

namespace Robots.Core.Programs
{
    public class TurnCommand : IProgramCommand
    {
        public double Angle { get; }

        public TurnCommand(double angle)
        {
            this.Angle = angle;
        }

        public string Describe() => $"Turn by angle of {Angle}";

        public void Execute(IRobot robot) => robot.Turn(Angle);
    }
}

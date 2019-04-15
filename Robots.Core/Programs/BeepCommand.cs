using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.SDK;

namespace Robots.Core.Programs
{
    public class BeepCommand : IProgramCommand
    {
        public string Describe() => "Beep";

        public void Execute(IRobot robot) => robot.Beep();
    }
}

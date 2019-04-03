using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.SDK;

namespace Robots.Core.Programs
{
    public class BeepCommand : ICommand
    {
        public string Describe() => "Beep";

        public Task Execute(IRobot robot) => robot.Beep();
    }
}

using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.Programs
{
    public class ProgramEventArgs : EventArgs
    {
        public IRobot Robot { get; }

        public ProgramEventArgs(IRobot robot)
        {
            this.Robot = robot;
        }
    }
}

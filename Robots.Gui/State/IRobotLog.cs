﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public interface IRobotLog
    {
        IEnumerable<string> Messages { get; }

        IRobotLog AddMessage(string msg);

        IRobotLog Clear();
    }
}
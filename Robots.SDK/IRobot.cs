﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.SDK
{
    public interface IRobot
    {
        void Move(double distance);
        void Turn(double angle);
        void Beep();
    }
}

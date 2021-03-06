﻿using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.Programs
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProgramCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        void Execute(IRobot robot);

        /// <summary>
        /// Returns human readable string describing the current command.
        /// </summary>
        /// <returns></returns>
        string Describe();
    }
}

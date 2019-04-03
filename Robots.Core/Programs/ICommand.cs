using Robots.SDK;
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
    public interface ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        Task Execute(IRobot robot); 
    }
}

using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Robots.Gui.Modules.Programs.ProgramView
{
    public interface IProgramViewViewModel
    {
        /// <summary>
        /// Should return hidden if no program is selected. Otherwise true
        /// </summary>
        Visibility CanShow { get; }

        string Name { get; set; }

        void SetProgram(IProgram program);
    }
}

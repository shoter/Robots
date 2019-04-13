using Robots.Gui.Helpers;
using Robots.Gui.Modules.Programs.AddProgram.CommandList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Robots.Gui.Modules.Programs.AddProgram
{
    public interface IAddProgramViewModel
    {
        /// <summary>
        /// Fired when user tries to add new command to the program.
        /// </summary>
        event EventHandler<AddCommandEventArgs> AddCommand;

        CommandListBaseViewModel CommandAddViewModel { get; }

        IUserControlProxy CommandAddControl { get;  }

        CommandListState CommandState { get; } 
    }
}

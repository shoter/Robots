using Robots.Gui.Base;
using Robots.Gui.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Robots.Gui.Modules.Programs.AddProgram.CommandList
{
    public interface ICommandListFactory
    {
        CommandListBaseViewModel CreateViewModel(CommandListState state);

        IUserControlProxy CreateControl(CommandListState state);
    }
}

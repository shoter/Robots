using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ProgramCommandList
{
    public interface IProgramCommandListViewModel
    {
        IEnumerable<IProgramCommandListItemViewModel> Commands { get; }

        void AddCommand(IProgramCommand command);

        void SetProgram(IProgram program);
    }
}

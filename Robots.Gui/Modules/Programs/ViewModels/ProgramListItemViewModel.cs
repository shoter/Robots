using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ViewModels
{
    public class ProgramListItemViewModel
    {
        public string Name { get; set; }
        public ulong Id { get; }

        public ProgramListItemViewModel(IProgram program)
        {
            this.Id = program.Id;
            this.Name = program.Name;
        }
    }
}

using Robots.Core.Programs;
using Robots.Gui.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Programs.ProgramView
{
    public class ProgramViewViewModel : ViewModelBase
    {
        private readonly IProgram program;

        public string Name
        {
            get => program.Name;
            set => program.Name = value;
        }

        public List<ProgramViewCommandViewModel> Commands = new List<ProgramViewCommandViewModel>();



        public ProgramViewViewModel(IProgram program)
        {
            this.program = program;
        }

        
    }
}

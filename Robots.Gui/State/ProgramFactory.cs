using Robots.Core.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.State
{
    public class ProgramFactory : IProgramFactory
    {
        private readonly IApplicationState state;

        public ProgramFactory(IApplicationState state)
        {
            this.state = state;
        }
        public IProgram Create()
        {
            var prg = new Program();

            state.AddProgram(prg);

            return prg;
        }
    }
}

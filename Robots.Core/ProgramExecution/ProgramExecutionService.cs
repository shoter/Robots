using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Core.Programs;
using Robots.SDK;

namespace Robots.Core.ProgramExecution
{
    public class ProgramExecutionService : IProgramExecutionService
    {
        private ConcurrentBag<IProgramExecutor> RunningExecutors { get; }

        public bool CanExecute(IProgram program, IRobot robot)
        {
            return RunningExecutors.Any(e => e.Program == program && e.Robot == robot) == false;
        }

        public IProgramExecutor Execute(IProgram program, IRobot robot)
        {
            IProgramExecutor executor = new ProgramExecutor(program, robot);
        }

        private void onExecutionEnd(object sender, EventArgs e)
        {
            var executor = sender as IProgramExecutor;


        }
    }
}

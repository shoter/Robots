using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Robots.Core.Programs;
using Robots.SDK;

namespace Robots.Core.ProgramExecution
{
    public class ProgramExecutionService : IProgramExecutionService
    {
        private List<IProgramExecutor> RunningExecutors { get; } = new List<IProgramExecutor>();

        private readonly Mutex runningExecutorsMutex = new Mutex();

        public event EventHandler<ProgramExecutionServiceProgramEventArgs> ProgramExecutionStarted;
        public event EventHandler<ProgramExecutionServiceProgramEventArgs> ProgramExecutionCompleted;

        private IProgramExecutorFactory ExecutorFactory { get; }

        public ProgramExecutionService(IProgramExecutorFactory factory)
        {
            this.ExecutorFactory = factory;
        }

        public bool CanExecute(IProgram program, IRobot robot)
        {
            return RunningExecutors.Any(e => e.Robot == robot) == false;
        }

        public bool IsProgramRunning(IProgram program)
        {
            return RunningExecutors.Any(e => e.Program == program);
        }

        public IProgramExecutor Execute(IProgram program, IRobot robot)
        {
            if(CanExecute(program, robot) == false)
            {
                throw new RobotsException("Robot is already running a program!");
            }

            IProgramExecutor executor = ExecutorFactory.Create(program, robot);

            lock(runningExecutorsMutex)
            {
                RunningExecutors.Add(executor);
            }

            executor.ProgramExecutionEnd += onExecutionEnd;

            executor.Start();
            ProgramExecutionStarted?.Invoke(this, new ProgramExecutionServiceProgramEventArgs(program));
            return executor;
        }


        private void onExecutionEnd(object sender, EventArgs e)
        {
            var executor = sender as IProgramExecutor;

            lock(runningExecutorsMutex)
            {
                RunningExecutors.Remove(executor);
            }

            ProgramExecutionCompleted?.Invoke(this, new ProgramExecutionServiceProgramEventArgs(executor.Program));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Robots.Core.Programs;
using Robots.SDK;

namespace Robots.Core.ProgramExecution
{
    public class ProgramExecutor : IProgramExecutor
    {
        public bool IsCompleted { get; private set; } = false;
        public bool HasBeenStarted { get; private set; } = false;

        public IProgram Program { get; }

        public IRobot Robot { get; }

        public event EventHandler<ProgramExecutorCommandEventArgs> CommandExecutionStart;
        public event EventHandler<ProgramExecutorCommandEventArgs> CommandExecutionEnd;
        public event EventHandler<EventArgs> ProgramExecutionEnd;

        public ProgramExecutor(IProgram program, IRobot robot)
        {
            this.Robot = robot;
            this.Program = program;
        }

        public void Start()
        {
            if (HasBeenStarted)
                throw new RobotsException("Cannot start same executor twice!");
            HasBeenStarted = true;

            ThreadPool.QueueUserWorkItem(start);
        }

        private void start(object _)
        {
            foreach(var c in Program.Commands)
            {
                CommandExecutionStart?.Invoke(this, new ProgramExecutorCommandEventArgs(c, Program, Robot));
                c.Execute(Robot);
                CommandExecutionEnd?.Invoke(this, new ProgramExecutorCommandEventArgs(c, Program, Robot));
            }

            ProgramExecutionEnd?.Invoke(this, EventArgs.Empty);
            IsCompleted = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.SDK;

namespace Robots.Core.Programs
{
    public class Program : IProgram
    {
        private List<IProgramCommand> CommandList { get; } = new List<IProgramCommand>();

        public IEnumerable<IProgramCommand> Commands => throw new NotImplementedException();

        public event EventHandler<ProgramCommandEventArgs> OnCommandExecutionStart;
        public event EventHandler<ProgramCommandEventArgs> OnCommandExecutionEnd;
        public event EventHandler<EventArgs> OnProgramExecutionEnd;

        public void AddCommand(IProgramCommand command)
        {
            CommandList.Add(command);
        }

        public void RemoveCommand(IProgramCommand command)
        {
            CommandList.Remove(command);
        }

        public async Task Start(IRobot robot)
        {
            foreach(var c in Commands)
            {
                OnCommandExecutionStart?.Invoke(this, new ProgramCommandEventArgs(c));
                await c.Execute(robot);
                OnCommandExecutionEnd?.Invoke(this, new ProgramCommandEventArgs(c));
            }

            OnProgramExecutionEnd?.Invoke(this, EventArgs.Empty);
        }
    }
}
